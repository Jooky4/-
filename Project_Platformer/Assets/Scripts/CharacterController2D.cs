using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float speed = 10;
    public float jumpForce = 10;
    [SerializeField]
    private bool isGround = false;
    private Rigidbody2D rb2D;
    private float horizontal;
    private float vertical;
    private bool Jumped = true;
    private bool facingRight = true;
    [SerializeField]
    private bool isLadder = false;
    [SerializeField]
    private bool isjump = false;
  

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        UpdateAxis();
        UpdateFlip();
        UpdateMoveLadder();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
        
    }


    void UpdateAxis()
    {
        Jumped = Input.GetButtonDown("Jump");
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void UpdateFlip()
    {
        if (horizontal > 0 && !facingRight)
            Flip();
        else if (horizontal < 0 && facingRight)
            Flip();
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void Move()
    {
       rb2D.velocity = new Vector2(horizontal * speed, rb2D.velocity.y);
    }

    private void Jump()
    {
        if (Jumped)
        {
            if (isGround)
            {
               rb2D.AddForce(Vector2.up * jumpForce);
            }
            isGround = false;
            isjump = true;

        }
    }



    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.tag == "Ground")
        {
            isGround = true;
            isjump = false;

        }
      
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Ladder")
        {
            isLadder = true;
        }
        //Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);

    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Ladder")
        {
            isLadder = false;
        }
     }
    void UpdateMoveLadder()
    {
        if (isLadder)
        {
            if (vertical != 0)
            {
                transform.Translate(new Vector2(0, speed * vertical * Time.fixedDeltaTime)); // движение по лестнице
                isGround = false;
            }

            if (!isGround && !isjump)
            {

                rb2D.gravityScale = 0;
            }

        }
        else
        {
            rb2D.gravityScale = 1;
        }




    }
}
