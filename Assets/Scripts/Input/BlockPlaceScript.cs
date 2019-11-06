using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPlaceScript : MonoBehaviour
{
    public GameObject block;
    public bool power = true;
    public bool hasBlock = true;

    public GameObject potentialBlock;
    public bool hovered = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F) && power)
        {
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
        Instantiate(block, transform.position, transform.rotation);
        hasBlock = false;
    }

    void StoreCube()
    {
        hasBlock = true;
        Destroy(potentialBlock);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Placeable")
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
