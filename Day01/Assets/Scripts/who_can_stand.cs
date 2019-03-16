using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class who_can_stand : MonoBehaviour
{
    public GameObject   target;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name != target.name)
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
    }
}
