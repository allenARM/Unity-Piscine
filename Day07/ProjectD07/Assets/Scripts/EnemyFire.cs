using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
	public float Range = 500f;
	public int NumOfBullets = 1000;
	public AudioSource sound;

	void Start()
	{
		StartCoroutine(Fire());
	}
    IEnumerator Fire()
    {
		yield return new WaitForSeconds(0.5f);
		RaycastHit hit;
		if (Physics.Raycast(transform.position, transform.forward, out hit) && NumOfBullets > 0)
		{
			if (hit.collider.CompareTag("Player") || hit.collider.CompareTag("Enemy"))
			{
				Debug.Log("Enemy Fired");
				sound.Play();
				NumOfBullets--;
				hit.collider.GetComponent<NumberOfHp>().HP -= 10;
			}
		}
		StartCoroutine(Fire());
	}
}
