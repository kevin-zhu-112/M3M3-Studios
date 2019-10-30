using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenControl : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject controlsMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 
    public void openControl() {
        pauseMenu.SetActive(false);
        controlsMenu.SetActive(true);

    }

    public void closeControl() {
        pauseMenu.SetActive(true);
        controlsMenu.SetActive(false);
    }
}
