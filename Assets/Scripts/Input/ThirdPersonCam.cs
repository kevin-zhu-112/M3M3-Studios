using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonCam : MonoBehaviour
{
    public Transform lookAt;
    public Transform cameraTransform;

    private Camera cam;

    private float dist = 2.0f;
    private float currentX = 10.0f;
    private float currentY = 0.0f;
    private float sensX = 3.5f;
    private float sensY = 2.5f;
    
    private float finalInputX;
    private float finalInputZ;

    private float clampAngle = 80.0f;
    private float clampAngleMin = -25.0f;

    PlayerControls controls;
    private Vector2 cameraVector;

    void Awake() {
        controls = new PlayerControls();

        controls.Gameplay.Camera.performed += ctx => cameraVector = ctx.ReadValue<Vector2>();
        controls.Gameplay.Camera.canceled += ctx => cameraVector = Vector2.zero;
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
        cameraTransform = transform;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = cameraVector.x;
        float inputZ = -cameraVector.y;
        currentX += (inputX * sensX);
        currentY += (inputZ * sensY);

        currentY = Mathf.Clamp(currentY, clampAngleMin, clampAngle);

    }

    void LateUpdate() {
        Vector3 direction = new Vector3(0, 0, -dist);
        Quaternion rot = Quaternion.Euler(currentY, currentX, 0);

        cameraTransform.position = lookAt.position + rot * direction;
        cameraTransform.LookAt(lookAt.position);
    }
}
