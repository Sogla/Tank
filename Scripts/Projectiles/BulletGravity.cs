using System.Collections;
using UnityEngine;

public class BulletGravity : Bullet
{
    protected float rotateSpeed = 200f;

    GameObject []otherp;

    Rigidbody2D rg;
    Vector2 direction;

    void Start()
    {
        otherp = GameObject.FindGameObjectsWithTag("otherp");
        rg = GetComponent<Rigidbody2D>();
    }

    new void Update()
    {
        Fire();
        HomingFire();
    }
    public void HomingFire()
    {
        int i = 0;
        Vector2 smallestDir = otherp[0].transform.position - transform.position;
        while (i < otherp.Length)
        {
            direction = otherp[i].transform.position - transform.position;
            if (smallestDir.magnitude > direction.magnitude)
            {
                smallestDir = direction;
            }
            i++;
        }
        smallestDir.Normalize();
        float rotate_amount = Vector3.Cross(smallestDir, transform.up).z;
        rg.angularVelocity = -rotate_amount * rotateSpeed;
        rg.velocity = transform.up * moveSpeed * Time.deltaTime;
    }
}
