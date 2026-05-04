using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugButtons : MonoBehaviour
{
    [SerializeField] private CameraData _cameraData;

    [SerializeField] private Text debugText;

    private void Start()
    {
        UpdateDebugText();
    }
    private void UpdateDebugText()
    {
        debugText.text = _cameraData.rotationSpeed.ToString();
    }

    public void UpdateCameraSpeed(float SpeedUpValue)
    {
        _cameraData.rotationSpeed += SpeedUpValue;
        _cameraData.rotationSpeed = Mathf.Clamp(_cameraData.rotationSpeed, 5, 500);
        UpdateDebugText();
    }
}
