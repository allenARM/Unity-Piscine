using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndGameRestart : MonoBehaviour
{
    // Start is called before the first frame update
	public AudioSource audio;
    void Start()
    {
		audio.enabled = false;
		StartCoroutine(reboot());
    }
	IEnumerator reboot()
	{
		yield return new WaitForSeconds(5);
		SceneManager.LoadScene(0);
	}
}
