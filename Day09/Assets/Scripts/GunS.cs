using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class GunS : MonoBehaviour
{
    public float damage = 10f;
	public ParticleSystem _ps;
	public ParticleSystem SparkPS;
	public GameObject dangerZone;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
		{
			Shoot();
			_ps.Play();
		}
		if (Input.GetMouseButtonDown(1))
			StartCoroutine(Spark());
    }
	void Shoot()
	{
		GetComponent<AudioSource>().Play();
		RaycastHit hit;
		if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
		{
			Debug.Log(hit.collider.name);
			EnemyTakeDmg takedmg = hit.transform.GetComponent<EnemyTakeDmg>();
			if (takedmg)
				takedmg.TakeDmg(damage);	
		}
	}
	IEnumerator Spark()
	{
		SparkPS.Play();
		dangerZone.SetActive(true);
		yield return new WaitForSeconds(2);
		dangerZone.SetActive(false);
	}
}
