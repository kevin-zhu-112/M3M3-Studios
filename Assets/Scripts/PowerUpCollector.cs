using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollector : MonoBehaviour
{
    public static bool doubleJumpPower =  false;
    public static bool blockPlacePower = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReceiveDoubleJump() {
        doubleJumpPower = true;
    }

    public void ReceiveBlockPlace() {
        blockPlacePower = true;
    }

    public void Reset()
    {
        doubleJumpPower = false;
        blockPlacePower = false;
    }

    public bool getDoubleJumpPower() {
        return doubleJumpPower;
    }

    public bool getBlockPlacePower() {
        return blockPlacePower;
    }
}
