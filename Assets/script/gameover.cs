using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class gameover : MonoBehaviour
{
    public GameObject panmuerte;
    public Canvas can;
    public bool muertepan= false;
   

    bool muerte = false;
   

    public void finjuego()
    {
        if(muerte==false && muertepan==false)
        {
            muerte = true;
            muertepan = true;

            if (muertepan == true)
            {
               
                panmuerte.SetActive(true);

            }
        }

    }
    public void mainmenu(int _level)
    {
       
        panmuerte.SetActive(false);
        SceneManager.LoadScene(_level);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        muerte = false;
        muertepan = false;
        if (muertepan == false)
        {

            panmuerte.SetActive(false);

        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("agua"))
        {
            finjuego();
        }
    }

}
