using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectListBuilder : MonoBehaviour
{

    public List<Object> TempList; // Lista temporara cu care ne construim lista statica

    public GameObject Canvas;

    //Variabile pentru plasarea butoanelor pe ecran
    public int XStart;
    public int YStart;
    public int XAdd;
    public int YAdd;

    private void Start()
    {
        int X = XStart; int Y = YStart;
        Canvas = GameObject.Find("Canvas");
        foreach (Object i in TempList) //Construim ObjectManager.ObjectList
        {
            i.CreateButton(Canvas);
            i.PlaceButton(X,Y);
            X += XAdd;Y += YAdd;
            ObjectManager.ObjectList.Add(i);
        }

    }
}
