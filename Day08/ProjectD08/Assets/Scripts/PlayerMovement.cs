using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerMovement : MonoBehaviour
{
	public NavMeshAgent agent;
	public Animator anim;
	void Update()
    {
		gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 90, 1));
		Vector3 target = new Vector3(0,0,0);
		transform.Rotate(new Vector3(-90, transform.rotation.y, transform.rotation.z)); 
        if (Input.GetMouseButton(0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				anim.SetBool("isRunning", true);
				agent.SetDestination(hit.point);
				target = hit.point;
			}
		}
		if (target.x != 0)
			if (Vector3.Distance(transform.position, target) < 5f)
				anim.SetBool("isRunning", false);
    }
}
