using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondWaterTrigger : MonoBehaviour
{
    public GameObject popUpText2;
    Vector3 textPosition2;
    float destroyDelay = 3f;

    void Start()
    {
        textPosition2 = new Vector3(345.63f, 12.37f, -3f);
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    { 
        FindObjectOfType<RisingWater>().TurboTime();
        GameObject HurryUpText = Instantiate(popUpText2, textPosition2, Quaternion.identity) as GameObject;
    }
}



/* bool textTriggered = false;
 * public void OnTriggerEnter2D(Collider2D other)
    {
        if (textTriggered = false)
        {
            FindObjectOfType<RisingWater>().TurboTime();
            GameObject HurryUpText = Instantiate(popUpText2, textPosition2, Quaternion.identity) as GameObject;
            textTriggered = true;
            Destroy(HurryUpText, destroyDelay);
        }
    }

    /*public void OnTriggerExit2D(Collider2D other)
    {
        textTriggered = false;
    }*/

/*Destroy(HurryUpText, destroyDelay);*/
