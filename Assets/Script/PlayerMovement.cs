using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed; 
    [SerializeField] private float jump; 
    [SerializeField] private bool wallJump; 
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    
    private Rigidbody2D body;
    private Animator anim; 
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float HInput;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        HInput = Input.GetAxis("Horizontal");
        // When you press the left key : "Input.GetAxis("Horizontal")" = -1
        // When you press the right key: "Input.GetAxis("Horizontal")" = 1
        // body.velocity.y means that we do not want to change the velocity on those axis

        //Flip player when moving left or right
        if (HInput > 0.01f)
            transform.localScale = new Vector3(1, 1, 1);
        else if (HInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        //Set animator parameters
        anim.SetBool("run", HInput != 0);
        anim.SetBool("grounded", isGrounded());
        
        //Wall jumping logic
        if(wallJumpCooldown > 0.2f)
        {
            if(wallJump || !isOnWall())
            body.velocity = new Vector2(HInput * speed,body.velocity.y);

            if(isOnWall() && !isGrounded() && wallJump)
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else
                body.gravityScale = 7;

            //Jump only when press space bar and grounded
            if(Input.GetKey(KeyCode.Space))
                Jump();
        }
        else
            wallJumpCooldown += Time.deltaTime;

    }
    
    private void Jump()
    {
        if(isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jump);
            anim.SetTrigger("jump");
        }
        // Wall Jump
        else if(isOnWall() && !isGrounded() && wallJump)
        {
            if(HInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);

            wallJumpCooldown = 0;
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    private bool isOnWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        return !isOnWall(); // && isGrounded() HInput == 0 &&
    }
}
