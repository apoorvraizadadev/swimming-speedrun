using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float time = 0;
    public string display;
    public TMP_Text text;
    public bool active = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            time += Time.deltaTime;
        }

        /*
        int tiny = Mathf.FloorToInt(time % 600);

        string tinyDisplay;

        if (tiny < 10)
        {
            tinyDisplay = "0" + "0" + tiny;
        }

        else if (tiny < 100)
        {
            tinyDisplay = "0" + tiny;
        }

        else
        {
            tinyDisplay = tiny.ToString();
        }

        if ((time % 60) < 10)
        {
            display = Mathf.FloorToInt(time / 60).ToString() + ":" + "0" + Mathf.FloorToInt(time % 60) + "." + tinyDisplay;
        }

        else
        {
            display = Mathf.FloorToInt(time / 60).ToString() + ":" + Mathf.FloorToInt(time % 60) + "." + tinyDisplay;
        }
        text.text = display;
        */

        text.text = TimeSpan.FromSeconds(time).ToString("mm\\:ss\\.fff");
    }
}
