using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int maxHealth = 50;
    [SerializeField]private int currentHealth;
    public Animator anim;
    GameObject Boss;

    [SerializeField]SoundManagerScript audio;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        Boss = GameObject.FindWithTag("Controller");
        audio = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int Damage)
    {
        Debug.Log("Enemy take damage");
        if(currentHealth <= 0)
        {
            audio.PlaySound("Explosion");
            anim.SetTrigger("Die");
        }
        else if(currentHealth != 0)
        {
            currentHealth -= Damage;
            if(currentHealth <= 0)
            {
                audio.PlaySound("Explosion");
                anim.SetTrigger("Die");
            }
        }
    }

    public void Die()
    {
        Boss.GetComponent<BossController>().tambah();
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.name == "Player")
        {
            hitInfo.gameObject.GetComponent<PlayerScript>().TakeDamage(5);
        }
        
    }
}
