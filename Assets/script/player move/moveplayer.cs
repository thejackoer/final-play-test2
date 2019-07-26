using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveplayer : MonoBehaviour
{

    public bool groound;
    public bool airj;

    private float vel;
    private float walk = 2.5f;
        private float walkrotate = 1.5f;
   //     private float run =5.5f;
        private float airjump = 100.25f;
    private float jump;

    Rigidbody rigid;
   // Animator anima;
    CapsuleCollider coltam;

    // Start is called before the first frame update
    void Start()
    { 
      rigid = GetComponent<Rigidbody>();
    //  anima = GetComponent<Animator>();
      coltam = GetComponent<CapsuleCollider>();
        groound = true;
        airj = false;
    }

    // Update is called once per frame
    void Update()
    {
       float x = Input.GetAxis("Vertical") * walk;
       float z = Input.GetAxis("Horizontal") * walk;

        /*  transform.Translate(x, 0, 0);

          transform.Rotate(0, z, 0);*/

        Vector3 move = new Vector3(z * walk * Time.deltaTime, 0, x* walk * Time.deltaTime);
      //  Vector3 rot = new Vector3(0, z * walk * Time.deltaTime,0);

        rigid.MovePosition(transform.position + move);
     //   rigid.MoveRotation(transform.rotation);

        if (Input.GetButtonDown("Jump")&& groound==true)
        {
            rigid.AddForce(0, airjump*3, 0);
            //anima.SetTrigger("salto");
            groound = false;

       
        }
        if(Input.GetButtonDown("Jump") && airj == false)
        {
                rigid.AddForce(0, airjump*2, 0);
                airj = true;
        }
    }

 

}
