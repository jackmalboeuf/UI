using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassUI : MonoBehaviour
{
    [SerializeField]
    float numberOfPixelsNorthToNorth;
    [SerializeField]
    Transform target;
    [SerializeField]
    Transform objectTarget;
    Vector3 startPosition;
    float rationAngleToPixel;
    Canvas canvas;

    void Start()
    {
        startPosition = transform.position;
        rationAngleToPixel = numberOfPixelsNorthToNorth / 360f;
        canvas = transform.parent.parent.GetComponent<Canvas>();
    }

    void Update()
    {
        //Vector3 perp = Vector3.Cross(Vector3.forward, target.forward);
        //float dir = Vector3.Dot(perp, Vector3.up);
        Vector3 perp = Vector3.Cross(target.forward, objectTarget.forward);
        float dir = Vector3.Dot(perp, Vector3.up);
        //transform.position = startPosition + (new Vector3(Vector3.Angle(target.forward, Vector3.forward) * Mathf.Sign(dir) * rationAngleToPixel * canvas.transform.lossyScale.x, 0, 0));
        transform.position = startPosition + (new Vector3(Vector3.Angle(target.forward, objectTarget.forward) * Mathf.Sign(dir) * rationAngleToPixel * canvas.transform.lossyScale.x, 0, 0));
    }
}
