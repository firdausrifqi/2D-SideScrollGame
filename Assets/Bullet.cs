using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int Damage = 10;
    public Animator anim;
    bool getHit = false;

    // Update is called once per frame
    void Start()
    {
        Destroy(this.gameObject, 0.5f); 
    }

    void Update()
    {
        if(!getHit)
        {
            rb.velocity = transform.right * speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        if(hitInfo.name == "Enemy1")
        {
            hitInfo.gameObject.GetComponent<EnemyScript>().TakeDamage(Damage);
        }
        else if(hitInfo.name == "Boss")
        {
            hitInfo.gameObject.GetComponent<Boss_Health>().TakeDamage(Damage);
        }
        else if(hitInfo.name == "Enemy2")
        {
            hitInfo.gameObject.GetComponent<EnemyScript>().TakeDamage(Damage);
        }
        else if(hitInfo.name == "Enemy3")
        {
            hitInfo.gameObject.GetComponent<EnemyScript>().TakeDamage(Damage);
        }
        else if(hitInfo.name == "Enemy4")
        {
            hitInfo.gameObject.GetComponent<EnemyScript>().TakeDamage(Damage);
        }
        else if(hitInfo.name == "Enemy5")
        {
            hitInfo.gameObject.GetComponent<EnemyScript>().TakeDamage(Damage);
        }
        else if(hitInfo.name == "Enemy6")
        {
            hitInfo.gameObject.GetComponent<EnemyScript>().TakeDamage(Damage);
        }
        else if(hitInfo.name == "Enemy7")
        {
            hitInfo.gameObject.GetComponent<EnemyScript>().TakeDamage(Damage);
        }
        else if(hitInfo.name == "Enemy8")
        {
            hitInfo.gameObject.GetComponent<EnemyScript>().TakeDamage(Damage);
        }
        else if(hitInfo.name == "Enemy9")
        {
            hitInfo.gameObject.GetComponent<EnemyScript>().TakeDamage(Damage);
        }
        else if(hitInfo.name == "Enemy10")
        {
            hitInfo.gameObject.GetComponent<EnemyScript>().TakeDamage(Damage);
        }
        else if(hitInfo.name == "Enemy11")
        {
            hitInfo.gameObject.GetComponent<EnemyScript>().TakeDamage(Damage);
        }
        else if(hitInfo.name == "Enemy12")
        {
            hitInfo.gameObject.GetComponent<EnemyScript>().TakeDamage(Damage);
        }
        else if(hitInfo.name == "Enemy13")
        {
            hitInfo.gameObject.GetComponent<EnemyScript>().TakeDamage(Damage);
        }
        else if(hitInfo.name == "Enemy14")
        {
            hitInfo.gameObject.GetComponent<EnemyScript>().TakeDamage(Damage);
        }
        else if(hitInfo.name == "Enemy15")
        {
            hitInfo.gameObject.GetComponent<EnemyScript>().TakeDamage(Damage);
        }
        getHit = true;
        anim.SetTrigger("Destroy");  
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
