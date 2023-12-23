using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
    }
}
