using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlide : MonoBehaviour
{
    public bool isSliding = false;
    public PlayerController PL;
    public Rigidbody2D rb;
    public Animator anim;
    public BoxCollider2D regColl;
    public BoxCollider2D slideColl;
    public float slideSpeed = 5f;
    public float jumpForce;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        Slide();
        if (Input.GetKeyDown(KeyCode.Space))
        Jump();
    }

    private void Slide()
    {
        isSliding = true;
        anim.SetBool("IsSlide",true);
        anim.SetTrigger("Slide");
        regColl.enabled = false;
        slideColl.enabled = true;

        if (!PL.sprite.flipX)
        {
            rb.AddForce (Vector2.right * slideSpeed); // nnti di copy ke player controller
        }
        else
        {
            rb.AddForce (Vector2.left * slideSpeed);
        }
        StartCoroutine("stopSlide");
    }
    public void Jump()
    {
        rb.AddForce (Vector2.up * jumpForce);
    }
    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(0.7f);
        anim.SetTrigger("Idle");
        anim.SetBool("IsSlide",false);
        regColl.enabled = true;
        slideColl.enabled = false;
        isSliding = false;
    }
}
