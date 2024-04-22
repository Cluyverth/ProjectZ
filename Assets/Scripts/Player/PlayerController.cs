using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider2D;
    private Animator animator;

    private bool jump = false;
    private int addJumps;
    private float directionMoveInput;

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float jumpForce = 7;
    [SerializeField] private LayerMask layerGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        directionMoveInput = Input.GetAxis("Horizontal");
        if (isGrounded()) 
        {
            addJumps = 1;
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump")) { jump = true; }
        }
        else
        {
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump")) && addJumps > 0) 
            { 
                jump = true;
                addJumps--;
            }
        }
    }

    private void FixedUpdate()
    {
        Move();
        if (jump) { Jump(); }
    }

    private void Move() { rb.velocity = new Vector2(directionMoveInput * moveSpeed, rb.velocity.y); }

    private void Jump() 
    { 
        rb.velocity = Vector2.up * jumpForce; 
        jump = false;
    }

    private bool isGrounded()
    {
        RaycastHit2D ground = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0, Vector2.down, 0.1f, layerGround);

        return ground.collider != null;
    }

}
