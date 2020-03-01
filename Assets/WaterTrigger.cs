using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrigger : MonoBehaviour
{
    public GameObject popUpText;
    Vector3 textPosition;

    void Start()
    {
        textPosition = new Vector3(338.88f, -3.318f, -3f);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        FindObjectOfType<RisingWater>().WaterMovement();
        GameObject OhNoText = Instantiate(popUpText, textPosition, Quaternion.identity) as GameObject;
    }
}
