using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject powerUp;
    public GameObject platform;
    private AudioSource m_Audio;
    private float timer = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        m_Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("ShoeBoss") == null) {
            ShowPowerUp();
        }

        timer -= Time.deltaTime;

        if (GameObject.Find("PowerUpCollectible") == null && timer < 0f) {
            m_Audio.Play(0);
        }
        

    }

    
    void ShowPowerUp() {
        powerUp.SetActive(true);
        platform.SetActive(true);
    }
}
