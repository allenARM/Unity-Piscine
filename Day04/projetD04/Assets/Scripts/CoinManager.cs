using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinManager : MonoBehaviour
{
	public Sonic _sonicManager;
	public Text Coin;
    // Start is called before the first frame update

	void OnTriggerEnter2D(Collider2D col)
	{
		_sonicManager.rings++;
		Coin.text = _sonicManager.rings.ToString();
		gameObject.GetComponent<AudioSource>().Play();
	}
	void OnTriggerExit2D(Collider2D col)
	{
		Destroy(gameObject);
	}
}
