using System.Collections;
using System.Collections.Generic;
using static System.Math;
using UnityEngine;

public class CharWalk : MonoBehaviour
{
    private Rigidbody2D rb;
    private float HorizontalMove = 0f;
    private bool FacingRight = true;

    public float speed = 1f;

    public Animator animator;

    private float minX;
    private float maxX;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        GameObject background = GameObject.FindGameObjectWithTag("Background");
        Renderer backgroundRenderer = background.GetComponent<Renderer>();
        float backgroundWidth = backgroundRenderer.bounds.size.x;

        Renderer characterRenderer = GetComponent<Renderer>();
        float characterWidth = characterRenderer.bounds.size.x;

        minX = background.transform.position.x - (backgroundWidth / 2) + (characterWidth / 2);
        maxX = background.transform.position.x + (backgroundWidth / 2) - (characterWidth / 2);
    }

    private void Update()
    {
        HorizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        animator.SetFloat("HorizontalMove", Mathf.Abs(HorizontalMove));

        if (HorizontalMove < 0 && FacingRight)
        {
            Flip();
        }
        else if (HorizontalMove > 0 && !FacingRight)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        float clampedX = Mathf.Clamp(rb.position.x, minX, maxX);
        rb.position = new Vector2(clampedX, rb.position.y);

        Vector2 targetVelocity = new Vector2(HorizontalMove * 15f, rb.velocity.y);
        rb.velocity = targetVelocity;
    }

    private void Flip()
    {
        FacingRight = !FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
