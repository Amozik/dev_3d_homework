using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health = 100f;
    [SerializeField] private GUISkin mySkin;
    [SerializeField] private GameObject lamp;
    
    private void OnGUI()
    {
        GUI.backgroundColor = Color.red;
        //GUI.skin = mySkin;
        GUI.HorizontalScrollbar(new Rect (20,20,200,20), 0, health,0, 100);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            lamp.SetActive(!lamp.activeSelf);
        }

    }
}
