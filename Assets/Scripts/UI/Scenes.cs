using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Instruction()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
