using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]private int currentHealth;
    //public HealthBar HP;
    public HealthBar healthBar;
    public int maxHealth = 10;
    public Animator anim;
    CharacterMovement status;
    SoundManagerScript audio;

    

    [Header("PlayerAttack")]
    public Transform BulletSpawn;
    public GameObject Bullet;

    public GameObject ScreenCanvas;

    void Start()
    {
        Time.timeScale = 1f;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        //HP.SetMaxStamina(currentHealth);
        anim = GetComponent<Animator>();
        status = GetComponent<CharacterMovement>();
        audio = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(status.run)
            {
                anim.SetTrigger("RunShoot");
            }
            else if(status.crouch)
            {
                anim.SetTrigger("CrouchShoot");
            }
            else
            {
                anim.SetTrigger("Shoot");
            }
        }
    }

    public void Shoot()
    {
        audio.PlaySound("GunShot");
        Instantiate(Bullet, BulletSpawn.position, BulletSpawn.rotation);
    }

    public void giveHealth(int health)
    {
        currentHealth += health;
    }

    public void TakeDamage(int Damage)
    {
        //Debug.Log("KENA DMG");
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0)
        {
            audio.PlaySound("Explosion");
            anim.SetTrigger("Die");
        }
        else if(currentHealth != 0)
        {
            currentHealth -= Damage;
            anim.SetTrigger("Hurt");
            //HP.SetHealth(currentHealth);
            if(currentHealth <= 0)
            {
                audio.PlaySound("Explosion");
                anim.SetTrigger("Die");
            }
        }
    }

    void Die()
    {
        //SceneManager.LoadScene(0);
        ScreenCanvas.GetComponent<ControllerScreen>().LossingScreen();
        Time.timeScale = 0f;
    }

    // void OnTriggerEnter2D(Collider2D hitInfo)
    // {
    //     //Debug.Log(hitInfo.name);
    //     if(hitInfo.name == "Enemy3Body")
    //     {
    //         TakeDamage(5);
    //     }
        
    // }

}
