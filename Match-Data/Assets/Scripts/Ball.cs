using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball
{
    public float xPosition;
    public float yPosition;
    public float zPosition;
    public float ballSpeed;

    public Ball(float xPos, float yPos, float zPos, float ballSpeed)
    {
        this.xPosition = xPos;
        this.yPosition = yPos;
        this.zPosition = zPos;
        this.ballSpeed = ballSpeed;
    }
}
