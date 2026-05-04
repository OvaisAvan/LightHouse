using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarController : MonoBehaviour
{
    [SerializeField] private Image _colorIntensityBar;
    private void OnEnable()
    {
        TowerManager.OnColorIntensityUpdate += OnColorIntensityUpdateEvent;
    }
    private void OnColorIntensityUpdateEvent(float colorIntensity, float maxColorIntensity)
    {
        _colorIntensityBar.fillAmount = colorIntensity/maxColorIntensity;
    }
    private void OnDisable()
    {
        TowerManager.OnColorIntensityUpdate -= OnColorIntensityUpdateEvent;
    }
}
