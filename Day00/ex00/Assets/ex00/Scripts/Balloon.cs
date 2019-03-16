using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    float   timeS = 0;
    float   scaleX = 0;
    float     breath = 8.0f;
    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        if (breath >= 1 && gameObject && Input.GetKeyDown("space"))
        {
            breath--;
            gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0);
        }
        breath += 0.05f;

        gameObject.transform.localScale -= new Vector3(0.008f, 0.008f, 0);

        scaleX = gameObject.transform.localScale.x;
        if (scaleX <= 0.01 || scaleX >= 2)
        {
            Debug.Log("Game Over");
            Debug.Log("Balloon life time: " + Mathf.RoundToInt(timeS) + "s");
            Destroy(gameObject);
        }
        timeS += Time.deltaTime;
    }
}
