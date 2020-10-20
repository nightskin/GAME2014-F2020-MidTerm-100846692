using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// all changes made by Shimron Khan October 20 2020
public class EnemyController : MonoBehaviour
{
    // changed names of HorizontalSpeed to just Speed and HorizontalBoundry to just Boundry
    float Speed = 2;
    public float Boundary;
    public float direction;

    void Update()
    { 
        _Move();
        _CheckBounds();
    }

    private void _Move()
    {
        // changed movement on x to movement on y
        transform.position += new Vector3(0, Speed * direction * Time.deltaTime, 0);
    }

    private void _CheckBounds()
    {
        // check top boundary
        if (transform.position.y >= Boundary)
        {
            direction = -1.0f;
        }

        // check bottom boundary
        if (transform.position.y <= -Boundary)
        {
            direction = 1.0f;
        }
    }
}
