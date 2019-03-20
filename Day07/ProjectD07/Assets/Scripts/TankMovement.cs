using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
	public float Multipliyer;
	public float ExtraSpeed = 10;
	private Rigidbody _rb;
	void Start()
	{
		_rb = GetComponent<Rigidbody>();
	}
	void Update()
    {
		Vector3 movePos;
		if (Input.GetKey(KeyCode.LeftShift) && ExtraSpeed > 0.19f)
		{
			movePos = transform.forward * Input.GetAxis("Vertical") * (Multipliyer * 2);
			ExtraSpeed -= 0.1f;
		}
		else
			movePos = transform.forward * Input.GetAxis("Vertical") * Multipliyer;
		_rb.velocity = new Vector3(movePos.x, _rb.velocity.y, movePos.z);
		Checkrotation();
		ExtraSpeed += 0.01f;
    }
	void Checkrotation()
	{
		float turn = Input.GetAxis("Horizontal");
		Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);
        _rb.MoveRotation(_rb.rotation * turnRotation);
	}
}
