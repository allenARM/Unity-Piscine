using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public  float speed;
	public  float deceleration;
    public  bool live = false;
	public  Vector3 direction;
	bool IsMoving = false;
	int score = -15;

	void Start() {
		gameObject.transform.localScale = new Vector3(0.4f, 0.4f, 0);
        direction = gameObject.transform.position;
		direction.y = 1;
	}

	void Update () {
		if (speed > 0)
			IsMoving = true;
		else {
			if (IsMoving && !live) {
				score += 5;
				Debug.Log("Score:" + score);
			}
			IsMoving = false;
			speed = 0;
		}
		transform.Translate(direction * speed * Time.deltaTime);
		transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 3.8f), transform.position.z);
		
		if (speed <= 2 && transform.position.y <= 3.5F && transform.position.y >= 2.5F)
        {
			speed = 0;
			if (!live)
                Debug.Log("Score: " + score);
			live = true;
			if (transform.localScale.x > 0)
				transform.localScale = new Vector3(transform.localScale.x - 0.005f, transform.localScale.y - 0.005f, transform.localScale.z);
		}
        else if (speed != 0)
            speed -= 0.02f;
		
		if (transform.position.y >= 3.8f || transform.position.y <= -3.8f)
		    direction = new Vector3(direction.x, -direction.y, direction.z);
	}
}
