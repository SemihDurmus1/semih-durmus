using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Takip edilecek hedef (gezegen)
    public float distance = 5f; // Kameran�n gezegenin y�zeyinden uzakl���

    [SerializeField] GameObject[] planetsToFollow;

    public readonly float minDistance = 100f;
    public readonly float maxDistance = 3000f;

    //UI ELEMENTS

    public Slider distanceSlider;
    public Dropdown planetDropdown;

    private void Start()
    {
        distanceSlider.value = CalculateSliderValue();
    }

    void FixedUpdate()
    {
            // Kameran�n konumunu belirli bir mesafede ayarla
            transform.position = target.position - target.forward * distance;

            // Kameray� gezegenin konumuna bakacak �ekilde d�nd�r
            transform.LookAt(target);
    }

    void Update()
    {
        // Kameran�n uzakl���n� g�ncelle
        float newDistance = CalculateDistanceFromSlider();
        SetCameraDistance(newDistance);


    }

    private float CalculateSliderValue()//Slider�n min ve max de�erini atar
    {
        return Mathf.InverseLerp(minDistance, maxDistance, target.position.magnitude);
    }

    float CalculateDistanceFromSlider()
    {
        // Slider'�n de�erini kameran�n uzakl���na �evir
        return Mathf.Lerp(minDistance, maxDistance, distanceSlider.value);
    }

    void SetCameraDistance(float newDistance)
    {
        // Kameran�n uzakl���n� ayarla
        Vector3 newPosition = -target.forward * newDistance;
        transform.position = target.position + newPosition;
    }

    public void SelectPlanet(int index)
    {
        if (index >= 0 && index < planetsToFollow.Length)
        {
            // Gezegeni se� ve kameray� ona odakla
            target = planetsToFollow[index].transform;
            planetDropdown.value = index;
        }
    }
}
