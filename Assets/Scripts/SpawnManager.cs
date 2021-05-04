using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private Vector2 spawnPos;
    private float spawnPosX;
    private float spawnPosY;
    private bool canSpawn;

    // Start is called before the first frame update
    void Start()
    {
        canSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            StartCoroutine(Spawner());
            canSpawn = false;
        }
    }

    void SpawnEnemy(int enemyType, int quantity)
    {
        for (int n = 0; n < quantity; n++)
        {
            spawnPosX = Random.Range(transform.position.x - 15, transform.position.x + 15);
            spawnPosY = Random.Range(transform.position.y - 15, transform.position.y + 15);
            spawnPos = new Vector2(spawnPosX, spawnPosY);
            Instantiate(enemyPrefabs[enemyType], spawnPos, transform.rotation);
        }
    }

    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(6);
        int e = Random.Range(0, enemyPrefabs.Length);
        int n = Random.Range(1, 3);
        SpawnEnemy(e, n);
        canSpawn = true;
    }
}
