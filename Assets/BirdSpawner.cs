using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    private static BirdSpawner _instance;

    public static BirdSpawner Instance
    {
        get { return _instance; }
    }

    public bool IsAlreadyCounting { get; set; }

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


    // BEGIN


    public GameObject BirdPrefab;


    private readonly float BIRD_SPAWN_MIN_X = -5;
    private readonly float BIRD_SPAWN_MAX_X = 5;

    private readonly float BIRD_SPAWN_Y = -2;
    private readonly float BIRD_SPAWN_Z = -2;


    // Start is called before the first frame update
    void Start()
    {
        SpawnBirds(1);
    }

    public void SpawnBirds(int amount)
    {
        if (BirdPrefab == null)
        {
            Debug.LogError("FATAL : No bird prefab!");
            return;
        }

        for (int i = 0; i < amount; i++)
        {
            Vector3 position =
                new Vector3(Random.Range(BIRD_SPAWN_MIN_X, BIRD_SPAWN_MAX_X), BIRD_SPAWN_Y, BIRD_SPAWN_Z);

            SpawnBird(position);
        }
    }

    private void SpawnBird(Vector3 position)
    {
        GameObject bird = Instantiate(BirdPrefab);
        bird.transform.position = position;
    }

    // Update is called once per frame
    void Update()
    {
    }
}