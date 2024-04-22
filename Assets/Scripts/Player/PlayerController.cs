using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Player Movement")]
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float jumpForce = 7;
    [SerializeField] private LayerMask layerGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {  

    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float direction = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);

    }

}
