using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Cooldowns")]
    [SerializeField] private float switchCooldown;
    [SerializeField] private float reloadCooldown;

    private RaycastHit2D hit;

    private Camera mainCamera;
   
    void Awake()
    {
        mainCamera = Camera.main;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        hit = Physics2D.Raycast(worldPosition, Vector2.zero);

        transform.position = worldPosition;
    }

    public void EnlargeShoot()
    {
        //Debug.Log(hit);
         if (hit.collider != null)
        {
            // Check if the object hit has a specific tag
            if (hit.collider.CompareTag("Item"))
            {
                //Debug.Log("Hit an object with the tag: " + hit.collider.tag);
                Transform hitTransform = hit.collider.transform;
                hitTransform.localScale *= 1.1f;
            }
            else
            {
                //Debug.Log("Hit an object with a different tag: " + hit.collider.tag);
            }
        }
        else
        {
            //Debug.Log("Nothing hit");
        }
    }

    public void ShrinkShoot()
    {
        Debug.Log("Les");
    }


}
