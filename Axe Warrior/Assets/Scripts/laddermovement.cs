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
    public Platformer.Mechanics.PlayerController PC;
    // Start is called  before the first frame update
    
    void Start()
    {
        PC = GetComponent<Platformer.Mechanics.PlayerController>();
    }
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
            PC.velocity = new Vector2(rb.velocity.x, vertical * speed);
           // rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
       /* else
        {
            rb.velocity = new Vector2(0,0);
            rb.gravityScale = 1f;
        } */
    }
}
