using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RotateBall : MonoBehaviour
{
	public GameObject MainCam;
	public GameObject FreeLookCam;
	public bool OnGolf;
	public bool SpaceSecond;
	public float Speed = 0.5f;
	float rotationSpeed=0.5f;
	private int NumberOfShoots;
	public SliderNum Value;
	public Text numberOfShoots;
	public Text score;
	// Start is called before the first frame update
	private void Start()
	{
		OnGolf = true;
		MainCam.SetActive(false);
		FreeLookCam.SetActive(true);
		SpaceSecond = true;
		NumberOfShoots = 0;
	}
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Vector3 localForward = transform.worldToLocalMatrix.MultiplyVector(transform.forward);
			if (SpaceSecond)
			{
				GetComponent<Rigidbody>().AddRelativeForce(localForward * Value.sin, ForceMode.Impulse);
				GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * Value.sin, ForceMode.Impulse);
				NumberOfShoots++;
				numberOfShoots.text = NumberOfShoots.ToString();
				score.text = (NumberOfShoots * (1000 + Value.sin)).ToString();
			}
			SpaceSecond = true;
			OnGolf = true;
			FreeLookCam.SetActive(true);
			MainCam.SetActive(false);
		}
		if (Input.GetKeyDown("w"))
		{
			SpaceSecond = false;
			OnGolf = false;
			MainCam.SetActive(true);
			FreeLookCam.SetActive(false);
		}
		CheckRotateBall();
	}
	void CheckRotateBall()
	{
		float turn = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody>().AddTorque(transform.up * Speed * turn, ForceMode.Impulse);
	}
}
