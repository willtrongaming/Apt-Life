using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeTheLightText : MonoBehaviour
{
    public GameObject popUpText;
    Vector3 textPosition3;

    void Start()
    {
        textPosition3 = new Vector3(-60f, -15.6f, -3f);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        GameObject SeeTheLightPrefab = Instantiate(popUpText, textPosition3, Quaternion.identity) as GameObject;
    }
}
