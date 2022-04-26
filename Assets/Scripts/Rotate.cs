using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour { 
public GameObject objectToRotate;
private bool rotating;

private IEnumerator rotateObject(Vector3 angles, float duration)
{
    rotating = true;
    Quaternion startRotation = objectToRotate.transform.rotation;
    Quaternion endRotation = Quaternion.Euler(angles) * startRotation;
    for (float t = 0; t < duration; t += Time.deltaTime)
    {
        objectToRotate.transform.rotation = Quaternion.Lerp(startRotation, endRotation, t / duration);
        yield return null;
    }
    objectToRotate.transform.rotation = endRotation;
    rotating = false;
}

public void StartRotation()
{
    if (!rotating)
        StartCoroutine(rotateObject(new Vector3(0, 90, 0), 1));
}
}
