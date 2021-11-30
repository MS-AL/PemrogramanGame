using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    int score = 0;
    bool IsGrounded = false;
    public bool isMoving;
    public Animator anim;
    public SpriteRenderer sprite;
    public float moveSpeed = 5f;
    public Text scoreText;
    public GameObject GameOver;
    public GameObject Winning;
    public GameObject Howto;

    void Start ()
    {
        GameOver.SetActive(false);
        Winning.SetActive(false);
        Howto.SetActive(true);
        Time.timeScale = 0;
    }

    void Update ()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene("main");
            Time.timeScale = 1;
        }
    }

    private void FixedUpdate()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), 0);
		transform.position += move * moveSpeed * Time.deltaTime;

        if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
			Kekanan();
		}
		
        if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
			Kekiri();
		} 

        if (!Input.anyKey) {
			isMoving = false;
			anim.SetBool ("IsMove", false);
            anim.ResetTrigger("Jump");
            anim.ResetTrigger("Walk");
            anim.ResetTrigger("Slide");
            anim.SetTrigger("Idle");
		}
    }
    public void Kekanan()
    {
        isMoving = true;
		sprite.flipX = false;
		anim.SetBool ("IsMove", true);
        anim.SetTrigger("Walk");
    }

    public void Kekiri()
    {
        isMoving = true;
		sprite.flipX = true;
		anim.SetBool ("IsMove", true);
        anim.SetTrigger("Walk");
    }

    void OnCollisionStay2D(Collision2D collisionInfo) {
		IsGrounded = true;
	}

	void OnCollisionExit2D(Collision2D collisionInfo) {
		IsGrounded = false;
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("coin"))
        {
            score += 10;
            scoreText.text = "Score : "+ score;
            Destroy(collision.gameObject);
        }

        if (score==120)
        {
            GameOver.SetActive(false);
            Winning.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if(col.gameObject.CompareTag("Enemy"))
        {
            GameOver.SetActive(true);
            Winning.SetActive(false);
            Time.timeScale = 0;
        }
    }

    public void Close()
    {
        Howto.SetActive(false);
        Time.timeScale = 1;
    }
}
