using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Projectile;
    public Vector2 projectileVelocity;
    public Vector2 projectileOffset;
    public float cooldown = 0.5f;
    bool isCanShoot = true;
    bool isJump = true;
    bool isDead = false;
        int idMove = 0;
        Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isCanShoot = false;
        EnemyController.EnemyKilled = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            MoveLeft();
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            MoveRight();
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            Jump();
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow)){
            Idle();
        }
        if(Input.GetKeyUp(KeyCode.RightArrow)){
            Idle();
        }
        if(Input.GetKeyDown(KeyCode.Z)){
            Fire();
        }
        Move();
        Dead();
    }
    IEnumerator CanShoot()
    {
        anim.SetTrigger("shoot");
        isCanShoot = false;
        yield return new WaitForSeconds(cooldown);
        isCanShoot = true;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(isJump){
            anim.ResetTrigger("Jump");
            if (idMove == 0) anim.SetTrigger("Idle");
            isJump = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        anim.SetTrigger("Jump");
        anim.SetTrigger("Run");
        anim.SetTrigger("Idle");
        isJump = true;
    }
    private void OnCollisisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag.Equals("Peluru"))
        {
            isCanShoot = true;
        }
        if(collision.transform.tag.Equals("Enemy"))
        {
            //SceneManager.LoadScene("Game Over")
            isDead = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.transform.tag.Equals("Coin")){
            Data.score += 15;
            Destroy(collision.gameObject);
        }
    }
    public void MoveRight()
    {
        idMove = 1;
    }
    public void MoveLeft()
    {
        idMove = 2;
    }
    private void Move()
    {
        if (idMove == 1 && !isDead){
            if (!isJump) anim.SetTrigger("Run");
            transform.Translate(1 * Time.deltaTime * 5f, 0,0);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (idMove == 2 && !isDead)
        {
            if (!isJump) anim.SetTrigger("Run");
            transform.Translate(-1 * Time.deltaTime * 5f, 0, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }  
    public void Jump(){
        if (!isJump){
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300f);
        }
    }
    public void Idle(){
        if (!isJump){
            anim.ResetTrigger("Jump");
            anim.ResetTrigger("Run");
            anim.SetTrigger("Idle");
        }
        idMove = 0;
    }
    private void Dead(){
        if (!isDead){
            if (transform.position.y < -10f){
                isDead = true;
            }
        }
    }
    void Fire()
    {
        if (isCanShoot)
        {
            GameObject bullet = Instantiate(Projectile, (Vector2)transform.position - 
                projectileOffset * transform.localScale.x, Quaternion.identity);

            Vector2 velocity = new Vector2 (projectileVelocity.x * 
                transform.localScale.x, projectileVelocity.y);
                bullet.GetComponent<Rigidbody>().velocity = velocity * -1;

            Vector3 scale = transform.localScale;
            bullet.transform.localScale = scale * -1;

            StartCoroutine(CanShoot());
            anim.SetTrigger("shoot");
        }
    }
}
