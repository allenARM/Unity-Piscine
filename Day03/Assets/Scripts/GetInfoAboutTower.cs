using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GetInfoAboutTower : MonoBehaviour
{
    public GameObject Tower;
    public Sprite MySprite;
    public GameObject MyTowerImg;
    public GameObject Cost;
    public GameObject Dmg;
    public GameObject Range;
    public GameObject Reload;
    // Start is called before the first frame update
    void Start()
    {
        Cost.GetComponent<Text>().text = Tower.GetComponent<towerScript>().energy.ToString();
        Dmg.GetComponent<Text>().text = Tower.GetComponent<towerScript>().damage.ToString();
        Range.GetComponent<Text>().text = Tower.GetComponent<towerScript>().range.ToString();
        Reload.GetComponent<Text>().text = Tower.GetComponent<towerScript>().fireRate.ToString();
        MyTowerImg.GetComponent<Image>().sprite = MySprite;
    }
}
