using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{

    public Transform sun;
    [SerializeField]float speed = 1f;

    public Vector3 axis;

    [SerializeField] float rotationSpeed = 1f;

    private void Start()
    {
        //Rastgele y�r�nge atamas� i�in
        axis = new Vector3(0, Random.Range(0f,1f), Random.Range(0f, 1f));
    }


    private void FixedUpdate()//Update kullan�nca m�thi� patl�yor, kamera scriptinden dolay�.
    {
        transform.RotateAround(sun.position, axis, speed * Time.deltaTime);

        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
