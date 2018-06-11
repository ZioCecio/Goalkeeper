using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    [SerializeField] private Text write;

    public static Timer Instance;

    private float timer;
    private bool stop;
    public bool stopwatch;

    void Awake()
    {
        Instance = this;
    }

    public void Start()
    {

        Reset();
    }

    public void Reset()
    {
        if (!stopwatch)
            timer = 5f;
        else
            timer = 0f;

        stop = false;
    }

    public void Stop()
    {
        stop = true;
    }

    public void Update()
    {
        if (stop)
            return;

        if (!stopwatch)
           timer -= Time.deltaTime;
        else
            timer += Time.deltaTime;

        write.text = "" + getTime();

        if (timer < 0)
            Stop();
    }

    public int getTime()
    {
        return (int)timer;
    }

    public bool isStopped()
    {
        return stop;
    }

    public void isStopwatch(bool state)
    {
        stopwatch = state;
        Reset();
    }
}
