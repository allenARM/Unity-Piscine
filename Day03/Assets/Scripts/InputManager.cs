using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class InputManager : MonoBehaviour
{
    public GameObject CurrentPrefab;
    public GameObject[] TowerPrefabs;

    public Image[] TowersUI;
    public gameManager _gameManger;
    public GameObject PauseMenuObj;
    public GameObject ConfirmMenu;
    public GameObject GameOverMenu;
    public GameObject RetryGameOver;
    public GameObject NextLevelGameOver;
    public int LevelToLoad;
    // Update is called once per frame
    void Update()
    {
        InputManagment();
    }
    private void InputManagment()
    {
        if (_gameManger.GameEnd)
            LoadEnd();
        if (Input.GetKeyDown("1"))
            Choose(0);
        if (Input.GetKeyDown("2"))
            Choose(1);
        if (Input.GetKeyDown("3"))
            Choose(2);
        if (Input.GetMouseButtonDown(0))
            Click();
        if (Input.GetKeyDown(KeyCode.Escape))
            PauseMenu();
        CheckAviability();
        if (_gameManger.currentWave > _gameManger.totalWavesNumber)
            _gameManger.gameOver();
    }
    public void LoadEnd()
    {
        GetRank();
        GameOverMenu.SetActive(true);
        if (_gameManger.score < 3000)
        {
            RetryGameOver.SetActive(true);
            NextLevelGameOver.SetActive(false);
        }
        else
        {
            RetryGameOver.SetActive(false);
            NextLevelGameOver.SetActive(true);
        }
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(LevelToLoad);
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void GetRank()
    {
        if (_gameManger.score <= 2000)
            GameOverMenu.GetComponentInChildren<Text>().text = "F";
        if (_gameManger.score > 2000)
            GameOverMenu.GetComponentInChildren<Text>().text = "D";
        if (_gameManger.score > 3000)
            GameOverMenu.GetComponentInChildren<Text>().text = "C";
        if (_gameManger.score > 4000)
            GameOverMenu.GetComponentInChildren<Text>().text = "B";
        if (_gameManger.score > 5000)
            GameOverMenu.GetComponentInChildren<Text>().text = "A";
        if (_gameManger.score > 5000 && _gameManger.playerHp > _gameManger.playerMaxHp - 7)
            GameOverMenu.GetComponentInChildren<Text>().text = "A+";
        if (_gameManger.score > 5000 && _gameManger.playerHp >= _gameManger.playerMaxHp - 4)
            GameOverMenu.GetComponentInChildren<Text>().text = "A++";
    }
    private void PauseMenu()
    {
        _gameManger.pause(true);
        PauseMenuObj.SetActive(true);
    }
    private void CheckAviability()
    {
        for (int i = 0; i < TowerPrefabs.Length; i++)
        {
            if (_gameManger.playerEnergy < TowerPrefabs[i].GetComponent<towerScript>().energy)
                TowersUI[i].color = Color.red;
            else if (_gameManger.playerEnergy >= TowerPrefabs[i].GetComponent<towerScript>().energy)
                TowersUI[i].color = Color.white;
        }
    }
    private void Click()
    {
        RaycastHit2D _hit;
        _hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0.2f);
        if (CurrentPrefab && _hit.collider.CompareTag("empty"))
        {
            Instantiate(CurrentPrefab, _hit.collider.transform.position, Quaternion.identity);
            _gameManger.playerEnergy -= CurrentPrefab.GetComponent<towerScript>().energy;
            _hit.collider.tag = "tile";
            CurrentPrefab = null;
            for (int i = 0; i < TowerPrefabs.Length; i++)
                TowersUI[i].enabled = true;
        }
        CheckAviability();
    }
    public static Texture2D textureFromSprite(Sprite sprite)
    {
        if(sprite.rect.width != sprite.texture.width)
        {
            Texture2D newText = new Texture2D((int)sprite.rect.width,(int)sprite.rect.height);
            Color[] newColors = sprite.texture.GetPixels((int)sprite.textureRect.x,
            (int)sprite.textureRect.y, 
            (int)sprite.textureRect.width, 
            (int)sprite.textureRect.height );
            newText.SetPixels(newColors);
            newText.Apply();
            return newText;
        }
        return sprite.texture;
    }
    private void Choose(int value)
    {
        if (TowerPrefabs[value])
        {
            if (_gameManger.playerEnergy >= TowerPrefabs[value].GetComponent<towerScript>().energy)
            {
                CurrentPrefab = TowerPrefabs[value];
                TowersUI[value].enabled = false;
                CheckAviability();
            }
        }
    }
    public void ResumGame()
    {
        _gameManger.pause(false);
        ConfirmMenu.SetActive(false);
        PauseMenuObj.SetActive(false);
    }
    public void TrunOnExitMenu()
    {
        ConfirmMenu.SetActive(true);
        PauseMenuObj.SetActive(false);
    }
    public void ConfirmExit()
    {
        Application.Quit();
    }
}
