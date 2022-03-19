using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyFollowPlayer : MonoBehaviour
{
    public float speed;
    public float lineOfSide;
    public float shootingRange;
    public float fireRate = 1f;
    private float nextFireTime;
    public GameObject bulletEnemy;
    public GameObject bulletParent;
    private Transform player;
    private float moveDirection = 1;
    private bool facingRight = true;
    string status = "0";
    bool IsTarget = false;

    [SerializeField]SoundManagerScript audio;

    void Start()
    {
        audio = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManagerScript>();
        checktarget();
        // player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        checktarget();
        if(IsTarget)
        {
            float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
            if(distanceFromPlayer < lineOfSide && distanceFromPlayer > shootingRange)
            {
                FlipTowardsPlayer();
                transform.position = Vector2.MoveTowards(this.transform.position,player.position,speed*Time.deltaTime);
            }
            else if(distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
            {
                audio.PlaySound("LaserShot");
                Instantiate(bulletEnemy, bulletParent.transform.position, Quaternion.identity);
                nextFireTime = Time.time + fireRate;
            }
        }
    }

    void checktarget()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            IsTarget = true;
        }
        else
        {
            IsTarget = false;
        }
    }

    void FlipTowardsPlayer()
    {
        status = "flip to player";
        float playerPosition = player.position.x - transform.position.x;
        if (playerPosition<0 && facingRight)
        {
            Flip();
        }
        else if (playerPosition>0 &&!facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        status = "flip";
        moveDirection *= -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSide);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
