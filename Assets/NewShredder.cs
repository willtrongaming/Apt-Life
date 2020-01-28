using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewShredder : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FaultyPlat")
        {
            Destroy(collision.gameObject);
        }
    }
}
