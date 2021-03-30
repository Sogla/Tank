using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosion : Bullet
{
    public Rigidbody2D rig;

    // Update is called once per frame
    new void Update()
    {
        Fire();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("otherp") || collision.gameObject.CompareTag("Mermi"))
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            rig.bodyType = RigidbodyType2D.Static;
            Destroy(gameObject, 0.5f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hello");
    }
}
