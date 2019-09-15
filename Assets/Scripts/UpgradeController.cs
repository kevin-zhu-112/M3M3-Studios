using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    public bool doubleJump = false;
    public Text notification;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GainDoubleJump()
    {
        doubleJump = true;
        notification.text = "You can now double jump.";
    }
}
