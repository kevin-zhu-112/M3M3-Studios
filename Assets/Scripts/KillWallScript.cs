using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillWallScript : MonoBehaviour
{
    GameObject doodlebob;

    // Start is called before the first frame update
    void Start()
    {
        doodlebob = GameObject.Find("Doodlebob");
    }

    // Update is called once per frame
    void Update()
    {
        if (doodlebob.GetComponent<DoodlebobScript>().currState != DoodlebobScript.DoodlebobState.Dead && Time.timeScale > .001f)
        {
            transform.position -= new Vector3(0, 0, .02f);
        }
    }
}
