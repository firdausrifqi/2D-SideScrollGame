using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("Move")]
    public float speed;
    public float jumpForce;
    private float input;
    private bool facingright = true;
    public bool jumping = false;
    public bool crouch = false;
    public bool run = false;

    [Header("OTHER")]
    [SerializeField] bool IsGrounded;
    public Transform GroundCheck;
    public float checkradius;
    public LayerMask whatIsGround;
    private Rigidbody2D rb;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Debug.Log(IsGrounded);
        input = Input.GetAxis("Horizontal");
        //rb.velocity = new Vector2(input*speed, rb.velocity.y);
        if(!facingright && input > 0)
        {
            flip();
        }
        else if(facingright && input < 0)
        {
            flip();
        }
        //Crouch State
        if(Input.GetButton("Crouch") && !run)
        {
            crouch = true;
            rb.position = this.rb.position;
            animator.SetInteger("State", 2);
            animator.SetBool("Crouch", true);
        }
        else
        {
            crouch = false;
            animator.SetInteger("State", 0);
            animator.SetBool("Crouch", false);
        }
        
        if ((Mathf.Abs(input) > Mathf.Epsilon) && IsGrounded && !crouch)
        {
            run = true;
            animator.SetInteger("State", 1);
        }
        else
        {
            run = false;
        }
    }

    void Update()
    {
        DoJump();
        if(!crouch)
        {
            rb.velocity = new Vector2(input * speed, rb.velocity.y);
        }
        IsGrounded = Physics2D.OverlapCircle(GroundCheck.position, checkradius, whatIsGround);
        animator.SetFloat("AirSpeed", rb.velocity.y);
        if (IsGrounded)
        {
            jumping = false;
        }
        else jumping = true;

        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            IsGrounded = false;
            jumping = true;
            rb.velocity = Vector2.up * jumpForce;
            animator.SetTrigger("Jump");
        }
    }

    void DoJump()
    {
        if (jumping)
        {
            animator.SetBool("Jumping", jumping);
        }
        else animator.SetBool("Jumping", jumping);
    }

    void flip()
    {
        facingright = !facingright;
        // Vector3 Scale = transform.localScale;
        // Scale.x *= -1;
        // transform.localScale = Scale;
        transform.Rotate(0f,180,0f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(GroundCheck.position, checkradius);    
    }
}
