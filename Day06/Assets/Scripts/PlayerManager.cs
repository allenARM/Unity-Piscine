using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	public Camera cam;
	public bool HasKey = false;
	public bool HasDocs = false;
	public GameObject Door;
	public SliderManager _sliderManager;
	public GameObject _pS;
	private bool _pSActive = true;
    void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
			if (hit.collider.CompareTag("Key") && Input.GetKeyDown("e"))
			{
				HasKey = true;
				Destroy(hit.collider);
			}
			if (hit.collider.CompareTag("Generator") && Input.GetKeyDown("e"))
			{
				_pS.SetActive(_pSActive);
				_pSActive = !_pSActive;
			}
			if (hit.collider.CompareTag("Docs") && Input.GetKeyDown("e"))
			{
				HasDocs = true;
				Destroy(hit.collider);
				_sliderManager.EndGameCam.SetActive(true);
				_sliderManager.FPS.SetActive(false);
			}
			if (hit.collider.CompareTag("KeyReader") && HasKey && Input.GetKeyDown("e"))
			{
				Destroy(Door);
			}
		}
    }
}
