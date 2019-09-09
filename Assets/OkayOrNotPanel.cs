using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OkayOrNotPanel : MonoBehaviour
{
    private static OkayOrNotPanel _instance;

    public static OkayOrNotPanel Instance
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


    public Color goodPanelColor;
    public Color badPanelColor;

    private Image background;
    private TMP_Text text;

    private GameObject panel;
    
    void Start()
    {

        panel = gameObject.transform.GetChild(0).gameObject;
        
        background = panel.GetComponentInChildren<Image>();
        text = panel.GetComponentInChildren<TMP_Text>();
    }

    public void SetIsRight(bool isRight)
    {
        panel.SetActive(true);
        
        if (isRight)
        {
            text.text = "Tu as raison!";
            background.color = goodPanelColor;
        }
        else
        {
            text.text = "Tu n'as pas raison.'";
            background.color = badPanelColor;
        }

        Invoke(nameof(Deactivate), 4.0f);
    }

    public void Deactivate()
    {
        panel.SetActive(false);
    }
}