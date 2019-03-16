using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelAccessManager : MonoBehaviour
{
    public GameObject[] Row1;
    public GameObject[] Row2;
    public PlayerSaves _playerSaves;
    // Start is called before the first frame update
    void Start()
    {
		if (_playerSaves.Row1 == 0 || _playerSaves.Row2 == 0)
			_playerSaves.SetDefault();
		MakeUnavalible();
		int i;

		for (i = 0; i < _playerSaves.Row1; i++)
			MakeAvalible(Row1[i]);
		for (i = 0; i < _playerSaves.Row2; i++)
			MakeAvalible(Row2[i]);
    }
	void MakeUnavalible()
	{
		for (int i = 0; i < Row1.Length; i++)
		{
			Row1[i].GetComponent<Image>().color = Color.red;
			Row2[i].GetComponent<Image>().color = Color.red;
		}
	}
    void MakeAvalible(GameObject obj)
    {
		obj.GetComponent<Image>().color = Color.green;
	}
}
