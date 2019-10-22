using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Base code taken from https://www.youtube.com/watch?v=LbDQHv9z-F0 and modified to include controller support
public class CameraFollowScript : MonoBehaviour
{
    public float CameraMoveSpeed = 120.0f;
    public GameObject CameraFollowObj;
    Vector3 followPOS;
    public float clampAngle = 80.0f;
    public float InputSensitivity = 150.0f;
    public GameObject CameraObj;
    public GameObject PlayerObj;
    public float camDistanceXToPlayer;
    public float camDistanceYToPlayer;
    public float camDistanceZToPlayer;
    public float mouseX;
    public float mouseY;
    public float finalInputX;
    public float finalInputZ;
    public float smoothX;
    public float smoothY;
    private float rotY = 0.0f;
    private float rotX = 0.0f;

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
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = cameraVector.x;
        float inputZ = -cameraVector.y;
        // mouseX = Input.GetAxis("Mouse X");
        // mouseY = Input.GetAxis("Mouse Y");
        finalInputX = mouseX + inputX;
        finalInputZ = mouseY + inputZ;

        rotY += finalInputX * InputSensitivity * Time.deltaTime;
        rotX += finalInputZ * InputSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
    }

    void LateUpdate()
    {
        CameraUpdater();
    }

    void CameraUpdater()
    {
        Transform target = CameraFollowObj.transform;
        //target.position = target.position + new Vector3(camDistanceXToPlayer, camDistanceYToPlayer, camDistanceZToPlayer);

        float step = CameraMoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        //transform.LookAt(target.position);
    }
}
