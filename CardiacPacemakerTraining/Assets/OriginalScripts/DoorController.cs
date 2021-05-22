using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject Door;
    public bool doorOpen;
    

    void Update()
    {
        if (doorOpen == true)
        {
            Door.transform.Translate(Vector3.up * Time.deltaTime * 5);
        }
        if (Door.transform.position.y > 20f)
        {
            doorOpen = false;
        }
    }

    public void OnMouseDown()
    {
        doorOpen = true;
    }
}
