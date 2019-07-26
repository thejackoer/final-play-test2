using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rpg_camarazoom : MonoBehaviour
{
    public float zoomSensitivity = 15f;
    public float zoomSpeed = 20f;

    public float zoomMin = 30f;
    public float zoomMax = 70f;

    private float z;

    private Camera maincamera;

    private void Start()
    {
        maincamera = Camera.main;
        z = maincamera.fieldOfView;
    }
    private void Update()
    {
        z -= Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity;
        z = Mathf.Clamp(z, zoomMin, zoomMax);
    }
    private void LateUpdate()
    {
        maincamera.fieldOfView = Mathf.Lerp(maincamera.fieldOfView, z, Time.deltaTime * zoomSpeed);

    }
}
