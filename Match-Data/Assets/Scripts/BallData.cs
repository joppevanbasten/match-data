using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallData : MonoBehaviour
{
    public float xPosition;
    public float yPosition;
    public float zPosition;
    public float ballSpeed;

    public void SetData(float xPos, float yPos, float zPos, float ballspeed)
    {
        xPosition = xPos;
        yPosition = yPos;
        zPosition = zPos;
        ballSpeed = ballspeed;
    }

    void Update()
    {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(xPosition, zPosition, yPosition), ballSpeed);
    }
}
