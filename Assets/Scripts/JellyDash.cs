using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyDash : MonoBehaviour
{
    public float maxDashDistance = 5f;
    public float dashSpeed = 20f;
    public float dashCooldown = 2f;
    public float bounceDistance = 3f;

    public LayerMask Platform;
    private Rigidbody2D rb;
    private bool isDashing = false;
    private bool isBouncing = false;
    private bool canDash = true;
    private float dashCooldownTimer = 0f;
    private Vector2 dashDirection;
    private float dashDistance;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!canDash)
        {
            dashCooldownTimer -= Time.deltaTime;
            if (dashCooldownTimer <= 0f)
            {
                Debug.Log("Dash Cooldown ended");
                canDash = true;
            }
        }

        if (isDashing || isBouncing)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && canDash)
        {
            DashTowardsMouse();
        }
    }

    void FixedUpdate()
    {
        if (isDashing)
        {
            DashMove();
        }
    }

    void DashTowardsMouse()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dashStart = rb.position;

        dashDirection = (mousePosition - dashStart).normalized;

        RaycastHit2D hit = Physics2D.Raycast(dashStart, dashDirection, maxDashDistance, Platform);

        Debug.DrawRay(dashStart, dashDirection * maxDashDistance, Color.yellow, 1f);

        if (hit.collider != null)
        {
            dashDistance = hit.distance-0.1f;
        }
        else
        {
            dashDistance = maxDashDistance;
        }

        isDashing = true;
        canDash = false;
        dashCooldownTimer = dashCooldown;
        Debug.Log("Dash Started");
    }

    void DashMove()
    {
        float moveDistance = dashSpeed * Time.fixedDeltaTime;

        RaycastHit2D hit = Physics2D.Raycast(rb.position, dashDirection, moveDistance + 0.2f, Platform);

        Debug.DrawRay(rb.position, dashDirection * moveDistance, Color.red, 0.1f);
        Vector2 currentVelocity = rb.velocity;
        currentVelocity.y = 0f;
        rb.velocity = currentVelocity;

        if (hit.collider != null)
        {
            Reflect();
        }
        else
        {
            Vector2 newPosition = rb.position + dashDirection * Mathf.Min(moveDistance, dashDistance);
            rb.MovePosition(newPosition);

            dashDistance -= moveDistance;
            if (dashDistance <= 0f)
            {
                isDashing = false;
                Debug.Log("Dash Ended");
            }
        }
    }

    private void Reflect()
    {
        RaycastHit2D hit = Physics2D.Raycast(rb.position, dashDirection, dashSpeed * Time.fixedDeltaTime + 0.2f, Platform);

        Debug.DrawRay(rb.position, dashDirection * (dashSpeed * Time.fixedDeltaTime + 0.2f), Color.blue, 0.1f);

        if (hit.collider != null)
        {
            Vector2 normal = hit.normal;
            Vector2 reflectDirection = Vector2.Reflect(dashDirection, normal);

            float bounceSpeed = dashSpeed * 0.8f;

            StartCoroutine(Bounce(reflectDirection, bounceDistance, bounceSpeed));

            isDashing = false;
            Debug.Log("Platform hit!");
        }
    }

    private IEnumerator Bounce(Vector2 reflectDirection, float bounceDistance, float bounceSpeed)
    {
        float duration = bounceDistance / bounceSpeed;
        float elapsedTime = 0f;

        Vector2 initialPosition = rb.position;

        while (elapsedTime < duration)
        {
            rb.MovePosition(Vector2.Lerp(initialPosition, initialPosition + reflectDirection * bounceDistance, elapsedTime / duration));
            elapsedTime += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        rb.MovePosition(initialPosition + reflectDirection * bounceDistance);
        isBouncing = false;
        Debug.Log("Bounce Complete");
    }
}