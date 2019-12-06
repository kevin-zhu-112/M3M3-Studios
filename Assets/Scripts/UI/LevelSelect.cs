using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{

    public GameObject controls;
    public GameObject titleImage;
    public GameObject menuButtons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void StartLevelOne()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void StartLevelTwo()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void StartLevelZero()
    {
        SceneManager.LoadScene("Level 0");
    }

    public void StartDemo()
    {
        SceneManager.LoadScene("Demo");
    }

    public void OpenControls() {
        controls.SetActive(true);
        titleImage.SetActive(false);
        menuButtons.SetActive(false);
    }

    public void CloseControls() {
        controls.SetActive(false);
        titleImage.SetActive(true);
        menuButtons.SetActive(true);
    }

    public void OpenLevelSelect()
    {
        controls.SetActive(true);
        titleImage.SetActive(false);
        menuButtons.SetActive(false);
    }

    public void CloseLevelSelect()
    {
        controls.SetActive(false);
        titleImage.SetActive(true);
        menuButtons.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
