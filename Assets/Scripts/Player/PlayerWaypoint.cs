using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWaypoint : MonoBehaviour
{
    public GameObject wayPoint;
    private float timer = 0.5f;

    void Update ()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if(timer <= 0)
        {
            //The position of the waypoint will update to the player's position
            UpdatePosition();
            timer = 0.5f;
        }
    }

    void UpdatePosition()
    {
        //The wayPoint's position will now be the player's current position.
        wayPoint.transform.position = transform.position;
    }
}
