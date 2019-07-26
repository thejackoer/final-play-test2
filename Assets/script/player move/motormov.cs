using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motormov : MonoBehaviour
{
    public float gravitymod = 9f;
    public float lerpTime = 5f;
    


    [HideInInspector]
    public CharacterController controlCha;

    public float distanceToGround = 0.5f;

    private Vector3 moveDirrection = Vector3.zero;
    private Vector3 targetDirection = Vector3.zero;
    private float fallVel = 0f;
    private bool enpiso;
    private Collider mycollider;
    //inicia referencias
    void Awake()
    {
        controlCha = GetComponent<CharacterController>();
        mycollider = GetComponent<Collider>();
             


    }

    void Start()
    {
        distanceToGround = mycollider.bounds.extents.y;

    }
    void Update()
    {
        //llama el metodo
        enpiso = enpisoCheck();
        // interpolacion de movimiento x y z
        moveDirrection = Vector3.Lerp(moveDirrection, targetDirection, Time.deltaTime * lerpTime);
        //mov en y
        moveDirrection.y = fallVel;
        //mov
        controlCha.Move(moveDirrection * Time.deltaTime);
        //gravedad
        if (!enpiso)
        {
            fallVel -= 90f * gravitymod * Time.deltaTime;
            Debug.Log("33");
        }
    }

    //calcula si esamos en tierra o no
    public bool enpisoCheck()
    {
        RaycastHit hit;
        //comprueba si esta en tierra
        if (controlCha.isGrounded)
        {
            Debug.Log("0");
            return true;
          
        }
        //creando y aplicando el raycast po fisica
        if (Physics.Raycast(mycollider.bounds.center, -Vector3.up, out hit, distanceToGround + 0.1f))
        {

           
            Debug.Log("22");
            return true;

        }
        Debug.Log("si es falso");
        return false;
    }
    //movera al jugador y usado en otros scripts
    public void Move(Vector3 dir)
    {
        targetDirection = dir;

    }
    //detiene elmovimiento
    public void stop()
    {
        moveDirrection = Vector3.zero;
        targetDirection = Vector3.zero;
    }
    // calcula altura  del salto
    public void jump(float jumps)
    {
        if (enpiso)
        {
            fallVel = jumps;

        }
    }


}



