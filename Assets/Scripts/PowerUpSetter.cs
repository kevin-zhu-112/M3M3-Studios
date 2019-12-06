using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSetter : MonoBehaviour
{
    private PowerUpCollector mc = new PowerUpCollector();
    public bool doubleJump;
    public bool pickUp;
    // Start is called before the first frame update
    void Start()
    {
        if (doubleJump) mc.ReceiveDoubleJump();
        if (pickUp) mc.ReceiveBlockPlace();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
