using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReachedFinishLine : MonoBehaviour
{    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Cursor.visible = true;
            SceneManager.LoadScene("Complete Tutorial");
        }
    }
}
