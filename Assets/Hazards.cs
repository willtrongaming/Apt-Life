using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazards : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        FindObjectOfType<NewPlayer>().Death();
    }
}
