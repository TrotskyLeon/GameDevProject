using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public Transform leftSpawn;
    public Transform rightSpawn;
    public Transform bottomSpawn;
    public Transform topSpawn;

    Transform[] spawnLocations;

    public GameObject enemyPrefab;

    System.Random rng = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        spawnLocations = new Transform[] { leftSpawn, rightSpawn, bottomSpawn, topSpawn };

        StartCoroutine(SpawnTime(2, enemyPrefab));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
        }
    }

    IEnumerator SpawnTime(float time, GameObject enemy)
    {
        while (true)
        {
            int currentSpawnLocation = rng.Next(0, 4);
            Transform spawn = spawnLocations[currentSpawnLocation];

            enemy = Instantiate(enemyPrefab, spawn.position, spawn.rotation);
            
            yield return new WaitForSeconds(time);
        }
    }

}
