using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
	public int NumOfBullets;
	public Sprite Bullet;
	public bool IsMelee;
	public bool CheckForEnemy;
	public GameObject BulletObj;
	public GameObject CurrentGun;
    // Start is called before the first frame update
    
	void Awake()
	{
        NumOfBullets = 0;
		IsMelee = false;
		CheckForEnemy = false;
	}
	
	void OnTriggerStay2D(Collider2D col)
	{
		if (CheckForEnemy && col.gameObject.CompareTag("Enemy"))
		{
			Debug.Log("ENEMY KILLED WITH SWORD");
			Destroy(col.gameObject);
		}//col.gameObject.PlayDeath();
	}
	public void Shoot()
	{
		NumOfBullets--;
		Instantiate(BulletObj, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
	}
}
