using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public float MaxMaxHealth = 10f;
    public float MaxHealth = 10f;
    public float Health = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        MaxHealth = MaxMaxHealth;
        Health = MaxHealth;   
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(MaxHealth);
    }
}
