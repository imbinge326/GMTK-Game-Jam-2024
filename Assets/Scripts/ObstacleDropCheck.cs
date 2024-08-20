using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDropCheck : MonoBehaviour
{
    public GameObject item1, item2, item3, item4, item5;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            item1.SetActive(true);
            item2.SetActive(true);
            item3.SetActive(true);
            item4.SetActive(true);
            item5.SetActive(true);
        }
    }
}
