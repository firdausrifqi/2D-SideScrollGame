using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    GameObject target;
    public float speed = 2;
    Rigidbody2D bulletRB;
    public int Damage = 10;

    void Start()
    {
       bulletRB = GetComponent<Rigidbody2D>();
       target = GameObject.FindGameObjectWithTag("Player");
       Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
       bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        if(hitInfo.name == "Player")
        {
            hitInfo.gameObject.GetComponent<PlayerScript>().TakeDamage(Damage);
        }
        Destroy(this.gameObject, 1); 
    }
    
    void Update()
    {
        
    }
}
