using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevianScript : MonoBehaviour
{
    public GameObject BalaPrefab;
    public GameObject Dereck;
    private int Health = 3;
    private Animator animator;

    private float LastShoot;
    public static int enemies;

    void Start()
    {        
        animator = GetComponent<Animator>();
        enemies = 4;
    }


    private void Update()
    {
        animator.SetBool("DevianShooting", false);
        if (Dereck == null) return;

        Vector3 direction = Dereck.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        float distance = Mathf.Abs(Dereck.transform.position.x - transform.position.x);
        //Debug.Log(distance);

        if (distance < 3.2f && Time.time > LastShoot + 1.8f)
        {
            animator.SetBool("DevianShooting", true);
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector2.right;
        else direction = Vector2.left;
        //Vector3 posicionBala = new Vector3(transform.position.x, transform.position.y + 0.55f, transform.position.z);

        GameObject bala = Instantiate(BalaPrefab, transform.position + direction * 0.4f, Quaternion.identity);
        bala.GetComponent<BalaScript>().SetDirection(direction);
    }

    public void Hit()
    {
        Health = Health - 1;
        if (Health == 0)
        {
            enemies -= 1;
            Destroy(gameObject);
            ScoreScript.scoreValue += 10;            
        }
        
    }

}
