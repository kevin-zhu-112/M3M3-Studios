﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonTest : MonoBehaviour
{

    PlayerControls controls;
    
    void Awake() {
        controls = new PlayerControls();

        controls.Gameplay.Test.performed += ctx => test();
        Debug.Log("HELLO?");   
    }

    void test() {
        Debug.Log("Pressed U");
    }

      public void OnEnable()
    {
        controls.Enable();
    }

    public void OnDisable()
    {
        controls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
