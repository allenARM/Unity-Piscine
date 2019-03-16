using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndGame : MonoBehaviour
{
	public Sonic _sonicManager;
	public GameObject EndGameMenu;
	public Text _text;
	// Start is called before the first frame update
    
	void OnTriggerEnter2D(Collider2D col)
	{
		_text.text = _sonicManager.Score.ToString();
		EndGameMenu.SetActive(true);
		Time.timeScale = 0;
		StartCoroutine(waitforsix());
	}
	IEnumerator waitforsix()
	{
		yield return new WaitForSeconds(6);
		SceneManager.LoadScene(0);
	}
}
