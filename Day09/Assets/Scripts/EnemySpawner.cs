using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject enemy;                // The enemy prefab to be spawned.
    public GameObject boss;
	public float spawnTime = 3f;            // How long between each spawn.
	public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    private int counter = 0;

    void Start ()
    {
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }


    void Spawn ()
    {
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
        if (counter < 25)
        {
            Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            counter++;
        }
        else
        {
            Instantiate (boss, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            counter = 0;
        }
    }
}
