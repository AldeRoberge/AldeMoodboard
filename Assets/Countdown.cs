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
            Destroy(gameObject);
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

    private bool stopCountdown;
    private int currentSecond;

    private Action onCountdownEnd;

    public void BeginCountdown(Action onCountdownEnd)
    {
        this.onCountdownEnd = onCountdownEnd;

        currentSecond = 4;
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
            if (stopCountdown) yield break; // STOP

            switch (currentSecond)
            {
                case 4:
                    text.text = "3...";
                    break;
                case 3:
                    text.text = "2...";
                    break;
                case 2:
                    text.text = "1...";
                    break;
                case 1:
                    text.text = "...";
                    break;
                default:
                    onCountdownEnd.Invoke();
                    text.text = "";
                    break;
            }

            currentSecond--;

            yield return new WaitForSeconds(1f); // CONTINUE
        }
    }
}