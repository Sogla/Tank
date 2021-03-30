using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 0f;
    public float MaxSpeed = 25f;
    public float moveAcceleration = 10f;
    public float Damage = 9f;
    public void Fire()
    {
        moveSpeed = (moveSpeed < MaxSpeed) ? moveSpeed + moveAcceleration : MaxSpeed;
        transform.Translate(0f, moveSpeed * Time.deltaTime, 0f);
    }
    
    public void Update()
    {
        Fire();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("otherp") || collision.gameObject.CompareTag("Mermi"))
        {
            Destroy(gameObject);
        }
    }
}
