using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    public Canvas pauseMenu;

    PlayerControls controls;
    private bool menuPress = false;
    private bool menuActive = false;

    void Awake() {
        controls = new PlayerControls();

        controls.Gameplay.Menu.performed += ctx => menuPress = true;
        controls.Gameplay.Menu.canceled += ctx => menuPress = false;
    }

    public void OnEnable() {
        controls.Enable();
    }

    public void OnDisable() {
        controls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.transform.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (menuPress) //Input.GetKeyUp(KeyCode.Escape))
        {
            menuPress = false;

            if (pauseMenu.transform.gameObject.activeSelf) {
                pauseMenu.transform.gameObject.SetActive(false);
                Time.timeScale = 1.0f;
            } else if (!pauseMenu.transform.gameObject.activeSelf) {
                pauseMenu.transform.gameObject.SetActive(true);
                Time.timeScale = 0f;
            }
        }

    }
}
