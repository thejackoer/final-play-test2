using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class main : MonoBehaviour
{
    public GameObject cambiamain;
    public GameObject cambiacreditos;


    public EventSystem misEventos;

    public bool menumain = true;
    public bool creditosmain = false;



    public void menumainact()
    {
        menumain = true;
        creditosmain = false;
        if (menumain == true)
        {
            cambiamain.SetActive(true);
            cambiacreditos.SetActive(false);
        }
        SeleccionarNuevo();
    }

    public void menucredito()
    {
        menumain = false;
        creditosmain = true;
        if (creditosmain == true)
        {
            cambiamain.SetActive(false);
            cambiacreditos.SetActive(true);

        }
        SeleccionarNuevo();
    }

    public void SeleccionarNuevo()
    {
        //misEventos.GetComponent<EventSystem>().SetSelectedGameObject(level1);
        misEventos.SetSelectedGameObject(GameObject.FindGameObjectWithTag("seleccionable"));
    }
}
