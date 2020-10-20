using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// all changes made by Shimron Khan October 20 2020
public class BulletController : MonoBehaviour, IApplyDamage
{
    // changesd names of VerticalSpeed and VerticalBoundry to Speed and boundry
    public float Speed;
    public float Boundary;
    public BulletManager bulletManager;
    public int damage;
    
    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
    }

    void Update()
    {
        _Move();
        _CheckBounds();
    }

    private void _Move()
    {
        // Set the new vector to move on x position instead of y
        transform.position += new Vector3(Speed, 0.0f, 0.0f) * Time.deltaTime;
    }

    private void _CheckBounds()
    {
        // checking for x instead of y
        if (transform.position.x > Boundary)
        {
            bulletManager.ReturnBullet(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.gameObject.name);
        bulletManager.ReturnBullet(gameObject);
    }

    public int ApplyDamage()
    {
        return damage;
    }
}
