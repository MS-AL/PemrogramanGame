using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject CreditMenu;
    public bool QuitGame;

    void Start()
    {
        MainMenu.SetActive(true);
        CreditMenu.SetActive(false);
    }

    void Update() 
    {
        if (Input.GetKeyUp(KeyCode.Escape)) { SceneManager.LoadScene("MainMenu"); }
    }

    public void StartButton() 
    {
        SceneManager.LoadScene("main");
        Time.timeScale = 1;
    }

    public void BackButton() 
    {
        CreditMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void CreditButton() 
    {
        MainMenu.SetActive(false);
        CreditMenu.SetActive(true);
    }

    public void ExitButton() 
    {
        Application.Quit();
    }
}
