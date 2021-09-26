using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject CreditsMenu;
    public bool QuitGame;

    void Start() {
        MainMenu.SetActive(true);
        CreditsMenu.SetActive(false);
    }

    void Update() {
        if (Input.GetKeyUp(KeyCode.Escape)) {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void PlayBtn() {
        SceneManager.LoadScene("Level1");
    }

    public void CreditsBtn() {
        MainMenu.SetActive(false);
        CreditsMenu.SetActive(true);
    }

    public void BackButton() {
        MainMenu.SetActive(true);
        CreditsMenu.SetActive(false);
    }
    
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Exit Game");
    }
}