using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPinsPlacer : MonoBehaviour
{
    public Vector3 top;
    public Vector3 bottom;
    public bool reachBottom;

    public float moveDuration;
    public float waitTime;
    void Start()
    {
        StartCoroutine(MoveObject());
    }

    private IEnumerator MoveObject()
    {
        // Move from A to B
        yield return StartCoroutine(MoveBetweenPoints(top, bottom));
        reachBottom = true;

        // Wait for 1 second
        yield return new WaitForSeconds(waitTime);

        // Move back from B to A
        yield return StartCoroutine(MoveBetweenPoints(bottom, top));
    }

    private IEnumerator MoveBetweenPoints(Vector3 start, Vector3 end)
    {
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            // Interpolate the position linearly over time
            transform.position = Vector3.Lerp(start, end, elapsedTime / moveDuration);

            // Increment elapsed time
            elapsedTime += Time.deltaTime;

            // Wait until the next frame
            yield return null;
        }

        // Ensure the final position is set
        transform.position = end;
    }
}
