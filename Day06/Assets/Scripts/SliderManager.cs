using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
	public float DecreaseVal;
	public float IncreaseVal;
	public Slider slider;
	public GameObject FPS;
	public GameObject EndGameCam;
	public AudioSource Siren;
	void Awake()
	{
		Siren.enabled = false;
	}
    void Update()
    {
        slider.value -= 0.005f;
		if (slider.value >= 9.6f)
		{
			slider.value = 0;
			FPS.SetActive(false);
			EndGameCam.SetActive(true);
			Time.timeScale = 0;
		}
		if (slider.value >= 7.5f)
			Siren.enabled = true;
		if (slider.value < 7.5f)
			Siren.enabled = false;
    }
	void OnTriggerStay(Collider other)
	{
		slider.value += 0.1f;
	}
}
