using System.Collections;
using UnityEngine;

public class BulletLaser : Bullet
{
    void Start()
    {
        StartCoroutine(Destroy());
    }


    IEnumerator Destroy()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Destroy());
    }
}
