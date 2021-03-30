using System.Collections;
using UnityEngine;

public class TankBarrel : MonoBehaviour
{
    public string fire;
    public int i;
    public GameObject []mermi;
    public float[] mermiDelay;
    public GUIStyle mystyle;
    bool isFired = false;
    bool ateskontrol = false;

    void Update()
    {
        ateskontrol = (Input.GetKeyDown(fire) || Input.GetKeyDown(KeyCode.Mouse0)) ? true : ateskontrol;
        ateskontrol = (Input.GetKeyUp(fire) || Input.GetKeyUp(KeyCode.Mouse0)) ? false : ateskontrol;
        if (!isFired && ateskontrol)
        {
            StartCoroutine(Fire(i, mermiDelay[i]));
        }
    }
    void InstantiateMermi(GameObject mermi)
    {
        if (ateskontrol)
        {
            Instantiate(mermi, transform.position, transform.rotation);
        }
    }

    IEnumerator Fire(int i ,float j)
    {
        InstantiateMermi(mermi[i]);
        isFired = true;
        yield return new WaitForSecondsRealtime(j);
        isFired = false;
    }
}
