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
    public float placeWaitTime;

    public GameObject pinPreFab;
    public GameObject pinHolderClone;

    void Start()
    {
        DeployPins();
    }
    public void DeployPinsDelay()
    {

        Invoke(nameof(DeployPins), placeWaitTime);

    }
    public void DeployPins()
    {
        Destroy(pinHolderClone);
        pinHolderClone = Instantiate(pinPreFab, transform.position, transform.rotation)as GameObject;
        pinHolderClone.transform.SetParent(this.transform);
        StartCoroutine(MoveObject());
    }

    private IEnumerator MoveObject()
    {
        // Move from A to B
        reachBottom = false;
        yield return StartCoroutine(MoveBetweenPoints(top, bottom));

        // Wait for 1 second
        yield return new WaitForSeconds(waitTime);
        pinHolderClone.transform.SetParent(null);

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
