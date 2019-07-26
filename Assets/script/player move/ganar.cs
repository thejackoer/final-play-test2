using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ganar : MonoBehaviour
{
    public float ganare = 0;
    public GameObject gameover;

    void Update()
    {
        if (ganare>=21)
        {
            gameover.SetActive(true);
        }
    }
    public void mainmenu(int _level)
    {

        gameover.SetActive(false);
        SceneManager.LoadScene(_level);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

           gameover.SetActive(false);

    }
    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("obj"))
        {
            ganare = ganare + 1.0f;
            
        }
    }
}
