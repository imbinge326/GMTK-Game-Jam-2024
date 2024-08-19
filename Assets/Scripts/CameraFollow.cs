using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float FollowSpeed = 2f;
    [SerializeField]  private float yOffset = 2f;
    [SerializeField]  private float xOffset = 4f;
    [SerializeField]  private Transform target;
    [SerializeField] private float delay = 1.5f;

    public bool canFollow = false;

    void Start()
    {
        StartCoroutine(StartFollowingAfterDelay());
    }
    void Update()
    {
        if (canFollow)
        {
            Vector3 newPos = new Vector3(target.position.x + xOffset, target.position.y + yOffset, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
        }
    }

    IEnumerator StartFollowingAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        canFollow = true;
    }
}
