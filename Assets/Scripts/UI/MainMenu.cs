using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //public AudioSource ClickButton;

    public void PlayGame()
    {
        //ClickButton.Play();
        SceneManager.LoadScene("MainScene 1");
    }

    public void QuitGame()
    {
        //ClickButton.Play();
        Application.Quit();
        Debug.Log("Quit");
    }
}
