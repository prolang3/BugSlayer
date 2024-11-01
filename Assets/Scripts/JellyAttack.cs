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

    public override void Use()
    {
        healthComponent.MaxHealth -= 1;
        base.Use();
    }
}
