using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Jobs.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class Launch_jelly : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject jelly;
    public GameObject Target;
    private HealthComponent healthComponent;
    
    public float cooldown;
    private float passing_time = 0f;
    private bool isFacingLeft = false;
    private float Spawning_Jelly_Pos_x;
    

    void Start()
    {
        healthComponent = GetComponent<HealthComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (passing_time > cooldown) {
            passing_time = cooldown;
        } else {
            passing_time += Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A)) {
            isFacingLeft = true;
        }

        if (Input.GetKey(KeyCode.D)) {
            isFacingLeft = false;
        }

        if (Input.GetMouseButton(0) && (passing_time >= cooldown)) {
            var Laun_Jel = Instantiate<GameObject>(jelly);
            if (isFacingLeft) {
                Spawning_Jelly_Pos_x = Target.transform.position.x + 1f;
            }
            else {
                Spawning_Jelly_Pos_x = Target.transform.position.x - 1f;
            }
            Laun_Jel.transform.position = new Vector2(Spawning_Jelly_Pos_x, Target.transform.position.y);
            passing_time = 0;
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Jelly_Piece")) {
            healthComponent.MaxHealth += 1;
            //젤리 먹으면 피 회복
        }
    }
}
