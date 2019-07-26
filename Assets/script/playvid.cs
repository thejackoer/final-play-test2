using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;



public class playvid : MonoBehaviour
{
    public PlayableDirector director;
    public TimelineAsset timeline;
    public GameObject objec;

    private float video0 =0.0f;
    private bool animate = false;
      
    void Update()
    {
        if (animate==true)
        {
              video0=  video0 += Time.deltaTime;

                if (video0>=3.0f)
                {
                    
                    Destroy(this.objec);
                }
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player")&&animate==false)
        {
            director.Play(timeline);
            animate = true;

 
        }

    }   
  


}
