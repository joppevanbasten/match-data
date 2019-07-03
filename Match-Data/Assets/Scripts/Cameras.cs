using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameras : MonoBehaviour
{
    public Camera mainCam;
    public Camera cam1;
    public Camera cam2;
    public Camera cam3;
    static public int cam = 0;
    private void Start()
    {
        cam1.gameObject.tag = "Main Camera";
        cam1.enabled = true;
        cam2.enabled = false;
        cam3.enabled = false;
    }

    public void SwitchCam()
    {
        cam++;
        if (cam > 2)
            cam = 0;
        switch (cam)
        {
            case 0:
                cam1.gameObject.tag = "MainCamera";
                cam2.gameObject.tag = "Untagged";
                cam3.gameObject.tag = "Untagged";
                cam1.enabled = true;
                cam2.enabled = false;
                cam3.enabled = false;
                break;
            case 1:
                cam2.gameObject.tag = "MainCamera";
                cam1.gameObject.tag = "Untagged";
                cam3.gameObject.tag = "Untagged";
                cam1.enabled = false;
                cam2.enabled = true;
                cam3.enabled = false;
                break;
            case 2:
                cam3.gameObject.tag = "MainCamera";
                cam2.gameObject.tag = "Untagged";
                cam1.gameObject.tag = "Untagged";
                cam1.enabled = false;
                cam2.enabled = false;
                cam3.enabled = true;
                break;
        }
    }
}
