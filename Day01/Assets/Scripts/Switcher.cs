using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    public GameObject   mycam;
    public GameObject   red;
    public GameObject   blue;
    public GameObject   yellow;
    GameObject  _nowfollowing;
    // Start is called before the first frame update
    void Start()
    {
        _nowfollowing = red;
        red.GetComponent<playerScript_ex00>().enabled = true;
        red.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        blue.GetComponent<playerScript_ex00>().enabled = false;
        blue.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        yellow.GetComponent<playerScript_ex00>().enabled = false;
        yellow.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }

    // Update is called once per frame
    void chooseHero()
    {
        if (Input.GetKeyDown("1"))
        {
            red.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            blue.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            yellow.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            _nowfollowing = red;
            red.GetComponent<playerScript_ex00>().enabled = true;
            red.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            blue.GetComponent<playerScript_ex00>().enabled = false;
            blue.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            yellow.GetComponent<playerScript_ex00>().enabled = false;
            yellow.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if (Input.GetKeyDown("2"))
        {
            red.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            blue.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            yellow.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            _nowfollowing = yellow;
            red.GetComponent<playerScript_ex00>().enabled = false;
            red.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            blue.GetComponent<playerScript_ex00>().enabled = false;
            blue.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            yellow.GetComponent<playerScript_ex00>().enabled = true;
            yellow.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        if (Input.GetKeyDown("3"))
        {
            red.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            blue.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            yellow.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            _nowfollowing = blue;
            red.GetComponent<playerScript_ex00>().enabled = false;
            red.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            blue.GetComponent<playerScript_ex00>().enabled = true;
            blue.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            yellow.GetComponent<playerScript_ex00>().enabled = false;
            yellow.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
    void reloadscene()
    {
        if (Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown("r"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void Update()
    {
        chooseHero();
        Vector3 tmp = new Vector3(_nowfollowing.transform.position.x, _nowfollowing.transform.position.y + 0.3f, -10);
        mycam.transform.position = tmp;
        reloadscene();
    }
}
