using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Cooldowns")]
    [SerializeField] private float switchCooldown;
    [SerializeField] private float reloadCooldown;

    [Header("Shot Counter")]
    [SerializeField] private int enlargeCount = 0;
    [SerializeField] private int shrinkCount = 0;

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
    private Transform CheckHitObject(RaycastHit2D hit)
    {
        if (hit.collider != null)
        {
            // Check if the object hit has a specific tag
            if (hit.collider.CompareTag("Item"))
            {
                Transform hitTransform = hit.collider.transform;
                return hitTransform;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }

    public void EnlargeShoot()
    {
        Transform hitTransform = CheckHitObject(hit);
        if (hitTransform != null && enlargeCount < 3)
        {
            hitTransform.localScale *= 1.1f;
            enlargeCount++;
            shrinkCount--;

            if (enlargeCount > 3)
            {
                enlargeCount = 3;
            }
        }
    }

        public void ShrinkShoot()
    {
        Transform hitTransform = CheckHitObject(hit);
        if (hitTransform != null && shrinkCount < 3)
        {
            hitTransform.localScale *= 0.9f;
            shrinkCount++;
            enlargeCount--;

            if (shrinkCount > 3)
            {
                shrinkCount = 3;
            }
        }
    }


}
