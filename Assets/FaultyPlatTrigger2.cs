using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaultyPlatTrigger2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        FindObjectOfType<FaultyPlatMovement2>().MoveTheFaultyPlat2();
    }
}
