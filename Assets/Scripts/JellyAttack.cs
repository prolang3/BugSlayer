using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JellyAttack : Weapon
{
    private HealthComponent healthComponent;

    public override void Start()
    {
        base.Start();
        healthComponent = GetComponent<HealthComponent>();
    }

    public override bool Use(Vector3 globalMousePosition)
    {
        healthComponent.MaxHealth -= 1;
        return base.Use(globalMousePosition);
    }
}
