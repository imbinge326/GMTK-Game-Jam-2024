using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Transform mainCharacter;
    public Transform checkpoint;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            mainCharacter.transform.SetPositionAndRotation(checkpoint.position, checkpoint.rotation);
        }
    }
}
