using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laddermovement : MonoBehaviour
{

    private float vertical;
    private float speed = 8f;
    private bool isLadder;
    private bool isClimbing;
    [SerializeField] private Rigidbody2D rb;

    // Start is called  before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LianaLadder"))
        {
            isLadder = true;
            Debug.Log("Toimii isLadder");

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("LianaLadder"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }

    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
            Debug.Log("Toimii isClimbing");
        }
    }
    private void FixedUpdate()
    {
        if(isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }
}
