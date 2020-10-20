using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// all changes made by Shimron Khan October 20 2020
public class BackgroundController : MonoBehaviour
{
    // name changes of HorizontalSpeed and HorizontalBoundry
    float Speed = 3; //made speed private and set to 3 
    public float Boundary; 

    void Update()
    {
        _Move();
        _CheckBounds();
    }

    private void _Reset()
    {
        transform.position = new Vector3(Boundary, 0.0f); //swapped values of vector x and y
    }

    private void _Move()
    {
        // switched swapped x and y position of new nector 
        transform.position -= new Vector3(Speed, 0.0f) * Time.deltaTime;
    }

    private void _CheckBounds()
    {
        // if the background at other side of screen then reset
        if (transform.position.x <= -Boundary) // changed the y to x
        {
            _Reset();
        }
    }
}
