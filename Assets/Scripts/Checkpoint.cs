using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Transform mainCharacter;
    public Transform checkpoint;
    public Transform ghost;
    private Vector3 ghostPos = new Vector3(8, 0, 0);

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            mainCharacter.transform.SetPositionAndRotation(checkpoint.position, checkpoint.rotation);
            ghost.transform.SetPositionAndRotation(checkpoint.position - ghostPos, checkpoint.rotation);
        }
    }
}
