using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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

    public void ExitGame()
    {
        Application.Quit();
    }
}
