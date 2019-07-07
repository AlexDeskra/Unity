using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMechanics : MonoBehaviour
{
    public float ForwardSpeed;
    public static float SpeedModifiers;

    private void Start()
    {
        SpeedModifiers = 1;
    }
    void Update()
    {
        if (Conditions() == true)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(ForwardSpeed*SpeedModifiers, this.GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    private bool Conditions()
    {
        if (PlayerCollisionController.ForwardTrigger == true) return false; //Daca exista un obiect in drumul jucatorului
        if (GameManager.Freeze == true) return false; // Daca Jucatorul nu a fost oprit
        return true;
    }

    public void Jump(float JumpForce)
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, 0);
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpForce));
    }

}
