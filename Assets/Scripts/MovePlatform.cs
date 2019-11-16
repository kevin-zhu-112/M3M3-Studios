using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    GameObject platform;
    Vector3 finalPos = new Vector3(-0.67f, -9.16f, -48.5f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Slerp(transform.position, finalPos, 0.03f);//Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);
    }
    
}
