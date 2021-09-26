using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    int score = 0;
    public int scoremax1;
    public int scoremax2;
    public bool lv1;
    public bool lv2;
    public Text scoreText;
    public Text winText;
    public BallController Ball;
    
    void Start() {
        winText.text = "";
    }

    public void Scoring() {
        if (lv1 == true) {
            score +=2;
            scoreText.text = "Score : "+ score;

            if(score >= scoremax1){
                Ball.ResetBall();
                SceneManager.LoadScene("Level2");
            }
        }
        if (lv2 == true) {
            score +=5;
            scoreText.text = "Score : "+ score;

            if (score >= scoremax2) {
                Ball.ResetBall();
                winText.text = "You Win\nCongratulations!\n\nPress Escape!";
            }
        }
    } 
    void Update() {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
} 
