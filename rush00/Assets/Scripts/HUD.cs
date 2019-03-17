using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using  UnityEngine.UI;
public class HUD : MonoBehaviour
{
	public Text ammoCount;

	public PlayerController pc;

    // Start is called before the first frame update
	void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		if (pc.HasGun)
		{
			if (pc.Gun.GetComponent<GunManager>().IsMelee)
				ammoCount.text = "Melee";
			else
			{
				ammoCount.text = pc.Gun.GetComponent<GunManager>().NumOfBullets.ToString();
			}
		}
		else
			ammoCount.text = "unarmed";
    }
}

