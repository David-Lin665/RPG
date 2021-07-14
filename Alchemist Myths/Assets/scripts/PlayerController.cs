using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpforce;
    private Rigidbody2D rb;
    private bool facingRight = false;
    private float moveInput;
    private bool isGrounded;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask whatisGround;
    public int extrajumps;
    int jumps;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundcheck.position,checkRadius,whatisGround);
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput*speed, rb.velocity.y);
        if(facingRight==true&& moveInput<0){
            flip();
        }
        if(facingRight!=true&& moveInput>0){
            flip();
        }
    }

    void Update()
    {
        if(isGrounded==true){
            jumps = extrajumps;
        }
        if(Input.GetKeyDown(KeyCode.Space)&&jumps>0){
            rb.velocity = Vector2.up*jumpforce;
            jumps--;
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x*=-1;
        transform.localScale = Scaler;
    }
}