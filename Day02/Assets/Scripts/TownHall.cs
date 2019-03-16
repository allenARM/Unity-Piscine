using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownHall : Building
{
    private float _spawnDelay = 10f;
    public GameObject EntityObj;
    public Vector3 SpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnerTime());
    }

    private IEnumerator SpawnerTime()
    {
        yield return new WaitForSeconds(_spawnDelay);
        SpawnEntity();
        StartCoroutine(SpawnerTime());
    }
    
    private void SpawnEntity()
    {
        Instantiate(EntityObj, new Vector3(SpawnPoint.x + Random.Range(-0.7f, 0.7f), SpawnPoint.y + Random.Range(-0.7f, 0.7f), 0), Quaternion.identity);
    }
}
