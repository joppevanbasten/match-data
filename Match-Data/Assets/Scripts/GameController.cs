using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI loadText;
    public Button button;
    int frames;
    
    public GameObject ball;
    public GameObject player;
    public Dictionary<int, List<Player>> playerDict = new Dictionary<int, List<Player>>();
    public Dictionary<int, Ball> ballDict = new Dictionary<int, Ball>();
    List<GameObject> playersGameObjects = new List<GameObject>();
    string path;
    int firstFrame;
    bool isFirstFrame = true;
    bool isLoaded;
    string[] dataStrings;
    bool isPlaying;
    void Start()
    {
        path = Application.dataPath + "/Resources/match_data.dat";
        Debug.Log(path);
        dataStrings = File.ReadAllLines(path);
        firstFrame = int.Parse(dataStrings[0].Split(':')[0]);
        frames = dataStrings.Length;
        slider.maxValue = frames;
        StartCoroutine(GetFileData());
    }

    void Update()
    {
        button.interactable = !isLoaded || isPlaying? false : true;
        slider.gameObject.SetActive(isLoaded ? false : true);
        loadText.gameObject.SetActive(isLoaded ? false : true);
    }
    public void StartGame()
    {
        if (isLoaded && !isPlaying)
        {
            StartCoroutine(PlayGame());
        }
    }
    IEnumerator GetFileData()
    {
        if (File.Exists(path))
        {

            int r = 0;
            for (int j = 0; j < dataStrings.Length; j++)
            {
                
                List<Player> playerList = new List<Player>();
                string[] split = dataStrings[j].Split(':');
                string[] players = split[1].Split(';');
                string[] ballData = split[2].Split(',');

                Ball ball = new Ball(float.Parse(ballData[0])/10, float.Parse(ballData[1])/10, float.Parse(ballData[2])/10, float.Parse(ballData[3])/1000);

                for (int i = 0; i < players.Length - 1; i++)
                {
                    string[] playerData = players[i].Split(',');
                    Player player = new Player(int.Parse(playerData[0]), int.Parse(playerData[1]), int.Parse(playerData[2]), float.Parse(playerData[3])/10, float.Parse(playerData[4])/10, float.Parse(playerData[5]) / 1000);
                    playerList.Add(player);
                }
                ballDict.Add(int.Parse(split[0]), ball);
                playerDict.Add(int.Parse(split[0]), playerList);
                slider.value = j;
                loadText.text = string.Format("{0}/{1}", j, frames);
                r++;
                if (r >= 32)
                {
                    yield return new WaitForFixedUpdate();
                    r = 0;
                }
            }
            isLoaded = true;
            Debug.Log(playerDict.Count);
            Debug.Log(playerDict.Keys);
        }
    }
    IEnumerator PlayGame()
    {
        isPlaying = true;
        for (int i = 0; i < frames-1; i++)
        {
            if (playerDict.ContainsKey(firstFrame + i))
            {
                Debug.Log(i);
                List<Player> players = playerDict[firstFrame + i];
                ball.GetComponent<BallData>().SetData(ballDict[firstFrame + i].xPosition, ballDict[firstFrame + i].yPosition, ballDict[firstFrame + i].zPosition, ballDict[firstFrame + i].ballSpeed);
                if (isFirstFrame)
                {
                    for (int j = 0; j < players.Count; j++)
                    {
                        GameObject g = Instantiate(player);
                        g.GetComponent<PlayerData>().SetData(players[j].team, players[j].trackingID, players[j].playerNumber, players[j].xPosition, players[j].yPosition, players[j].speed);
                        g.GetComponentInChildren<TextMeshPro>().text = g.GetComponent<PlayerData>().playerNumber.ToString();
                        Renderer rend = g.GetComponent<Renderer>();
                        switch (g.GetComponent<PlayerData>().team)
                        {
                            case 0:
                                rend.material.SetColor("_Color", Color.red);
                                break;
                            case 1:
                                rend.material.SetColor("_Color", Color.blue);
                                break;
                            case 2:
                                rend.material.SetColor("_Color", Color.magenta);
                                break;
                            case 3:
                                rend.material.SetColor("_Color", Color.black);
                                break;
                            case 4:
                                rend.material.SetColor("_Color", Color.yellow);
                                break;
                            default:
                                rend.material.SetColor("_Color", Color.white);
                                break;
                        }
                        playersGameObjects.Add(g);
                    }
                    isFirstFrame = false;
                }
                else
                {
                    for (int j = 0; j < players.Count; j++)
                    {
                        playersGameObjects[j].GetComponent<PlayerData>().SetData(players[j].team, players[j].trackingID, players[j].playerNumber, players[j].xPosition, players[j].yPosition, players[j].speed);
                    }
                }
            }
            yield return new WaitForFixedUpdate();
        }
    }
}
