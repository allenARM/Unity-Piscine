using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderNum : MonoBehaviour
{
	public float frequency = 1;
	public float periodicity = 1;
	public float amplitude = 6;
	public Slider slider;
	public float sin;
    // Update is called once per frame
    void Update()
    {
        sin = Mathf.Sin(frequency * Mathf.PI * (Time.time * periodicity / 3)) * amplitude;
		sin += 1;
		Debug.Log(sin);
		slider.value = sin;
    }
}
