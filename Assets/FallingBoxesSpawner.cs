using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(StaticChoicesLoader))]
public class FallingBoxesSpawner : MonoBehaviour
{
    public TMP_Text infoText;

    private StaticChoicesLoader choiceEngine;

    public readonly Vector3 spawnPoint = new Vector3(0, 3f, -4);

    void Start()
    {
        choiceEngine = this.gameObject.AddComponent<StaticChoicesLoader>();
    }

    public void Activate()
    {
        ChoicePair c = choiceEngine.GetNextChoicePair();

        SpawnACube(c.goodChoice);
        SpawnACube(c.badChoice);
    }

    private void SpawnACube(Choice c)
    {
        // Instantiate cube

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.AddComponent<ChoiceContainer>().choice = c;
        cube.GetComponent<ChoiceContainer>().parent = cube;
        
        cube.AddComponent<Rigidbody>();
        
        // Set texture
        cube.GetComponent<Renderer>().material.mainTexture = c.image;

        // Make it draggable
        Draggable d = cube.AddComponent<Draggable>();

        // Set title info
        d.onClick = () =>
        {
            if (infoText != null)
            {
                infoText.text = c.title;
            }
        };

        // Rotate it
        Quaternion q = cube.transform.rotation; //shows the image properly
        q.z = 180;
        cube.transform.rotation = q;

        // Set to position
        cube.transform.position = spawnPoint;

        cube.transform.localScale = new Vector3(0.90f, 0.90f, 0.90f);
    }
}

public class ChoiceContainer : MonoBehaviour
{

    public GameObject parent;
    
    public Choice choice;
}


class StaticChoicesLoader : MonoBehaviour
{
    public static List<ChoicePair> choices;

    public ChoicePair GetNextChoicePair()
    {
        if (choices.Count == 0)
        {
            Debug.LogError("FATAL: Choice list is empty. No more choices.");
        }

        ChoicePair c = choices[0];
        choices.RemoveAt(0);
        return c;
    }

    // Start is called before the first frame update
    void Awake()
    {
        choices = new List<ChoicePair>
        {
            new ChoicePair(
                new Choice("Bonobo - Migration", "", "bonobo", true),
                new Choice("Justin Bieber - My World 2.0", "", "bieber", false)),

            new ChoicePair(
                new Choice("C#", "", "csharp", true),
                new Choice("ActionScript", "", "actionscript", false)),

            new ChoicePair(
                new Choice("Justin Trudeau", "", "trudeau", true),
                new Choice("Andrew Scheer", "", "andrew-scheer", false)),


            new ChoicePair(
                new Choice("Foreurs", "", "vd_foreurs", true),
                new Choice("Huskies", "", "rn_huskies", false)),


            new ChoicePair(
                new Choice("Microsoft", "", "microsoft", true),
                new Choice("Apple", "", "apple", false)),


            new ChoicePair(
                new Choice("Super Mario Bros 3", "", "microsoft", true),
                new Choice("Fornite", "", "fortnite", false)),


            new ChoicePair(
                new Choice("Sony", "", "sony", true),
                new Choice("Nikon", "", "nikon", false)),


            new ChoicePair(
                new Choice("Ableton Live", "", "ableton", true),
                new Choice("FL Studio", "", "fl_studio", false)),

            new ChoicePair(
                new Choice("Val-d'Or'", "", "vd", true),
                new Choice("Rouyn-Noranda", "", "rn", false)),


            new ChoicePair(
                new Choice("Burger King", "", "burger_king", true),
                new Choice("Mc Donald", "", "mc_donald", false)),

            new ChoicePair(
                new Choice("Samsung", "", "samsung", true),
                new Choice("iPhone", "", "iphone", false)),


            new ChoicePair(
                new Choice("Open Source", "", "open_source", true),
                new Choice("Closed Source", "", "closed_source", false)),

            new ChoicePair(
                new Choice("Lego", "", "lego", true),
                new Choice("Mega Blocks", "", "mega_blocks", false)),

            new ChoicePair(
                new Choice("Rick and Morty", "", "rick_and_morty", true),
                new Choice("Family Guy", "", "family_guy", false)),


            new ChoicePair(
                new Choice("Chien", "", "dog", true),
                new Choice("Chat", "", "cat", false)),

            new ChoicePair(
                new Choice("Reddit", "", "reddit", true),
                new Choice("Facebook", "", "facebook", false)),

            new ChoicePair(
                new Choice("Jurassic Park", "", "jurassic_park", true),
                new Choice("Jurassic Park 2", "", "jurassic_park2", false)),
        };


        Debug.Log("Loaded " + choices.Count + " choice(s).");
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

    public string title;
    public string description;
    public string imagePath;
    public Texture2D image;
    public bool isRight;

    public Choice(string title, string description, string imagePath, bool isRight)
    {
        this.title = title;
        this.description = description;
        this.imagePath = imagePath;
        this.isRight = isRight;

        image = LoadImage(imagePath);
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