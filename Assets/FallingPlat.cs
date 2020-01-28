using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlat : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    bool isFalling = false;
    [SerializeField] float fallSpeed = -15f;
    [SerializeField] float firstDelay = 0.5f;
    [SerializeField] float firstShrink = 0.75f;
    [SerializeField] float secondDelay = 0.25f;
    [SerializeField] float destroyDelay = 5f;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    private IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "FallingPlat")
        {
            isFalling = true;
            yield return StartCoroutine(PlatFall());
            Destroy(gameObject, destroyDelay);
        }
    }

    private IEnumerator PlatFall()
    {
        if (isFalling)
        {
            yield return new WaitForSeconds(firstDelay);
            yield return StartCoroutine(PlatShrink());
        }
    }

    private IEnumerator PlatShrink()
    {
        myRigidbody.transform.localScale = new Vector2(firstShrink, 1f);
        yield return new WaitForSeconds(secondDelay);
        myRigidbody.velocity = new Vector2(0f, fallSpeed);
    }
}