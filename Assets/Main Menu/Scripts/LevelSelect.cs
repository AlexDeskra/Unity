using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelSelect : MonoBehaviour
{
    public List<string> List;

    public Button ButtonPrefab;
    private GameObject Canvas;

    private int X;
    private int Y;

    public int AddX;
    public int AddY;

    public int InitialX;
    public int InitialY;

    public int FinX;
    public int FinY;

    private int LevelCount;

    private void Start()
    {
        LevelCount = 0;
        X = InitialX;
        Y = InitialY;
        LoadLevelButtons();
        GameObject.Find("CloseWindow").GetComponent<Button>().onClick.AddListener(CloseWindow);
    }

    public void LoadLevelButtons()
    {
        foreach(string a in List)
        {
            Button Temp = Instantiate(ButtonPrefab);

            Temp.transform.SetParent(this.transform);
            Temp.GetComponentInChildren<Text>().text = a;

            Vector2 pos = new Vector2(X, Y);
            CalculatePosition();

            Temp.transform.localPosition = pos;
            Temp.onClick.AddListener(delegate { LoadScene(a); });           
        }
    }

    private void CalculatePosition()
    {
        if (X < FinX) X += AddX;
        else if (Y > FinY)
        {
            Y += AddY;
            X = InitialX;
        }
    }
    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void CloseWindow()
    {
        this.gameObject.SetActive(false);
    }
}
