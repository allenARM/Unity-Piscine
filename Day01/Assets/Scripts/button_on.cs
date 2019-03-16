using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_on : MonoBehaviour
{
    public GameObject target;
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == target.name)
        {
            if (door.transform.localScale.x > 0.02f)
                door.transform.localScale = new Vector2(door.transform.localScale.x - 0.01f, door.transform.localScale.y);
            if (door.transform.localScale.y > 0.02f)
                door.transform.localScale = new Vector2(door.transform.localScale.x, door.transform.localScale.y - 0.01f);
        }
    }
}
