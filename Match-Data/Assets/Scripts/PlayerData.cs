using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int team;
    public int trackingID;
    public int playerNumber;
    public float xPosition;
    public float yPosition;
    public float speed;

    private int currentTeam = -20;
    private int currentPlayerNumber = -20;
    void Update()
    {
        gameObject.transform.position = Vector3.Slerp(gameObject.transform.position, new Vector3(xPosition, 4.51f, yPosition), speed);
    }

    public void SetData(int team, int trackingid, int playernumber, float xPos, float yPos,float speed)
    {
        this.team = team;
        this.trackingID = trackingid;
        this.playerNumber = playernumber;
        this.xPosition = xPos;
        this.yPosition = yPos;
        this.speed = speed;
        if (currentPlayerNumber != playerNumber)
        {
            GetComponentInChildren<TextMeshPro>().text = playernumber.ToString() + " / " + team.ToString();
        }
        if (currentTeam != team)
        {
            Renderer rend = GetComponent<Renderer>();
            switch (team)
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
        }
        currentTeam = team;
        currentPlayerNumber = playernumber;
        
    }
}
