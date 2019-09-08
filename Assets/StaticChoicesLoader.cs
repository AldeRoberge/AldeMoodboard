using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StaticChoicesLoader : MonoBehaviour
{
    public List<ChoicePair> choices;


    // Start is called before the first frame update
    void Start()
    {
        choices = new List<ChoicePair>
        {
            new ChoicePair(
                new Choice("Bonobo - Migration", "", "bonobo"),
                new Choice("Justin Bieber - My World 2.0", "", "bieber")),

            new ChoicePair(
                new Choice("C#", "", "csharp"),
                new Choice("ActionScript", "", "actionscript")),

            new ChoicePair(
                new Choice("Justin Trudeau", "", "trudeau"),
                new Choice("Andrew Scheer", "", "andrew-scheer")),


            new ChoicePair(
                new Choice("Foreurs", "", "vd_foreurs"),
                new Choice("Huskies", "", "rn_huskies")),


            new ChoicePair(
                new Choice("Microsoft", "", "microsoft"),
                new Choice("Apple", "", "apple")),


            new ChoicePair(
                new Choice("Super Mario Bros 3", "", "microsoft"),
                new Choice("Fornite", "", "fortnite")),


            new ChoicePair(
                new Choice("Sony", "", "sony"),
                new Choice("Nikon", "", "nikon")),


            new ChoicePair(
                new Choice("Ableton Live", "", "ableton"),
                new Choice("FL Studio", "", "fl_studio")),

            new ChoicePair(
                new Choice("Val-d'Or'", "", "vd"),
                new Choice("Rouyn-Noranda", "", "rn")),


            new ChoicePair(
                new Choice("Burger King", "", "burger_king"),
                new Choice("Mc Donald", "", "mc_donald")),

            new ChoicePair(
                new Choice("Samsung", "", "samsung"),
                new Choice("iPhone", "", "iphone")),


            new ChoicePair(
                new Choice("Open Source", "", "open_source"),
                new Choice("Closed Source", "", "closed_source")),

            new ChoicePair(
                new Choice("Lego", "", "lego"),
                new Choice("Mega Blocks", "", "mega_blocks")),

            new ChoicePair(
                new Choice("Rick and Morty", "", "rick_and_morty"),
                new Choice("Family Guy", "", "family_guy")),


            new ChoicePair(
                new Choice("Chien", "", "dog"),
                new Choice("Chat", "", "cat")),

            new ChoicePair(
                new Choice("Reddit", "", "reddit"),
                new Choice("Facebook", "", "facebook")),

            new ChoicePair(
                new Choice("Jurassic Park", "", "jurassic_park"),
                new Choice("Jurassic Park 2", "", "jurassic_park2")),
        };
    }
}


public class ChoicePair
{
    public Choice goodChoice;
    public Choice badChoice;


    public ChoicePair(Choice goodChoice, Choice badChoice)
    {
        this.goodChoice = goodChoice;
        this.badChoice = badChoice;
    }
}


public class Choice
{
    public string UNKNOWN_TEXTURE_DEFAULT_PATH = "unknown.png";

    private string title;
    private string description;
    public string imagePath;
    private Texture2D image;

    public Choice(string title, string description, string imagePath)
    {
        this.title = title;
        this.description = description;
        this.imagePath = imagePath;


        LoadImage(imagePath);
    }


    private Texture2D LoadImage(string filePath)
    {
        Texture2D ret = Resources.Load<Texture2D>("Choices/" + filePath);


        if (ret == null)
        {
            Debug.LogError("Fatal : '" + filePath + "' does not exist.");
        }

        return ret;
    }
}