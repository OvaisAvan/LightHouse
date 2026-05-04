using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour
{
    public GameObject FirePoint;
    public Camera Cam;
    public float MaxLength;
    public GameObject[] Prefabs;

    private Ray RayMouse;
    private Vector3 direction;
    private Quaternion rotation;


    private int Prefab;
    private GameObject Instance;
    private CustomLaser LaserScript;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("Laser Allowed");
                Destroy(Instance);
                Instance = Instantiate(Prefabs[Prefab], FirePoint.transform.position, FirePoint.transform.rotation);
                Instance.transform.parent = transform;
                LaserScript = Instance.GetComponent<CustomLaser>();
            }
            if (touch.phase == TouchPhase.Ended && LaserScript != null)
            {
                Debug.Log("Laser Closed");
                LaserScript.DisablePrepare();
                Destroy(Instance, 1);
            }
        }
    }
}
