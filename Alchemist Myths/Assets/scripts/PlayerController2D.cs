using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{   
    private Rigidbody2D rb;
    public float speed = 5f;
    public float jumpforce;
    private float MoveInput;

    

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        MoveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed*MoveInput,rb.velocity.y);
    }
}  
