using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float thrust;
    
    private Rigidbody2D rigidBody2D;

    public float maximumSpeed = 5f;

    public void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        rigidBody2D.AddForce(transform.right * thrust);

        // Make sure MC does not exceed maximumSpeed
        if (rigidBody2D.velocity.magnitude > maximumSpeed)
        {
            rigidBody2D.velocity = rigidBody2D.velocity.normalized * maximumSpeed;
        }

        //Debug.Log(rigidBody2D.velocity.magnitude);
    }
}
