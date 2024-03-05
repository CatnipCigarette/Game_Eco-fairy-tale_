using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatWalk : MonoBehaviour
{
    public Transform target;
    public float followDistance = 2f;
    public float moveSpeed = 3f;

    public Animator animator;
    private Rigidbody2D rb;
    private bool facingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Calculate the direction along the X-axis only
        Vector3 direction = new Vector3(target.position.x - transform.position.x, 0f, 0f);

        // If the target is far enough, move towards it
        if (direction.magnitude > followDistance)
        {
            direction.Normalize();
            Vector3 targetPosition = transform.position + direction * followDistance;
            rb.velocity = (targetPosition - transform.position).normalized * moveSpeed;
            animator.SetBool("Walking", true);
        }
        else
        {
            rb.velocity = Vector3.zero;
            animator.SetBool("Walking", false);
        }

        // Flip the NPC based on the direction
        if (direction.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (direction.x < 0 && facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
