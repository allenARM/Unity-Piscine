using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class EndMenu : MonoBehaviour
{
    public GameObject Menu;

	public void EnableMenu()
	{
		Menu.SetActive(true);
		if (Input.GetKey("r"))
			SceneManager.LoadScene(1);
	}
}
