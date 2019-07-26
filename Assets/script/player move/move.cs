using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float movemagnitus = 0.05f;
    public float speed = 0.7f;

    public float turnspeed = 10f;
    public float jumpspeed = 20f;

    private motormov motor;

    private float speedmovemultiplier = 1f;
    private Vector3 direction;

   // public Animator anim;
    //int jumped = Animator.StringToHash("jump");

    private Camera maincamera;
 



    private bool jumped=false;
    private void Awake()
    {
        motor = GetComponent<motormov>();
       // anim = GetComponent<Animator>();

    }

    private void Start()
    {

     //   anime.applyRootMotion = false;
        maincamera = Camera.main;

    }

    private void Update()
    {
        moveandjump();

    }
    //accesorio
    private Vector3 movedirection
    {
        get
        {
            return direction;
        }
        set
        {
            direction = value * speedmovemultiplier;
            if (direction.magnitude > 0.1f)
            {
                Quaternion _newrotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, _newrotation, Time.deltaTime * turnspeed);
            }
            direction *= speed * (Vector3.Dot(transform.forward, direction) + 1f) * 5f;
            motor.Move(direction);

          //  animationmove(motor.controlCha.velocity.magnitude * 0.1f);
        }

    }

    void moving(Vector3 _dir, float _mult)
    {
        speedmovemultiplier = 1 * _mult;
        movedirection = _dir;

    }
    void jump()
    {
        motor.jump(jumpspeed);
        //anim.SetBool("jump",true);

    }
    


    void moveandjump()
    {
        Vector3 moveinput = Vector3.zero;
        Vector3 forw = Quaternion.AngleAxis(-90, Vector3.up) * maincamera.transform.right;

        moveinput += forw * Input.GetAxis("Vertical");
        moveinput += maincamera.transform.right * Input.GetAxis("Horizontal");
       // float moved= Input.GetAxis("Vertical");
        //anim.SetFloat("running", moved);


        //normalizacion
        moveinput.Normalize();
        moving(moveinput.normalized, 1f);

        //salto
        if (motor.controlCha.isGrounded && Input.GetKey(KeyCode.Space))
        {
            jump();
            //   jumped = true;
           
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ground") && jumped == true)
        {
            jumped = false;
        }
    }

    /* void animationmove(float magnitu)
    {
        if (magnitu > movemagnitus)
        {
            float speedanime = magnitu * 2f;
            if (speedanime < 1)
                speedanime = 1f;
            if (anime.GetInteger(parameter_state) != 2)
            {
                anime.SetInteger(parameter_state, 1);
                anime.speed = speedanime;
            }
        }
        else
        {

            if (anime.GetInteger(parameter_state) != 2)
            {
                anime.SetInteger(parameter_state, 0);

            }
        }

    }*/
  

}
