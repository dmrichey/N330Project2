using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void Play()
    {
        Debug.Log("Loading");
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Debug.Log("Exiting");
        Application.Quit();
    }
}
