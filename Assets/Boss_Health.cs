using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Health : MonoBehaviour
{

	public int health = 100;
	public int currentHealth;
	bool isDead = false;

	public BossHealthBar healthBar;

	//public GameObject deathEffect;
	public Animator anim;
	public bool isInvulnerable = false;
	public Transform Spawn;
	Rigidbody2D rb;
	bool hasEnter = false;
	public bool GetBack = false;

	public GameObject ScreenCanvas;
	[SerializeField]SoundManagerScript audio;

	public void SetOn(bool set)
	{
		hasEnter = set;
	}

	void Start()
	{
		audio = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManagerScript>();
		rb = gameObject.GetComponent<Rigidbody2D>();
		currentHealth = health;
		healthBar.SetMaxHealth(health);	
	}

	void Update()
	{	
		Debug.Log(GetBack);
		if(hasEnter)
		{
			GetBack = false;
			anim.SetInteger("State",0);
		}
		else
		{
			if (Vector2.Distance(Spawn.position, rb.position) >= 1)
            {
                GetBack = true;
            }
			else
			{
				GetBack = false;
				anim.SetInteger("State",1);
				currentHealth = 600;
				healthBar.SetHealth(currentHealth);
			}
		}

		if (currentHealth <= 100)
		{
			anim.SetBool("isEnraged", true);
		}
		else anim.SetBool("isEnraged", false);
	}

	public void TakeDamage(int damage)
	{
		if( !isDead )
		{
			if (isInvulnerable)
				return;

			anim.SetTrigger("GetHit");
			currentHealth -= damage;

			if (currentHealth <= 0)
			{
				isDead = true;
				audio.PlaySound("Explosion");
				anim.SetTrigger("Dead");
			}

			healthBar.SetHealth(currentHealth);
		}
	}

	void Die()
	{
		ScreenCanvas.GetComponent<ControllerScreen>().WinningScreen();
		Destroy(gameObject);
	}

}
