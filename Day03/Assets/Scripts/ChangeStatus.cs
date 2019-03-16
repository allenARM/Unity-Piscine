using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeStatus : MonoBehaviour
{
    private GameObject _gameManager;
    public GameObject Hp;
    public GameObject Energy;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        Hp.GetComponent<Text>().text = (_gameManager.GetComponent<gameManager>().playerHp).ToString();
        Energy.GetComponent<Text>().text = (_gameManager.GetComponent<gameManager>().playerEnergy).ToString();
    }
}
