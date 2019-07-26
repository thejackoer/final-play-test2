using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rpg_camaraorbit : rpg_orbita
{
    public Vector3 targetoffset = new Vector3(0, 2, 0);
    public Vector3 cameraPositionZoom = new Vector3(-0.5f, 0, 0);

    public float cameraLength = -10f;
    public float cameraLengthZoom = -5f;

    public Vector2 orbitSpeed = new Vector2(0.01f, 0.01f);
    public Vector2 orbitOffSet = new Vector2(0, -0.8f);
    public Vector2 angleOffset = new Vector2(0, 0.25f);

    private float zoomValue;
    private Vector3 cameraPosTemp;
    private Vector3 camPos;

    private Transform playerTarget;
    private Camera mainCamera;

    private void Start()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;

        sphericalVectorData.length = cameraLength;
        sphericalVectorData.azimuth = angleOffset.x;
        sphericalVectorData.zenith = angleOffset.y;

        mainCamera = Camera.main;

        cameraPosTemp = mainCamera.transform.localPosition;
        camPos = cameraPosTemp;

        //
        rpg_mouselock.Mouselocked = true;

    }
    private void Update()
    {
        handlecamera();
        HandleMouseLocking();
    }

    void handlecamera()
    {
        if (rpg_mouselock.Mouselocked)
        {
            sphericalVectorData.azimuth += Input.GetAxis("Mouse X") * orbitSpeed.x;
            sphericalVectorData.zenith += Input.GetAxis("Mouse Y") * orbitSpeed.y;
        }

        // sphericalVectorData.azimuth += Input.GetAxis("Mouse X")*orbitSpeed.x;
        //sphericalVectorData.zenith += Input.GetAxis("Mouse Y") *orbitSpeed.y;

        sphericalVectorData.zenith = Mathf.Clamp(sphericalVectorData.zenith + orbitOffSet.x, orbitOffSet.y, 0f);

        float _distancetoobject = zoomValue;
        float _deltaDistance = Mathf.Clamp(zoomValue, _distancetoobject, -_distancetoobject);
        sphericalVectorData.length += (_deltaDistance - sphericalVectorData.length);

        Vector3 _lookat = targetoffset;
        //transform.LookAt(_lookat);
        _lookat += playerTarget.position;

        base.Update();

        transform.position += _lookat;
        transform.LookAt(_lookat);

        if (zoomValue == cameraLengthZoom)
        {
            Quaternion _targetRotation = transform.rotation;
            _targetRotation.x = 0f;
            _targetRotation.z = 0f;
            playerTarget.rotation = _targetRotation;


        }
        camPos = cameraPosTemp;
        zoomValue = cameraLength;

    }
    void HandleMouseLocking()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (rpg_mouselock.Mouselocked)
            {
                rpg_mouselock.Mouselocked = false;
            }
            else
            {
                rpg_mouselock.Mouselocked = true;
            }

        }

    }
}
