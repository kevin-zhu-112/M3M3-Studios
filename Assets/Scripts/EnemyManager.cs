using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Canvas victoryScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("ShoeBoss") == null)
        {
            victoryScreen.transform.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
