using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Takip edilecek hedef (gezegen)
    public float distance = 5f; // Kameranın gezegenin yüzeyinden uzaklığı

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
            // Kameranın konumunu belirli bir mesafede ayarla
            transform.position = target.position - target.forward * distance;

            // Kamerayı gezegenin konumuna bakacak şekilde döndür
            transform.LookAt(target);
    }

    void Update()
    {
        // Kameranın uzaklığını güncelle
        float newDistance = CalculateDistanceFromSlider();
        SetCameraDistance(newDistance);


    }

    private float CalculateSliderValue()//Sliderın min ve max değerini atar
    {
        return Mathf.InverseLerp(minDistance, maxDistance, target.position.magnitude);
    }

    float CalculateDistanceFromSlider()
    {
        // Slider'ın değerini kameranın uzaklığına çevir
        return Mathf.Lerp(minDistance, maxDistance, distanceSlider.value);
    }

    void SetCameraDistance(float newDistance)
    {
        // Kameranın uzaklığını ayarla
        Vector3 newPosition = -target.forward * newDistance;
        transform.position = target.position + newPosition;
    }

    public void SelectPlanet(int index)
    {
        if (index >= 0 && index < planetsToFollow.Length)
        {
            // Gezegeni seç ve kamerayı ona odakla
            target = planetsToFollow[index].transform;
            planetDropdown.value = index;
        }
    }
}
