using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoveBollTo : MonoBehaviour
{
	public Vector3 coor;
	public Text HoleNum;
	private int tmp;
	void OnTriggerEnter(Collider other)
	{
		other.gameObject.transform.position = coor;
		tmp = int.Parse(HoleNum.text);
		tmp++;
		HoleNum.text = tmp.ToString();
	}
}
