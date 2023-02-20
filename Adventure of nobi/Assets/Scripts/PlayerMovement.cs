using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public CharController2D controller;

    public Animator animator;
    public float runSpeed = 40f; 
    float horizontalMove = 0f;

    bool jump = false;
    bool crouch = false;

    // public int maxHealth = 100;
    // public int currentHealth;

    // public HealthBar healthBar;

    void Start()
    {
        // currentHealth = maxHealth;
        // healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
       horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
    
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

     if(Input.GetButtonDown("Jump"))
    {
        jump = true;
        animator.SetBool("IsJumping", true);
    }
    if(Input.GetButtonDown("Crouch"))
    {
        crouch = true;
        //damage
        // TakeDamage(20);

    }

    else if (Input.GetButtonUp("Crouch"))
    {
        crouch = false;

    } 
}   
    //damage
    // void TakeDamage (int damage)
    // {
    //     currentHealth -= damage;
    //     healthBar.SetHealth(currentHealth);
    // }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
    void FixedUpdate()
    {
        //crouch jump move
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
