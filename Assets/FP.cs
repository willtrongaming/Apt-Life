using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FP : MonoBehaviour
{
    bool isFalling = false;
    float fallSpeed = -15f;
    float firstDelay = 0.5f;
    float firstShrink = 0.75f;
    float secondDelay = .25f;
    float destroyDelay = .5f;

    public void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(FPTriggered());
    }
    
    public IEnumerator FPTriggered()
    {
        if (tag == "FallingPlat")
        {
            isFalling = true;
            yield return StartCoroutine(PlatFall());
            Destroy(gameObject, destroyDelay);
        }
    }

    public IEnumerator PlatFall()
    {
        if (isFalling)
        {
            yield return new WaitForSeconds(firstDelay);
            yield return StartCoroutine(PlatShrink());
        }
    }

    public IEnumerator PlatShrink()
    {
        transform.localScale = new Vector2(firstShrink, 1f);
        yield return new WaitForSeconds(secondDelay);
    }
}



/*float destroyDelay = 5f;*/

/*public IEnumerator PlatShrink()
    {
        myRigidbody.transform.localScale = new Vector2(firstShrink, 1f);
        yield return new WaitForSeconds(secondDelay);
        myRigidbody.velocity = new Vector2(0f, fallSpeed);
    }*/




// Did not work - the FP's (even when tagged as FallingPlatform) do not fall at all regardless of the conditions 
// need to come up with a new structure
/*void Update()
{
    elapsed = Time.timeSinceLevelLoad;
}
public void OnTriggerEnter2D(Collider2D other)
{
    if (elapsed == 1f)
    {
        StartCoroutine(FPTriggered());
    }
}*/

/* relic: public void FPIsTriggered()*/
