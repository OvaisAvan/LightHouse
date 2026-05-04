using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField]float timeCounter = 0;

     [SerializeField] float speed;
    [SerializeField] float width;
    [SerializeField] float height;

    private void Start()
    {
        speed = 1;
        width = 10;
        height = 10;
    }
    //private void Update()
    //{
    //    transform.position]
    //}

}
