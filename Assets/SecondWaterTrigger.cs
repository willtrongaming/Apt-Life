using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondWaterTrigger : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        FindObjectOfType<RisingWater>().TurboTime();
    }
}
