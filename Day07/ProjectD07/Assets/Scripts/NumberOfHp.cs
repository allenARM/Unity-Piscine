using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NumberOfHp : MonoBehaviour
{
	public Text text;
	public int HP = 100;

	void Update()
	{
		if (text)
			text.text = HP.ToString();
		if (HP < 1)
			Destroy(gameObject);
	}
}
