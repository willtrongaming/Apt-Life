using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    Vector3 point;
    [SerializeField] float angle = 50;
    
    void Start()
    {
        point = transform.position;
    }

    void Update()
    {
        transform.RotateAround(point, Vector3.back, Time.deltaTime * angle);
    }
}
