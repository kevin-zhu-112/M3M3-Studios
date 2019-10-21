using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    public Canvas pauseMenu;

    //PlayerControl controls;
    //private bool menuPress = false;

    // void Awake() {
    //     controls = new PlayerControl();

    //     controls.Gameplay.Menu.performed += ctx => menuPress = true;
    //     controls.Gameplay.Menu.canceled += ctx =? menuPress = false;
    // }

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.transform.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            pauseMenu.transform.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
