using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class JellyScaleComponent : MonoBehaviour
{
    public float MinScale = 0.5f;
    private HealthComponent healthComponent;

    // Start is called before the first frame update
    void Start()
    {
        healthComponent = GetComponent<HealthComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        var scale = Mathf.Max(MinScale, (healthComponent.MaxMaxHealth - (healthComponent.MaxMaxHealth - healthComponent.MaxHealth)) * 0.1f);
        transform.localScale = Vector3.one * scale;
    }
}
