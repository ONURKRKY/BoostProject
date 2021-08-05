using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]float mainThrust = 100f;
    [SerializeField]float rotationThrust = 100f;
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
    if(Input.GetKey(KeyCode.Space))
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime) ;
    }
    }
     void ProcessRotation()
    {
    if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
        }
        else if(Input.GetKey(KeyCode.D))
    {
       ApplyRotation(-rotationThrust);
    }
    }

    private void ApplyRotation(float RotationThisFrame)
    {
        rb.freezeRotation= true;
        transform.Rotate(Vector3.forward * RotationThisFrame * Time.deltaTime);
        rb.freezeRotation=false;
    }
}