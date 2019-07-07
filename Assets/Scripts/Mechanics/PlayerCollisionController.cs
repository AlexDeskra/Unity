using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    private int ForwardTriggerCount;
    public static bool ForwardTrigger;

    void Start()
    {
        ForwardTriggerCount = 0;
    }
    void Update()
    {
        if (ForwardTriggerCount == 0) ForwardTrigger = false;
        else ForwardTrigger = true;

       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            ForwardTriggerCount++;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            ForwardTriggerCount--;
        }
    }
}
