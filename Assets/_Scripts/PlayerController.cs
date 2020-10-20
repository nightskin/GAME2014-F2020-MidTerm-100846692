using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;

// all changes made by Shimron Khan October 20 2020
public class PlayerController : MonoBehaviour
{
    public BulletManager bulletManager;

    [Header("Boundary Check")]
    public float Boundary; // changed name from HorizontalBoundry

    [Header("Player Speed")]
    public float Speed; //changed name from HorizontalSpeed
    public float maxSpeed;
    public float VerticalTValue; //changed name from HorizontalTValue

    [Header("Bullet Firing")]
    public float fireDelay;

    // Private variables
    private Rigidbody2D m_rigidBody;
    private Vector3 m_touchesEnded;

    // Start is called before the first frame update
    void Start()
    {
        m_touchesEnded = new Vector3();
        m_rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
        _FireBullet();
    }

    private void _FireBullet()
    {
        // delay bullet firing 
        if(Time.frameCount % 60 == 0 && bulletManager.HasBullets())
        {
            bulletManager.GetBullet(transform.position);
        }
    }

    private void _Move()
    {
        float direction = 0.0f;

        // touch input support
        foreach (var touch in Input.touches)
        {
            var worldTouch = Camera.main.ScreenToWorldPoint(touch.position);
            //compares y touch to y position instead of x touch to x position
            if (worldTouch.y > transform.position.y)
            {
                // direction is positive
                direction = 1.0f;
            }
            //compares y touch to y position instead of x touch to x position
            if (worldTouch.y < transform.position.y)
            {
                // direction is negative
                direction = -1.0f;
            }

            m_touchesEnded = worldTouch;

        }

        // keyboard support
        // changed axis to Vertical
        if (Input.GetAxis("Vertical") >= 0.1f) 
        {
            // direction is positive
            direction = 1.0f;
        }
        // changed axis to Vertical
        if (Input.GetAxis("Vertical") <= -0.1f)
        {
            // direction is negative
            direction = -1.0f;
        }
        // chekcing y instead of x
        if (m_touchesEnded.y != 0.0f)
        {
            // modifying the Vector3 to move in y instead of x
            transform.position = new Vector2(transform.position.x, Mathf.Lerp(transform.position.y, m_touchesEnded.y, VerticalTValue));
        }
        else
        {
            Vector2 newVelocity = m_rigidBody.velocity + new Vector2(0.0f, direction * Speed); //setting x to 0 and moving on y instead
            m_rigidBody.velocity = Vector2.ClampMagnitude(newVelocity, maxSpeed);
            m_rigidBody.velocity *= 0.99f;
        }
    }

    private void _CheckBounds()
    {
        // check top bounds instead of right bounds and setting appropiate position
        if (transform.position.y >= Boundary)
        {
            transform.position = new Vector3(transform.position.x, Boundary, 0.0f);
        }

        // check bottom bounds instead of left bounds and setting appropiate position
        if (transform.position.y <= -Boundary)
        {
            transform.position = new Vector3(transform.position.x, -Boundary, 0.0f);
        }

    }
}
