using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rpg_cammove : MonoBehaviour
{
    public float length;
    public float zenith;
    public float azimuth;

    public rpg_cammove(float _azimuth, float _zenith, float _length)
    {
        length = _length;
        zenith = _zenith;
        azimuth = _azimuth;

    }

    public Vector3 Direction
    {
        get
        {
            Vector3 dir;
            float _verticalAngle = zenith * Mathf.PI / 2f;
            dir.y = Mathf.Sin(_verticalAngle);
            float _h = Mathf.Cos(_verticalAngle);

            float _horizontalAngle = azimuth * Mathf.PI;
            dir.x = _h * Mathf.Sin(_horizontalAngle);
            dir.z = _h * Mathf.Cos(_horizontalAngle);

            return dir;
        }
    }

    public Vector3 position
    {
        get
        {
            return length * Direction;

        }

    }

}
