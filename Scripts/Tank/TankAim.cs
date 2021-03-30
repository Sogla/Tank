using UnityEngine;

public class TankAim : MonoBehaviour
{
    float hiz = 5f;

    void Start()
    {

    }
    
    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.back);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, hiz * Time.deltaTime);

    }
}
