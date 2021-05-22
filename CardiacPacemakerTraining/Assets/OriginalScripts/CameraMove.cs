using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float rotateSpeed = 50.0f;                                  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.position += moveSpeed * v * Time.deltaTime * transform.forward;
        transform.rotation *= Quaternion.AngleAxis(rotateSpeed * h * Time.deltaTime, transform.up);
    }
}
