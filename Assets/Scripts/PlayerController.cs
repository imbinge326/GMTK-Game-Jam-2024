using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Cooldowns")]
    [SerializeField] private float switchCooldown;
    [SerializeField] private float shotCooldown;
    [SerializeField] private float reloadCooldown;
    [SerializeField] private bool canShoot = true; // Serialized for testing purposes

    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

        // Set the z position to 0 so it stays in the 2D plane
        worldPosition.z = 0;
        transform.position = worldPosition;
    }

    public void EnlargeShoot()
    {
        // Implement proper cooldown
        if(canShoot) 
        {
            Debug.Log("Gay");
        }
    }
}
