using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_platform : MonoBehaviour
{
public Vector3 toObject;
Vector3 origPoint;
public float Speed;
float distance;
bool reached = false;

public void Start()
{
    origPoint = transform.position;
}

public void Update()
{
    if(!reached)
    {
        distance = Vector3.Distance(transform.position, toObject);
        if(distance > 0.01f)
            move (transform.position, toObject);
        else
            reached = true;
    }
    else
    {
        distance = Vector3.Distance(transform.position, origPoint);
        if(distance > 0.01f)
            move (transform.position, origPoint);
        else
            reached = false;
    }
}

    void move(Vector3 pos, Vector3 towards)
    {
        transform.position = Vector3.MoveTowards(pos, towards, Speed);
    }
}
