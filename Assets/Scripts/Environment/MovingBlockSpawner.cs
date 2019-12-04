using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlockSpawner : MonoBehaviour
{
    public GameObject movingPlatform;
    public float cd;
    public float windup;

    private float countDown;
    // Start is called before the first frame update
    void Start()
    {
        countDown = windup;
    }

    // Update is called once per frame
    void Update()
    {
        if (countDown <= 0f)
        {
            Instantiate(movingPlatform, transform.position, transform.rotation);
            countDown = cd;
        } else
        {
            countDown -= Time.deltaTime;
        }
    }

}
