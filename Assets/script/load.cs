using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class load : MonoBehaviour
{
    public GameObject loading;
    public Slider slider;

    AsyncOperation async;

    public void Loadlevel(string lv)
    {
        StartCoroutine(loadingscreen(lv));

    }


    IEnumerator loadingscreen(string lvl)
    {
        loading.SetActive(true);
        async = SceneManager.LoadSceneAsync(lvl);
        async.allowSceneActivation = false;

        while (async.isDone == false)
        {
            slider.value = async.progress;
            if (async.progress == 0.9f)
            {
                slider.value = 1f;
                async.allowSceneActivation = true;
            }
            yield return new WaitForSeconds(5);
        }


    }


}
