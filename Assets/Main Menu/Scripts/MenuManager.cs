using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public GameObject SelectLevel;

    private void Start()
    {
        SelectLevel.SetActive(false);
    }
    public void QuitApplication()
    {
        Application.Quit();
    }

    public void EnableSelectLevel()
    {
        SelectLevel.SetActive(true);
    }

    public void DisableSelectLevel()
    {
        SelectLevel.SetActive(false);
    }
}
