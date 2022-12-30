using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GrayScale : MonoBehaviour
{
    private readonly string message = "ColorAdjustments not found";
    private readonly float saturationValue = -90f;
    private UnityEngine.Rendering.Universal.ColorAdjustments colorAdjustments;
    Volume volume;

    private void Start()
    {
        volume = GetComponent<Volume>();
        ColorAdjustments temp;
        if (volume.profile.TryGet<UnityEngine.Rendering.Universal.ColorAdjustments>(out temp))
        {
            colorAdjustments = temp;
            colorAdjustments.active = true;
        }

        else
            print(message);
        EventBus.eObstacleCollision.AddListener(SaturationOn);
        EventBus.eFalling.AddListener(SaturationOn);
        SetSaturation(false);
    }

    private void SetSaturation(bool on)
    {
        if (on)
            colorAdjustments.saturation.value = saturationValue;
        if(!on)
            colorAdjustments.saturation.value = 0;
    }
    private void SaturationOn() => SetSaturation(true);
    
}
