using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StaticChoicesLoader : MonoBehaviour
{
    public List<Choice> choices;


    // Start is called before the first frame update
    void Start()
    {
    }
}


public enum GoodOrBad
{
    GOOD,
    BAD
}

public class Choice
{
    public string UNKNOWN_TEXTURE_DEFAULT_PATH = "unknown.png";
    
    private string title;
    private string description;
    private bool isGood;
    private Texture2D image;
    
    public Choice(string title, string description, bool isGood, string imagePath)
    {
        this.title = title;
        this.description = description;
        this.isGood = isGood;

        if (File.Exists(imagePath))
        {
            image = LoadImage(imagePath);
        }
        else
        {
            Debug.LogError("Fatal : Could not get image '" + imagePath + "' for choice '" + title + "'.'");
            image = LoadImage(UNKNOWN_TEXTURE_DEFAULT_PATH);
        }
    }

    private Texture2D LoadImage(string filePath)
    {
        byte[] fileData = File.ReadAllBytes(filePath);
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.

        return tex;
    }
}