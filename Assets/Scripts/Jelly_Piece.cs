using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;

public class Jelly_Piece : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D jel;
    void Start()
    {
        jel = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        jel.velocity = new Vector2(0, jel.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            Destroy(gameObject);
        }
    }
}
