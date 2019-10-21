using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Canvas pauseMenu;
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
