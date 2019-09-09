using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StaticChoicesLoader))]
public class EmitABunchOfFallingObjects : MonoBehaviour
{
    private StaticChoicesLoader choiceEngine;

    public readonly Vector3 spawnPoint = new Vector3(0, 3f, -4);

    void Start()
    {
        choiceEngine = this.gameObject.AddComponent<StaticChoicesLoader>();

        SpawnChoices();
    }

    void SpawnChoices()
    {
        ChoicePair c = choiceEngine.GetNextChoicePair();

        SpawnACube(c.goodChoice);
        SpawnACube(c.badChoice);
    }

    private void SpawnACube(Choice c)
    {
        // Instantiate cube

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.AddComponent<Rigidbody>();

        // Set texture
        cube.GetComponent<Renderer>().material.mainTexture = c.image;


        // Make it draggable
        cube.AddComponent<Draggable>();

        // Rotate it
        Quaternion q = cube.transform.rotation; //shows the image properly
        q.z = 180;
        cube.transform.rotation = q;

        // Set to position
        cube.transform.position = spawnPoint;
        
        cube.transform.localScale = new Vector3(0.90f, 0.90f, 0.90f);
    }
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

    public Choice(string title, string description, string imagePath)
    {
        this.title = title;
        this.description = description;
        this.imagePath = imagePath;
        
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