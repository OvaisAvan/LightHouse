using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [SerializeField] private float _currentColorIntensity = 0;
    [SerializeField] private float _colorAddition = 5f;
    [SerializeField] private float _maxColorIntensity = 100f;
    private bool _isFillingCompleted;

    [SerializeField] private Material fillingMaterial;
    public delegate void onColorIntensityUpdate(float currentIntensity, float maxIntensity);
    public static event onColorIntensityUpdate OnColorIntensityUpdate;

    public delegate void onFillingCompleted(bool fillingCompleted);
    public static event onFillingCompleted OnFillingCompleted;
    private void OnEnable()
    {
        CustomLaser.OnCollisionWithObject += OnLaserCollisionWithObject;
    }
    private void Start()
    {
        fillingMaterial.SetFloat("_MeshHeight", 1);
    }
    private void OnLaserCollisionWithObject()
    {
        if (_isFillingCompleted)
            return;
        _currentColorIntensity -= _colorAddition;
        fillingMaterial.SetFloat("_MeshHeight", _currentColorIntensity);
        if( _currentColorIntensity < _maxColorIntensity)
        {
            _currentColorIntensity = _maxColorIntensity;
            _isFillingCompleted = true;
            OnFillingCompleted?.Invoke(true);
        }
        OnColorIntensityUpdate?.Invoke(_currentColorIntensity, _maxColorIntensity);
    }
    private void OnDisable()
    {
        CustomLaser.OnCollisionWithObject -= OnLaserCollisionWithObject;
    }
}
