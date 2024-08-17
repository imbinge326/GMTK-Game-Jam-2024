using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enlarge : ShootingModes
{
    [Header("Settings")]
    [SerializeField] private float enlargeSize;
    [SerializeField] private bool canShoot;
    [SerializeField] private float shotCooldown;

    private bool shoot;

    protected override void InitState()
    {
        base.InitState();
    }
    
    public override void ExecuteMode()
    {
        EnlargeObject();
    }

    private void EnlargeObject()
    {
        if (shoot)
        {
            playerController.EnlargeShoot();
            canShoot = false;
            StartCoroutine(StartCooldown());
        }
    }

    protected override void GetInput()
    {
        shoot = leftMouseClick;
    }
    IEnumerator StartCooldown()
    {
        //cooldown between each shot
        yield return new WaitForSeconds(shotCooldown);
        canShoot = true;
    }

}
