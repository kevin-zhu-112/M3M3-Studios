using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject powerUp;
    public GameObject platform;
    public GameObject trigger;

    // Start is called before the first frame update
    void Start()
    {
        //m_Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("ShoeBoss") == null && GameObject.Find("Doodlebob") == null) {
            ShowPowerUp();
        }
        // if (GameObject.Find("PowerUpCollectible") == null && timer < 0f) {
        //     m_Audio.Play(0);
        // }
        

    }

    
    void ShowPowerUp() {
        powerUp.SetActive(true);
        platform.SetActive(true);
        trigger.SetActive(true);
    }
}
