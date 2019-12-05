using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealDoor : MonoBehaviour
{
    public GameObject button1;
    public GameObject button2;
    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (button1.GetComponent<DoubleButtonScript>().pressed && button2.GetComponent<ButtonPlaceable>().pressed) {
            door.SetActive(true);
        }
    }
}
