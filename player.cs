using UnityEngine;
using System.Collections;
using System;

public class player : MonoBehaviour
{
    private Rigidbody2D myRigid;

    [SerializeField]
    private Transform[] groundPoints;

    [SerializeField]
    private float groundRadius;

    [SerializeField]
    private LayerMask whatIsGround;

    private bool isGrounded;

    [SerializeField]
    private float speed;

    private bool isJumping;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private bool airCTRL;

    private bool facRight;

    private int timeCount = 0;

    float lockPos = 0;





    // Use this for initialization
    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();


    }

    void Update()
    {
        HandleInput();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (gameObject.name == "Player")
        {
            myRigid.constraints = RigidbodyConstraints2D.None;
            float horizontal = Input.GetAxis("Horizontal");

            if (isGrounded)
            {
                HandleMovement(horizontal);
            }

            Flip(horizontal);
            ResetValues();
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, lockPos, lockPos);

        }

        if (gameObject.name == "pPlatform")
        {
            timeCount++;
            myRigid.AddForce(Physics.gravity = new Vector3(0, -1f, 0));
            if (timeCount >= 20)  // das funktioniert noch lange nicht müsste für jedes einzeln angesprochen werden
            {
                myRigid.constraints = RigidbodyConstraints2D.FreezeAll;

            }
        }


    }



    private void HandleMovement(float horizontal)
    {
        if (airCTRL)
        {
            myRigid.velocity = new Vector2(horizontal * speed, myRigid.velocity.y);
        }

        if (isJumping && isGrounded)
        {
            myRigid.AddForce(new Vector2(0, jumpForce));

        }
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground" || coll.gameObject.name == "pPlatform")
        {
            isGrounded = true;
        }

    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground" || coll.gameObject.name == "pPlatform" )
        {
            isGrounded = false;

        }
    }


    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        }
    }

    //private bool IsGrounded()
    //{
    //    if (myRigid.velocity.y <= 0)
    //    {
    //        foreach (Transform point in groundPoints)
    //        {
    //            Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);
    //            for (int i = 0; i < colliders.Length; i++)
    //            {
    //                if (colliders[i].gameObject != gameObject)
    //                {
    //                    return true;
    //                }
    //            }
    //        }
    //    }
    //    return false;
    //}


    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facRight || horizontal < 0 && facRight)
        {
            facRight = !facRight;

            Vector2 theScale = transform.localScale;
            theScale.x *= -1;

            transform.localScale = theScale;
        }
    }


    private void ResetValues()
    {
        isJumping = false;
    }






}
