using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player 
{
    public int team;
    public int trackingID;
    public int playerNumber;
    public float xPosition;
    public float yPosition;
    public float speed;
    
    public Player(int team, int trackingID, int playerNumber, float xPosition, float yPosition, float speed)
    {
        this.team = team;
        this.trackingID = trackingID;
        this.playerNumber = playerNumber;
        this.xPosition = xPosition;
        this.yPosition = yPosition;
        this.speed = speed;
    }
}
