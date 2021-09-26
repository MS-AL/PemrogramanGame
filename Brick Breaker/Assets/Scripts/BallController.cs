using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    public int force;
	public Transform induk;
	public Text lifeText;
	Rigidbody2D rb;
	bool mulaiGame = false;
	int life=5;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (Input.GetKeyUp(KeyCode.Space) && mulaiGame==false){
			transform.SetParent(null);
			rb.isKinematic = false;
			rb.AddForce (new Vector2(force/4,force+20));
			mulaiGame=true;
		}
		if (Input.GetKeyDown("r")){
			ResetBall();
		}
    }
    public void ResetBall() {
		mulaiGame=false;
		rb.isKinematic = true;
		transform.SetParent(induk);
		transform.localPosition = new Vector2 (0,0.8f);
		rb.velocity = new Vector2 (0,0);
	}
    private void OnCollisionEnter2D (Collision2D coll) {
		if (coll.gameObject.name == "BatasBawah") {
			life--;
			ResetBall ();
			lifeText.text = "Live: "+ life;
			if(life==0){
				SceneManager.LoadScene("GameOver");
			}

		}
		if (coll.gameObject.name == "Paddle") {
			float sudut = (transform.position.y - coll.transform.position.y) * 8f;
			Vector2 arah = new Vector2 (rb.velocity.x, sudut).normalized;
			rb.velocity = new Vector2 (0, 0);
			rb.AddForce (arah * force * 2);
		}
	}
}
