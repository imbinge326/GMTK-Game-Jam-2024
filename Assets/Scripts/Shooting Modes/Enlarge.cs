using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enlarge : ShootingModes
{
    [Header("Settings")]
    [SerializeField] private float enlargeSize;

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
        }
    }

    protected override void GetInput()
    {
        shoot = leftMouseClick;
    }

}
