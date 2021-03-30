using System.Collections;
using UnityEngine;

public class BulletEdge : Bullet
{
    bool isFired = false;  //Yön Bulma her mermi için bir kez gerçekleşsin diye.
    protected float hiz = 5f;     //Merminin yön bulma hızı
    float temp;     //Durduktan sonraki tekrar max hızlanması
    GameObject[] otherp;    //Sahadaki diğer düşmanlar

    void Start()
    {
        temp = MaxSpeed * 3;
        otherp = GameObject.FindGameObjectsWithTag("otherp");
    }

    new void Update()
    {
        Fire();
        if (Input.GetKey(KeyCode.Mouse1) && !isFired)
        {
            MaxSpeed = 0f;
            StartCoroutine(MaxTargeting(1f));
            int i = 0;
            Vector2 smallestDir = otherp[0].transform.position - transform.position;
            while (i < otherp.Length)
            {
                Vector2 direction = otherp[i].transform.position - transform.position;
                if (smallestDir.magnitude > direction.magnitude)
                {
                    smallestDir = direction;
                }
                i++;
            }
            float angle = Mathf.Atan2(smallestDir.x, smallestDir.y) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.back);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, hiz * Time.deltaTime);
        }
        else if(Input.GetKeyUp(KeyCode.Mouse1) && !isFired)
        {
            MaxSpeed = temp;
            isFired = true;
        }
    }

    IEnumerator MaxTargeting(float sure)  //Oyuncu uzun süre mermiyi salmaz ise otomatik ateşleme
    {
        yield return new WaitForSecondsRealtime(sure);
        isFired = true;
        MaxSpeed = temp;
    }
}
