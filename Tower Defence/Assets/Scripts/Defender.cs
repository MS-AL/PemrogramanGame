using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {
	public bool isPlayer = true;
	private bool isDefend = false;
	public int defense = 300;
	[HideInInspector]
	public int underAttack;
	private float timer = 0;
	private string nameTagLawan;
	// Use this for initialization
	void Start () {
		if (isPlayer) {
			nameTagLawan = "Enemy";
		}
		else{
			nameTagLawan = "Player";
		}
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (isDefend) {
			//attack
			timer += Time.deltaTime;
			if (timer > 0.6f) {
				defense -= underAttack;
				timer = 0;
			}
		}
		if (defense <= 0) {
			Destroy (gameObject);
		}
		if (transform.position.x > 9 || transform.position.x < -9) {
			Destroy (gameObject);
		}
	}
	private void OnCollisionEnter2D (Collision2D Collision)
	{
		isDefend = true;
		Attacker m = Collision.gameObject.GetComponent<Attacker> ();
		if (m != null)
			m.underAttack = 0;
		Defender d = Collision.gameObject.GetComponent<Defender> ();
	}

    public void OnCollisionExit2D(Collision2D Collision)
    {
	isDefend = false;
	}
}