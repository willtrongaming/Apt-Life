using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftStructure : MonoBehaviour
{
    [SerializeField] float liftStructureXTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        liftStructureXTransform = transform.position.x;
    }
}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftMovement : MonoBehaviour
{
    // Config. Parameters
    [SerializeField] float liftTime = 3f;
    LiftStructure liftStructure;
    float relativeXDistance;
    float liftXTransform = transform.position.x;

    private void Awake()
    {
        liftStructure = FindObjectOfType<LiftStructure>().transform.position.x;
        relativeXDistance = liftStructure - liftXTransform;
        [SerializeField] Vector2 pointA = new Vector2(relativeXDistance, -6.48f);
        [SerializeField] Vector2 pointB = new Vector2(relativeXDistance, 0f);
    }

    IEnumerator Start()
    {
        while (true)
        {
            yield return StartCoroutine(MoveObject(transform, pointA, pointB, liftTime));
            yield return StartCoroutine(MoveObject(transform, pointB, pointA, liftTime));
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
    } */
