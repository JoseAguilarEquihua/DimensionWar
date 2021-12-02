using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DereckMovement : MonoBehaviour
{
    public GameObject BalaPrefab;
    public float JumpForce;
    public float Speed;
    public GameOver GameOver;
    private Rigidbody2D Rigidbody2D;
    private Animator animator;
    private float Horizontal;
    private bool Grounded;
    private float LastShoot;
    public int Health = 5;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("weapon", true );
        ScoreScript.scoreValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if( DevianScript.enemies<=0)
        {
            this.enabled = false;
            Win();
        }
        Horizontal = Input.GetAxisRaw("Horizontal") * Speed;
        animator.SetBool("shot", false);
        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        animator.SetBool("running", Horizontal != 0.0f);

        Debug.DrawRay(transform.position, Vector3.down * 0.8f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.8f))
        {
           Grounded = true;
        }
        else Grounded = false;
        
        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > LastShoot + 0.5f)
        {
            animator.SetBool("shot", true);
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector2.right;
        else direction = Vector2.left;
        Vector3 posicionBala = new Vector3(transform.position.x, transform.position.y + 0.55f, transform.position.z);                

        GameObject bala = Instantiate(BalaPrefab, posicionBala  + direction * 0.5f, Quaternion.identity);
        bala.GetComponent<BalaScript>().SetDirection(direction);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y);
    }

    public void Hit()
    {
        Health = Health - 1;
        if (Health == 0)
        {
            //Destroy(gameObject);
            this.enabled = false;
            GameOverAction();            
        }
    }

    public void GameOverAction()
    {
        GameOver.Setup(ScoreScript.scoreValue);
    }

    public void Win()
    {
        GameOver.Setup(ScoreScript.scoreValue);
    }

}
