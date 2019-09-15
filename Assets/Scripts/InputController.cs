using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    private float filteredForwardInput = 0f;
    private float filteredTurnInput = 0f;
    private bool grounded = true;
    private bool secondJump = true;

    public bool InputMapToCircular = true;

    public float forwardInputFilter = 5f;
    public float turnInputFilter = 5f;

    public float forwardSpeed = 10f;
    public float turnSpeed = 10f;
    public float jumpForce = 50f;

    private Rigidbody rbody;
    private GameObject upgradeManager;


    public float Forward
    {
        get;
        private set;
    }

    public float Turn
    {
        get;
        private set;
    }

    public bool Action
    {
        get;
        private set;
    }



    void Start()
    {
        upgradeManager = GameObject.Find("UpgradeManager");
        rbody = GetComponent<Rigidbody>();
    }

    void Update()
    {

        //GetAxisRaw() so we can do filtering here instead of the InputManager
        float h = Input.GetAxisRaw("Horizontal");// setup h variable as our horizontal input axis
        float v = Input.GetAxisRaw("Vertical"); // setup v variables as our vertical input axis


        if (InputMapToCircular)
        {
            // make coordinates circular
            //based on http://mathproofs.blogspot.com/2005/07/mapping-square-to-circle.html
            h = h * Mathf.Sqrt(1f - 0.5f * v * v);
            v = v * Mathf.Sqrt(1f - 0.5f * h * h);

        }


        //BEGIN ANALOG ON KEYBOARD DEMO CODE
        if (Input.GetKey(KeyCode.Q))
            h = -0.5f;
        else if (Input.GetKey(KeyCode.E))
            h = 0.5f;

        //END ANALOG ON KEYBOARD DEMO CODE  


        //do some filtering of our input as well as clamp to a speed limit
        filteredForwardInput = Mathf.Clamp(Mathf.Lerp(filteredForwardInput, v,
            Time.deltaTime * forwardInputFilter), -forwardSpeed, forwardSpeed);

        filteredTurnInput = Mathf.Lerp(filteredTurnInput, h,
            Time.deltaTime * turnInputFilter);

        Forward = filteredForwardInput;
        Turn = filteredTurnInput;

        rbody.MovePosition(rbody.position + this.transform.forward * Forward * Time.deltaTime * forwardSpeed);
        rbody.MoveRotation(rbody.rotation * Quaternion.AngleAxis(Turn * Time.deltaTime * turnSpeed, Vector3.up));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                rbody.AddForce(0, jumpForce, 0, ForceMode.Impulse);
            }
            else if (upgradeManager.GetComponent<UpgradeController>().doubleJump && secondJump)
            {
                rbody.AddForce(0, jumpForce, 0, ForceMode.Impulse);
                secondJump = false;
            }
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        grounded = true;
        secondJump = true;
    }

    void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }
}