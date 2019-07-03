using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int team;
    public int trackingID;
    public int playerNumber;
    public float xPosition;
    public float yPosition;
    public float speed;

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
    }
}
