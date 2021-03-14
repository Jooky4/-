using UnityEngine;

public class HeroControl : MonoBehaviour
{
    
    [SerializeField]
    private float speed = 3.0F;
    [SerializeField]
    private float jumpForce = 15.0F;
    [SerializeField] 
    private Transform groundCheker;

    bool facingRight = true;
    [SerializeField] 
    private bool isGrounded = false;
    private float Hor;
    private bool Jumped;


    new private Rigidbody2D rigidbody;
  
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
      
    }

    private void Update()
    {
        CheckGround();

        if (!Jumped)
        {
            Jumped = Input.GetButton("Jump");
        }

        if (Hor > 0 && !facingRight)
            Flip();
        else if (Hor < 0 && facingRight)
            Flip();
    }

    private void FixedUpdate()
    {
        Hor = Input.GetAxis("Horizontal");
        Move(Hor, Jumped);
        Jumped = false;
    }

    private void Move(float hor, bool jump)
    {
      //  if (isGrounded)
      //  {
            rigidbody.velocity = new Vector2(hor * speed, rigidbody.velocity.y);
      //  }
        if (isGrounded && jump)
        {
            rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }

    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheker.position, 0.3F);

        isGrounded = colliders.Length > 1;
    }



    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}