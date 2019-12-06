using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.timeScale > .001f)
        {
            transform.position += new Vector3(0, 0, 0.15f);
        }
        if (transform.position.z >= 45)
        {
            Destroy(gameObject);
        }
    }

}
