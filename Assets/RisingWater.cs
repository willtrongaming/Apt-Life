using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingWater : MonoBehaviour
{
    float riseRate = 0.2f;
    float turboRiseRate = 2f;

    public void WaterMovement()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, riseRate);
    }

    public void TurboTime()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, turboRiseRate);
    }

    public void FullStopOfWaterMovement()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
    }
}



