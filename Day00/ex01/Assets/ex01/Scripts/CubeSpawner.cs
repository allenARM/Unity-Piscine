using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    int     phase;
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        phase = Random.Range(1, 4);
        if (phase == 1 && Random.Range(0.1f, 1) >= 0.98)
        {
            pos = new Vector3(-3, 4, 0);
            Instantiate (obj1, pos, Quaternion.identity);
            phase++;
        }
        else if (phase == 2 && Random.Range(0.1f, 1) >= 0.98)
        {
            pos = new Vector3(0, 4, 0);
            Instantiate (obj3, pos, Quaternion.identity);
            phase++;
        }
        else if (phase == 3 && Random.Range(0.1f, 1) >= 0.98)
        {
            pos = new Vector3(3, 4, 0);
            Instantiate (obj2, pos, Quaternion.identity);
            phase++;
        }
    }
}
