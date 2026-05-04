using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraControl
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private CameraData _cameraData;
        private GameObject target;
        private void Awake()
        {
            InitializeTarget();
        }
        private void FixedUpdate()
        {
            if (target == null) { return; }
            RotateCamera();
        }
        private void InitializeTarget()
        {
            target = GameObject.FindGameObjectWithTag(_cameraData.targetTag);
        }
        private void RotateCamera()
        {
            // get the current position of the object
            Vector3 currentPosition = transform.position;

            // calculate the target position of the object
            Vector3 targetPosition = target.transform.position + (transform.position - target.transform.position).normalized * _cameraData.targetDistance;

            // move the object towards the target position
            transform.position = Vector3.MoveTowards(currentPosition, targetPosition, Time.deltaTime * _cameraData.rotationSpeed);

            // rotate the object around the center object
            transform.RotateAround(target.transform.position, Vector3.up, Time.deltaTime * _cameraData.rotationSpeed);

            transform.LookAt(target.transform.position);
        }

    }
}
