using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DataManger : MonoBehaviour
{
    public PlayerSaves _playerSaves;
    public Sonic SonicX;
	public TimeManager _time;
	public Text _text;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SonicX.isDead)
            PlayerPrefs.SetInt("Death", _playerSaves.Death + 1);
		SonicX.Score = SonicX.rings * (100 - _time.secs);
		_text.text = SonicX.Score.ToString();
	}
    private void OnDisable()
    {
        if (SonicX.Score > _playerSaves.Score)
            PlayerPrefs.SetInt("Score", SonicX.Score);
    }
}
