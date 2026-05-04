using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraData",menuName = "ShaderPractice/Create/CameraData")]
public class CameraData : ScriptableObject
{
    public Vector3 rotationAxis;
    public float rotationSpeed;
    public float targetDistance;
    public string targetTag = "Tower";
}
