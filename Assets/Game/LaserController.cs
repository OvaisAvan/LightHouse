using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LaserController : MonoBehaviour
{
    [SerializeField] private GameObject laserObject;

    [SerializeField] private float laserGrowSpeed = 0.2f;

    private void OnEnable()
    {
        ScreenTouch.OnScreenTouch += ShootLaser;
    }
    private void ShootLaser(bool status)
    {
        laserObject.SetActive(status);
    }
    private void OnDisable()
    {
        ScreenTouch.OnScreenTouch -= ShootLaser;
    }
}
