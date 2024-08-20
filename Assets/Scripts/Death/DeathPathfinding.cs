using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPathfinding : MonoBehaviour
{
    private GameObject wayPoint;
    private Vector2 wayPointPos;
    [SerializeField] private float speed = 6.0f;

    void Start ()
    {
        wayPoint = GameObject.Find("Waypoint");
    }

    void Update ()
    {
        wayPointPos = new Vector2(wayPoint.transform.position.x, wayPoint.transform.position.y);

        //Here, the zombie's will follow the waypoint.
        transform.position = Vector2.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);
    }
}
