using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    SoundManager soundManager;

    [SerializeField] private float thrust; //need experiment to find the optimal value
    [SerializeField] private float jumpHeight; //need experiment to find the optimal value
    [SerializeField] private Transform groundChecker;
    [SerializeField] private float checkRadius; //need experiment to find the optimal value
    [SerializeField] private LayerMask groundTerrain;
    [SerializeField] private bool hasJumped = false; // Flag to track if sound has been emitted

    private Rigidbody2D rigidBody2D;
    private bool isOnGround;
    public float maximumSpeed = 5f;

    public void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        soundManager = GameObject.Find("Sound Emitter").GetComponent<SoundManager>();
    }


    public void FixedUpdate()
    {
        rigidBody2D.AddForce(transform.right * thrust);

        // Make sure MC does not exceed maximumSpeed
        if (rigidBody2D.velocity.magnitude > maximumSpeed)
        {
            rigidBody2D.velocity = rigidBody2D.velocity.normalized * maximumSpeed;
        }
    }


    private void Update()
    {
        isOnGround = Physics2D.OverlapCircle(groundChecker.position, checkRadius, groundTerrain);

        float jump = Input.GetAxis("Jump");
        if (jump == 1 && isOnGround)
        {
            if (!hasJumped)
            {
                rigidBody2D.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
                soundManager.EmitSound(2, transform); // 2 is the order in the list for jump sound
                hasJumped = true; // Set flag to true to prevent multiple emissions
            }
        }
        else
        {
            // Reset the flag when not on ground so sound can be emitted again
            hasJumped = false;
        }
    }

    //May be useful
    /*
    private void SetRayOrigins()
    {
        Bounds playerBounds = boxCollider2D.bounds;
        
        boundBottomLeft = new Vector2(playerBounds.min.x, playerBounds.min.y);
        boundBottomRight = new Vector2(playerBounds.max.x, playerBounds.min.y);
        boundTopLeft = new Vector2(playerBounds.min.x, playerBounds.max.y);
        boundTopRight = new Vector2(playerBounds.max.x, playerBounds.max.y);

        boundHeight = Vector2.Distance(boundBottomLeft, boundTopLeft);
        boundWidth = Vector2.Distance(boundBottomLeft, boundBottomRight);
    }
    */
}