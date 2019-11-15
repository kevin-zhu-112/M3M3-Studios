using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject powerUp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("ShoeBoss") == null) {
            ShowPowerUp();
        }
    }

    
    void ShowPowerUp() {
        powerUp.SetActive(true);
    }
}
