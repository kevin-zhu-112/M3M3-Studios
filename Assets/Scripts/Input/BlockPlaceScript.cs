using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BlockPlaceScript : MonoBehaviour
{
    public GameObject block;
    public bool power = true;
    public bool hasBlock = true;

    public GameObject potentialBlock;
    public bool hovered = false;

    PlayerControls controls;
    private bool pickUpControl = false;

    void Awake() {
        controls = new PlayerControls();
        controls.Gameplay.PickUp.performed += ctx => pickUpControl = true;
        controls.Gameplay.PickUp.canceled += ctx => pickUpControl = false;
    }

    public void OnEnable() {
        controls.Enable();
    }

    public void OnDisable() {
        controls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyUp(KeyCode.F) || pickUpControl) && power)
        {   

            pickUpControl = false;
            if (hasBlock)
            {
                PlaceCube();
            }
            else if (hovered)
            {
                StoreCube();
            }
        }
    }

    void PlaceCube()
    {
        block.SetActive(true);
        Instantiate(block, transform.position, transform.rotation);
        Destroy(potentialBlock);
        block = null;
        hasBlock = false;
    }

    void StoreCube()
    {
        hasBlock = true;
        block = potentialBlock;
        potentialBlock.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Placeable" && !hasBlock) 
        {
            potentialBlock = other.gameObject;
            hovered = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Placeable")
        {
            hovered = false;
        }
    }
}
