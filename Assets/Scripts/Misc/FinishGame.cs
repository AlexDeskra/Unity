using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    private GameObject GameManager;

    private void Start()
    {
        GameManager = GameObject.Find("GameManager");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true) GameManager.GetComponent<GameManager>().FinishGame();
    }
}
