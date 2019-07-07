using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectManager : MonoBehaviour
{
    public static List<Object> ObjectList = new List<Object>();
    
}

[System.Serializable] //Temporar, necesar pentru a popula lista temporara din insepctorul unity
public class Object
{
    public GameObject Prefab;
    public int Count;
    public int MaxCount;
    public Button Button;
    public string Name;

    public Object()
    {
        Prefab = null;
        Count = 0;
        MaxCount = 0;
        Button = null;
    }
    public Object(GameObject prefab, int maxcount, Button button)
    {
        Prefab = prefab;
        Count = 0;
        MaxCount = maxcount;
        Button = button;
    }
    public void ButtonEventToObject()
    {
        Button.onClick.AddListener(CreateObject); // legam functia de creeare a obiectului la butonul respectiv
    }
    
    public void CreateObject()
    {
        if(GameManager.GameStart==false && Count < MaxCount)
            { 
                GameObject.Instantiate(Prefab);
                Count++;
            }
    }

    public void CreateButton(GameObject Canvas)
    {
        Button = GameObject.Instantiate(Button);
        Button.transform.SetParent(Canvas.gameObject.transform);
        ButtonEventToObject();

    }

    public void PlaceButton(int X, int Y)
    {
        Button.gameObject.transform.position = new Vector2(X, Y);
    }
}
