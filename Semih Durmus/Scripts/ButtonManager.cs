using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public CameraFollow cameraFollow; // Kameray� takip eden script
    public int planetIndex; // Bu butonun hangi gezegeni temsil etti�i

    void Start()
    {
        // Her butonun t�klama olay�na OnButtonClick fonksiyonunu ekleyin
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    public void OnButtonClick()
    {
        planetIndex = cameraFollow.planetDropdown.value;
        cameraFollow.SelectPlanet(planetIndex);
    }

}
