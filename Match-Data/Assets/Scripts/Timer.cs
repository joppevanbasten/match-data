using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public bool IsDone { get; private set; }
    public bool Running { get; set; }
    public bool Repeat { get; private set; }

    private float baseTime;
    [SerializeField]
    private float time;
    private Action callback;

    /// <summary>
    /// Starts New Timer
    /// </summary>
    /// <param name="g">gameObjet the timer is set on</param>
    /// <param name="t">Time for the Timer</param>
    /// <param name="callback">Function that gets called after the timer is over</param>
    /// <returns></returns>
    public static Timer StartNew(GameObject g, float t, Action callback = null)
    {
        var timer = g.AddComponent<Timer>();
        timer.SetTime(t);
        timer.SetCallback(callback);
        timer.Running = true;
        return timer;
    }
    /// <summary>
    /// Starts a timer that repeats itself
    /// </summary>
    /// <param name="g">gameObjet the timer is set on</param>
    /// <param name="t">Time for the Timer</param>
    /// <param name="callback">Function that gets called after the timer is over</param>
    /// <returns></returns>
    public static Timer StartNewRepeat(GameObject g, float t, Action callback = null)
    {
        var timer = StartNew(g, t, callback);
        timer.Repeat = true;
        return timer;
    }

    //sets time
    protected void SetTime(float t)
    {
        baseTime = t;
        time = t;
    }
    //Sets the Action for the Timer
    protected void SetCallback(Action callback)
    {
        this.callback = callback;
    }
    /// <summary>
    /// Toggles between running and not running
    /// </summary>
    public void Toggle()
    {
        Running = !Running;
    }
    /// <summary>
    /// resumes the timer
    /// </summary>
    public void Resume()
    {
        Debug.Log("resumed");
        Running = true;
    }


    void Update()
    {
        if (Running && time > 0)
        {
            time -= Time.deltaTime;
            Debug.Log(time);
            if (time < 0)
            {

                if (!Repeat) Running = false;
                IsDone = true;
                time = baseTime;
                if (callback != null)
                    callback.Invoke();
                if (!Repeat)
                    Destroy(GetComponent<Timer>());
            }
        }
    }
}
