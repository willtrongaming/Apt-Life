using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaultyPlatMovement2 : MonoBehaviour
{
    public void MoveTheFaultyPlat2()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(2.0f, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.collider.transform.SetParent(null);
        }
    }
}
