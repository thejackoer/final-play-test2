using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ahogado : MonoBehaviour
{
    public GameObject explorer;
     
    
void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("agua"))
        {
           
            Destroy(transform.parent.gameObject);
            
        }

    }
}
