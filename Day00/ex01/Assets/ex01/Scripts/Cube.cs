using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    float speed = 0;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(0.09f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector2.down * speed);
        if (gameObject.transform.position.x == -3 && gameObject.transform.position.y < -1 && Input.GetKeyDown("a"))
        {
            Debug.Log("Precision: " + ((gameObject.transform.position.y - gameObject.transform.position.y - gameObject.transform.position.y) - 1) * 100);
            Destroy(gameObject);
        }
        if (gameObject.transform.position.x == 0 && gameObject.transform.position.y < -1 && Input.GetKeyDown("s"))
        {
            Debug.Log("Precision: " + ((gameObject.transform.position.y - gameObject.transform.position.y - gameObject.transform.position.y) - 1) * 100);
            Destroy(gameObject);
        }
        if (gameObject.transform.position.x == 3 && gameObject.transform.position.y < -1 && Input.GetKeyDown("d"))
        {
            Debug.Log("Precision: " + ((gameObject.transform.position.y - gameObject.transform.position.y - gameObject.transform.position.y) - 1) * 100);
            Destroy(gameObject);
        }
        if (gameObject && gameObject.transform.position.y < -4.5)
        Destroy(gameObject);
        
    }
}
