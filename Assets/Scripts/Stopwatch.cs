using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour
{
    public Text timer;
    private bool isRunning;
    private float i;
    void Start()
    {
        i = 0;
        isRunning = false;
        StartCoroutine(Timer());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(isRunning)
            {
                isRunning = false;
            }
            else
            {
                isRunning = true;
                StartCoroutine(Timer());
            }

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
    }

    private IEnumerator Timer()
    {
        while (isRunning)
        {
            i = i + 0.01f;
            timer.text = FormatTime(i);
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void Reset()
    {
        i = 0;
        isRunning = false;
        timer.text = FormatTime(i);
    }

    private string FormatTime(float time)
    {
        int minutes = (int)time / 60;
        int seconds = (int)time - 60 * minutes;
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
