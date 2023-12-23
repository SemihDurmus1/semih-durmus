using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public CameraFollow cameraFollow; // Kamerayý takip eden script
    public int planetIndex; // Bu butonun hangi gezegeni temsil ettiði

    void Start()
    {
        // Her butonun týklama olayýna OnButtonClick fonksiyonunu ekleyin
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    public void OnButtonClick()
    {
        planetIndex = cameraFollow.planetDropdown.value;
        cameraFollow.SelectPlanet(planetIndex);
    }

}
