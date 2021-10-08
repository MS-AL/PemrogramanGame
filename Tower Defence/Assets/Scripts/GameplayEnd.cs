using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayEnd : MonoBehaviour {
	float timer = 0;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Data.isGameOver) {
			timer += Time.deltaTime;
			if (timer > 2) {
				SceneManager.LoadScene ("GameOver");
			}
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
	}
}