using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float thrust;
    private Rigidbody2D rigidBody2D;

    public void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        rigidBody2D.AddForce(transform.right * thrust);
    }
    
}
