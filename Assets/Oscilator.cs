using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscilator : MonoBehaviour
{
    Vector3 startinPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float Period = 2f;



    void Start()
    {
        startinPosition = transform.position;

    }


    void Update()

    {
        if(Period<=Mathf.Epsilon){return;}  // 0 bölme hatası
        float cycles = Time.time / Period;      // kaç döngü var
        const float tau = Mathf.PI * 2;    //2pi değeri sabit
        float rawSinWave = Mathf.Sin(cycles * tau);
        movementFactor = (rawSinWave + 1f) / 2f;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startinPosition + offset;
    }
}
