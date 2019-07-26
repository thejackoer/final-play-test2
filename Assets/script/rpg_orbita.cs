using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rpg_orbita : MonoBehaviour
{
    public rpg_cammove sphericalVectorData = new rpg_cammove(0, 0, 1);

    protected virtual void Update()
    {
        transform.position = sphericalVectorData.position;

    }
}
