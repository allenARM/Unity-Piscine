using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyTakeDmg : MonoBehaviour
{
	public float health = 10f;
	public NavMeshAgent agent;
	private GameObject player;
	void Start()
	{
		player = GameObject.Find("Player");
	}
	void Update()
	{
		agent.SetDestination(player.transform.position);
	}
	public void TakeDmg(float amount)
	{
		health -= amount;
		if (health <= 0)
			Die();
	}
	void Die()
	{
		Destroy(gameObject);
	}
}
