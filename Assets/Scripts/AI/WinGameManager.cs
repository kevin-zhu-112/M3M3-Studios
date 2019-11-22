using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGameManager : MonoBehaviour
{
    public GameObject victoryScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("mrPEPE") == null)
        {
            victoryScreen.SetActive(true);
        }
    }
    
}
