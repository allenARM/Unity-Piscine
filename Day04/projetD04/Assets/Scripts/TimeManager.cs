using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeManager : MonoBehaviour
{
	public Text txt;
	public int mins;
	public int secs;
    // Start is called before the first frame update
    void Start()
    {
		txt.text = "0:00";
		StartCoroutine(HarmPlayer());
	}

	IEnumerator HarmPlayer()
	{
		yield return new WaitForSeconds(1);
		secs++;
		if (secs == 60)
		{
			secs = 0;
			mins++;
		}
		if (secs < 10)
			txt.text = mins.ToString() + ":0" + secs.ToString();
		else
			txt.text = mins.ToString() + ":" + secs.ToString();
		StartCoroutine(HarmPlayer());
	}
}
