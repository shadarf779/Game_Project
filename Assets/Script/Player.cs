using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float MoveForce = 5f;


    [SerializeField]
    private float JumpForce = 6f;
    [SerializeField]
    private float JumpHoldForce = 0.05f;
    private float JumpHoldTime = 0.5f;
    private float JumpTime = 0;
    [SerializeField]
    private float HoldJumpTime = 0.5f;

    private float movementX;
    private float MovementY;
    [SerializeField]
    private Rigidbody2D MyBody;
    
    private SpriteRenderer sr;
    
    private Animator anim;

    private string Walk_Animation = "Walk";

    private bool isGrounded;

    private string ground_Tag = "Ground";
    private void Awake()
    {
        MyBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Keyboard();
        giveAnimation();
        Jump();
    }

    void Keyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX , 0f , 0f) * Time.deltaTime * MoveForce;
    }
    void Jump()
    {
        if (Input.GetKey(KeyCode.Space) )
        {
            JumpTime += Time.deltaTime;
            if (JumpTime < JumpHoldTime && isGrounded)
            {
                isGrounded = false;
                MyBody.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            }
            if (JumpTime < HoldJumpTime && !isGrounded)
            {
                MyBody.AddForce(new Vector2(0f, JumpHoldForce), ForceMode2D.Impulse);
            }

        }
        if (Input.GetKeyUp(KeyCode.Space) && isGrounded)
        {
            JumpTime = 0f;
        }
       
            
         
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(ground_Tag))
        {
            isGrounded = true;
        }
    }
    void giveAnimation()
    {
        if (movementX > 0)
        {
            anim.SetBool(Walk_Animation, true);
            sr.flipX = false;
        }
        else 
            if (movementX < 0)
        {
            anim.SetBool(Walk_Animation, true);
            sr.flipX = true;
        }else
        {
            anim.SetBool(Walk_Animation, false);
        }
    }
}
