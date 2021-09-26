using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Brick : MonoBehaviour
{
    UIManager ui;

    void Start()
    {
        ui = GameObject.FindWithTag("ui").GetComponent<UIManager>();
    }

    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "ball"){
            Destroy(gameObject);
            ui.Scoring();
        }
    }
}
