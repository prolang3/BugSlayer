using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public GameObject Bullet;
    public float UseDelay;
    public float Damage;

    private float cooldown;

    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (cooldown < UseDelay)
        {
            cooldown += Time.deltaTime;
        }

        if (Input.GetMouseButton(0) && cooldown >= UseDelay)
        {
            Use();
            cooldown = 0;
        }
    }

    public virtual void Use()
    {
        
        if (Bullet != null)
        {
            var globalMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            globalMousePosition.z = 0;
            var diff = globalMousePosition - transform.position;
            diff.Normalize();

            var rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg - 90; // -90 because we use transform.up
            var rot = quaternion.Euler(0, 0, rotZ);

            var newBullet = Instantiate<GameObject>(Bullet);
            newBullet.transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 0, rotZ));
        }
        
        /*
        var enemys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemys)
        {
            var health = enemy.GetComponent<HealthComponent>();
            var direction = enemy.transform.position - transform.position;
            var dotProduct = Vector2.Dot(transform.right, direction.normalized); //내적 :jelly:
            if (dotProduct > 0.2f && direction.magnitude < 1.5f && health)
            {
                health.Health -= Damage;
                Debug.Log("YOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO");
            }
        }
        */
    }
}
