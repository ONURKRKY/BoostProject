using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]float mainThrust = 110f;
    [SerializeField]float rotationThrust = 100f;
    [SerializeField]AudioClip mainEngine;
    [SerializeField]ParticleSystem mainEngineParticles;
    [SerializeField]ParticleSystem leftThrusterParticles;
     [SerializeField]ParticleSystem rightThrusterParticles;
    AudioSource audioSource;

   
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        audioSource=GetComponent<AudioSource>();
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
        if(!audioSource.isPlaying)
        {
        audioSource.PlayOneShot(mainEngine);
        }
        if(!mainEngineParticles.isPlaying)
        {
        mainEngineParticles.Play();
        }
    }else
    {
        audioSource.Stop();
        mainEngineParticles.Stop();

    }
    }
     void ProcessRotation()
    {
    if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
            if(!rightThrusterParticles.isPlaying)
        {
        rightThrusterParticles.Play();
        }

        }
        else if(Input.GetKey(KeyCode.D))
        {
       ApplyRotation(-rotationThrust);
       if(!leftThrusterParticles.isPlaying)
        {
        leftThrusterParticles.Play();
        }
        }
        else
        {
            rightThrusterParticles.Stop();
             leftThrusterParticles.Stop();
        }
    }

    private void ApplyRotation(float RotationThisFrame)
    {
        rb.freezeRotation= true;
        transform.Rotate(Vector3.forward * RotationThisFrame * Time.deltaTime);
        rb.freezeRotation=false;
    }
}
