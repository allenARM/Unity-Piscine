using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour
{
	public NavMeshAgent agent;
    
	void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("Player") || (other.CompareTag("Enemy")))
			agent.SetDestination(other.transform.position);
	}
}
