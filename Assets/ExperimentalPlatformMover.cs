using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperimentalPlatformMover : MonoBehaviour
{
    // Config. Parameters
    float xPositionA;
    float xPositionB;
    float yPositionA;
    float yPositionB;
    Vector2 pointA;
    Vector2 pointB;
    [SerializeField] float endToEndTime = 1.5f;
    /*public Transform[] transforms;*/
    public GameObject pointAObj;
    public GameObject pointBObj;

    public void Awake()
    {
        pointA = new Vector2(pointAObj.transform.position.x, pointAObj.transform.position.y);
        pointB = new Vector2(pointBObj.transform.position.x, pointBObj.transform.position.y);
    }

    IEnumerator Start()
    {
        while(true)
        {
            yield return StartCoroutine(MoveObject(transform, pointA, pointB, endToEndTime));
            yield return StartCoroutine(MoveObject(transform, pointB, pointA, endToEndTime));
        }
    }

    IEnumerator MoveObject(Transform thisTransform, Vector2 startPos, Vector2 endPos, float time)
    {
        var i = 0.0f;
        var rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector2.Lerp(startPos, endPos, i);
            yield return null;
        }
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

