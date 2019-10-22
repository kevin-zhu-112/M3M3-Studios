using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCamera : MonoBehaviour
{

    public GameObject player;

    private Vector3 cameraOffset;

    [Range(0.01f, 1.0f)]
    public float smoothFactor = 1.0f;

    public bool lookAtPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate() {
        Vector3 updatePosition = player.transform.position + cameraOffset;

        transform.position = Vector3.Slerp(transform.position, updatePosition, smoothFactor);

        if (lookAtPlayer) {
            transform.LookAt(player.transform);
        }
    }
}
