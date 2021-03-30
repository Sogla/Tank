using UnityEngine;

public class Tank : MonoBehaviour
{
    public TankAim tower;
    public TankBarrel namlu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            namlu.i = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            namlu.i = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            namlu.i = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            namlu.i = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            namlu.i = 4;
        }

    }
}
