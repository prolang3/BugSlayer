using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public string CreatorTag;
    public float Speed = 3;
    public float Damage = 1;
    private Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = transform.up * Speed;
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.gameObject.CompareTag(CreatorTag) && !collider.gameObject.CompareTag("Projectile"))
        {
            var health = collider.gameObject.GetComponent<HealthComponent>();
            if (health)
            {
                health.Health -= Damage;
            }
            Destroy(gameObject);
        }
    }
}
