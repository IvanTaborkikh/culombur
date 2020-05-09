using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float RunSpeed;
    public float JumpForse;
    private Rigidbody2D rb;
    private bool iR = true;
    private Animator ch;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        ch = GetComponent<Animator>();


    }



    private void FixedUpdate()
    {
        if (Input.GetButtonDown("JumpBut"))
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForse);
            rb.AddForce(new Vector2(rb.velocity.x, JumpForse), ForceMode2D.Impulse);
        }

        float move = Input.GetAxis("Hor");

        if (move > 0 && !iR)
        {
            Flip();
        }

        if (move < 0 && iR)
        {
            Flip();
        }

        if (move != 0)
        {
            ch.SetBool("Walk", true);
        }
        else
        {
            ch.SetBool("Walk", false);
        }

        if (Input.GetButtonDown("Fire"))
        {
            ch.SetTrigger("Attack");
        }
    }

    void Flip()
    {
        iR = !iR;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private void Update()
    {
        Vector3 direction = transform.right * Input.GetAxis("Hor");
        transform.position = Vector3.Lerp(transform.position, transform.position + direction, RunSpeed * Time.deltaTime);

    }
}
