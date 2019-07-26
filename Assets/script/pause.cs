using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class pause : MonoBehaviour
{
    public GameObject Resume, Quit, pausemenu,inventorymenu;
    public Canvas Canvas;

    public bool pausse = false; 
   public bool inventor =false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausse = true;
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pausebtn();
            }
        }
    }

    public void pausebtn()
    {
        Time.timeScale = 0;
        if (pausse == true)
        {
            pausemenu.SetActive(true);
        }
        else
        {
            pausemenu.SetActive(false);
        }
    }

    public void resume()
    {
        Time.timeScale = 1;
        inventor = false;
        pausse = false;
        pausemenu.SetActive(false);
        inventorymenu.SetActive(false);
    }

    public void inventory()
    {
        inventor = true;
        pausse = false;
        pausemenu.SetActive(false);
        inventorymenu.SetActive(true);

    }

    public void mainmenu(int _level)
    {
        Time.timeScale = 1;
        pausemenu.SetActive(false);
        inventorymenu.SetActive(false);
        SceneManager.LoadScene(_level);
    }


    public void Quitting()
    {
        Application.Quit();
    }
}

