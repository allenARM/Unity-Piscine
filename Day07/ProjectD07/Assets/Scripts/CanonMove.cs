using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonMove : MonoBehaviour
{
	public float Speed;
    void Update()
    {
    	if (Input.GetAxis("Mouse X") > 0)
    		transform.Rotate(Vector3.up * Speed);
		if (Input.GetAxis("Mouse X") < 0)
			transform.Rotate(Vector3.up * -Speed);
    }
}
