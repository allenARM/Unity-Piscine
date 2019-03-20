using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GunManager : MonoBehaviour
{
	public float Range = 50f;
	public int NumOfBullets = 1000;
	public Text text;
	public AudioSource sound;
	public Image crosshair;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			if (Physics.Raycast(transform.position, transform.forward, out hit) && NumOfBullets > 0)
			{
				Debug.Log(hit.transform.name);
				sound.Play();
				NumOfBullets--;
				text.text = NumOfBullets.ToString();
				if (hit.collider.CompareTag("Enemy") || hit.collider.CompareTag("Player"))
				{
					hit.collider.GetComponent<NumberOfHp>().HP -= 10;
					StartCoroutine(makeRed());
				}
			}
		}
    }
	IEnumerator makeRed()
	{
		crosshair.color = Color.red;
		yield return new WaitForSeconds(0.3f);
		crosshair.color = Color.white;
	}
}
