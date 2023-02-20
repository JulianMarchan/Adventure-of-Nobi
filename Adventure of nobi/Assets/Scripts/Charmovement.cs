using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charmovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    public float movement = 6f;
    public float Jumpspeed = 5f;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    private bool isOnGround;
    private Rigidbody2D _rigidbody;

    private Animator playerAnimation;
    void Start()
    {
        playerAnimation = GetComponent<Animator>();
         _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // isOnGround = Physics2D.OverlapCircle(groundCheckPoint.position,groundCheckRadius ,groundLayer);
        isOnGround = Physics2D.OverlapCircle(groundCheckPoint.position,groundCheckRadius ,groundLayer);
                movement = Input.GetAxis ("Horizontal");      
        
        if(movement > 0f)
         {
            // _rigidbody.velocity = new Vector2(movement*speed, _rigidbody.velocity.y);
            _rigidbody.velocity = new Vector2 (movement * speed, _rigidbody.velocity.y);
         }
        else if(movement < 0f)
        {
            // _rigidbody.velocity = new Vector2(movement*speed, _rigidbody.velocity.y);
            _rigidbody.velocity = new Vector2 (movement * speed, _rigidbody.velocity.y);
        }

        // jump
        if(Input.GetButtonDown("Jump") && isOnGround)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, Jumpspeed);
        }
        // playerAnimation.SetFloat("Speed", _rigidbody.velocity.x);
    }
}
////////////////////KAY SIR MEL///////////////////////