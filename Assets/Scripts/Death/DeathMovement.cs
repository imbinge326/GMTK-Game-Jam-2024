using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMovement : MonoBehaviour
{
    [SerializeField] private float thrust;
    [SerializeField] private float maximumSpeed;
    private Rigidbody2D rigidBody2D;
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
    }
}
