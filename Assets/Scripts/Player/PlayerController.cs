using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private Animator animator;

    [Header("Player Movement")]
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float jumpForce = 7;
    [SerializeField] private LayerMask layerGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded()) { JumpPlayer(); }
    }

    private void FixedUpdate()
    {

    }

    private void MovePlayer()
    {
        float direction = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);

    }

    private void JumpPlayer() { rb.velocity = Vector2.up * jumpForce; }

    private bool isGrounded()
    {
        RaycastHit2D ground = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, layerGround);

        return ground.collider != null;
    }

}
