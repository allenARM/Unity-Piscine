using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour
{
    float strength;
	bool stopPressSpace = true;
    public GameObject ball;
    Ball ballScript;
	Vector3 prevPosition;

	// Use this for initialization
	void Start () {
		ballScript = ball.GetComponent<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!ballScript.live) {

			if (ballScript.speed == 0 && stopPressSpace) {
				transform.position = new Vector3(ballScript.transform.position.x - 0.2f, ballScript.transform.position.y, ballScript.transform.position.z);
			}

			if (Input.GetKey("space") && ballScript.speed == 0) {
				if (stopPressSpace)
					prevPosition = transform.position;
				if (strength < 7f) {
					strength += 0.2f;
					transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z);
				}
				stopPressSpace = false;
			} 
			else if (strength != 0){
				if(!stopPressSpace) {
					transform.position = prevPosition;
					stopPressSpace = true;
					ballScript.speed = strength;
					ballScript.direction = Vector3.up;
					strength = 0;
				}
			}
		}
	}
}
