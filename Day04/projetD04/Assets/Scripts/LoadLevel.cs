using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadLevel : MonoBehaviour
{
	public int LoadID;
	public void LoadNext()
	{
		SceneManager.LoadScene(LoadID);
	}
}
