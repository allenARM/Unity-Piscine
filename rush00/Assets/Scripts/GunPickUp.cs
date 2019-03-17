using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GunPickUp : MonoBehaviour
{
	public PlayerController _playerManager;
	public Sprite GunImage;
	public int	NumOfBullets;
	public bool IsMelee;
    // Start is called before the first frame update
	void OnTriggerStay2D(Collider2D col)
	{
		if (Input.GetKeyDown("e") && _playerManager.HasGun == false)
		{
			_playerManager.HasGun = true;
			_playerManager.Gun.GetComponent<SpriteRenderer>().sprite = GunImage;
			_playerManager.Gun.SetActive(true);
			_playerManager.Gun.GetComponent<GunManager>().IsMelee = IsMelee;
			_playerManager.Gun.GetComponent<GunManager>().NumOfBullets = NumOfBullets;
			_playerManager.Gun.GetComponent<GunManager>().CurrentGun = gameObject;
			gameObject.SetActive(false);
		}
	}
}
