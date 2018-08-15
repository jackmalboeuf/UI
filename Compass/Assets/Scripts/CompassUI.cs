using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassUI : MonoBehaviour
{
    [SerializeField]
    float numberOfPixelsNorthToNorth;
    [SerializeField]
    Transform objectTarget;
    [SerializeField]
    bool isMarker;

    Transform player;
    Vector3 startPosition;
    float rationAngleToPixel;
    Canvas canvas;
    Vector3 perp;
    float dir;

    void Start()
    {
        startPosition = transform.position;
        rationAngleToPixel = numberOfPixelsNorthToNorth / 360f;
        canvas = transform.parent.parent.GetComponent<Canvas>();
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (isMarker)
        {
            perp = Vector3.Cross(player.forward, objectTarget.forward);
            dir = Vector3.Dot(perp, Vector3.up);
            transform.position = startPosition + (new Vector3(Vector3.Angle(player.forward, objectTarget.forward) * Mathf.Sign(dir) * rationAngleToPixel * canvas.transform.lossyScale.x, 0, 0));
        }
        else
        {
            perp = Vector3.Cross(Vector3.forward, player.forward);
            dir = Vector3.Dot(perp, Vector3.up);
            transform.position = startPosition + (new Vector3(Vector3.Angle(player.forward, Vector3.forward) * Mathf.Sign(dir) * rationAngleToPixel * canvas.transform.lossyScale.x, 0, 0));
        }
    }
}
