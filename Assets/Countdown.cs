using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    private static Countdown _instance;

    public static Countdown Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // BEGIN CLASS

    private static string[] CountdownStrings = {"3...", "2...", "1..."};

    private TMP_Text text;

    void Start()
    {
        text = gameObject.GetComponent<TMP_Text>();
    }

    private bool stopCountdown = false;
    private int currentSecond = 3;

    public void BeginCountdown()
    {
        currentSecond = 3;
        stopCountdown = false;

        StartCoroutine(nameof(DoStuff));
    }

    public void StopCountdown()
    {
        stopCountdown = true;

        text.text = "";
    }


    IEnumerator DoStuff()
    {
        while (true)
        {
            currentSecond--;

            switch (currentSecond)
            {
                case 3:
                    text.text = "3...";
                    break;
                case 2:
                    text.text = "2...";
                    break;
                case 1:
                    text.text = "1...";
                    break;
                default:
                    text.text = "...";
                    break;
            }


            if (stopCountdown) yield break; // STOP


            yield return new WaitForSeconds(1f); // CONTINUE
        }
    }
}