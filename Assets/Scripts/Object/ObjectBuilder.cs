using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectBuilder : MonoBehaviour
{
    private bool IsBuilt;

    public int ObjectsOnHitbox;

    public Vector2 Offset;

    private void Start()
    {
        GameManager.ObjectSelected = true;
        ObjectsOnHitbox = 0;
        IsBuilt = false;
    }

    private void Update()
    {
        if (IsBuilt == false)
        {
            Vector2 Pos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            Pos += Offset;
            transform.position = Pos;
        }
    }

    public void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject() == false)
        {
            if (ObjectsOnHitbox == 0 && IsBuilt == false && GameManager.GameStart == false)
            {
                IsBuilt = true;
                GameManager.ObjectSelected = false;
            }
            else if (IsBuilt == true && GameManager.ObjectSelected == false && GameManager.GameStart==false)
            {
                IsBuilt = false;
                GameManager.ObjectSelected = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ObjectsOnHitbox++;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        ObjectsOnHitbox--;
    }

}
