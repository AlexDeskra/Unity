using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject Player;
    private GameObject Canvas;

    public static bool Freeze;
    public static bool ObjectSelected;
    public static bool GameStart;

    public static int LevelNumber;

    public Button StartButton;
    public Button StopButton;
    public Button QuitButton;

    public GameObject SelectLevelButton;
    public GameObject SelectLevelScreen;

    public GameObject FinishScreen;

    public Vector2 StartPosition;

    private void Start()
    {
        LevelNumber = 1;

        StartButton = GameObject.Instantiate(StartButton);
        StopButton = GameObject.Instantiate(StopButton);
        QuitButton = GameObject.Instantiate(QuitButton);
        SelectLevelButton = GameObject.Instantiate(SelectLevelButton);
        SelectLevelScreen = GameObject.Instantiate(SelectLevelScreen);
        FinishScreen = GameObject.Instantiate(FinishScreen);

        StartButton.onClick.AddListener(StartGame);
        StopButton.onClick.AddListener(StopGame);
        QuitButton.onClick.AddListener(ExitApplication);

        Player = GameObject.Find("Player");
        Canvas = GameObject.Find("Canvas");

        SelectLevelButton.transform.SetParent(Canvas.transform, worldPositionStays: false);
        SelectLevelScreen.transform.SetParent(Canvas.transform, worldPositionStays: false);
        StartButton.transform.SetParent(Canvas.transform,worldPositionStays:false);
        StopButton.transform.SetParent(Canvas.transform,worldPositionStays:false);
        QuitButton.transform.SetParent(Canvas.transform, worldPositionStays: false);
        FinishScreen.transform.SetParent(Canvas.transform, worldPositionStays: false);

        GameObject.Find("ResetGame").GetComponent<Button>().onClick.AddListener(ResetGame);
        GameObject.Find("NextLevel").GetComponent<Button>().onClick.AddListener(NextLevel);
        SelectLevelButton.GetComponent<Button>().onClick.AddListener(SelectLevel);
        FinishScreen.SetActive(false);

        Freeze = true; //Jucatorul este static
        GameStart = false; //Jocul nu a inceput
        ObjectSelected = false; //Nici un obiect nu este selectat

        Player.transform.position = StartPosition;
    }

    private void Update()
    {
        if (FreezeCondition() == false) Freeze = false;
        else Freeze = true;
    }

    private bool FreezeCondition()
    {
        if (GameStart == false) return true; // daca jocul nu a inceput
        return false;
    }

    public void StartGame()
    {
        if (ObjectSelected == false)
        {
            GameStart = true;
            Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            StopButton.gameObject.SetActive(true);
            StartButton.gameObject.SetActive(false);
        }
    }
    public void StopGame()
    {
        PlayerMechanics.SpeedModifiers = 1;
        GameStart = false;
        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        Player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        Player.transform.position = StartPosition;
        StopButton.gameObject.SetActive(false);
        StartButton.gameObject.SetActive(true);
    }
    public void ResetGame()
    {
        FinishScreen.SetActive(false);
    }
    public void NextLevel()
    {
        LevelNumber++;
        SceneManager.LoadScene("Level" + LevelNumber);
    }

    public void SelectLevel()
    {
        if (GameStart == false)
            if (SelectLevelScreen.activeInHierarchy == false)
                SelectLevelScreen.SetActive(true);
            else SelectLevelScreen.SetActive(false);
    }
    public void FinishGame()
    {
        StopGame();
        FinishScreen.SetActive(true);
    }

    public void ExitApplication()
    {
        if (GameStart == false)
            Application.Quit();
    }
}
