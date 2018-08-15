using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turn : MonoBehaviour
{
    [SerializeField]
    Transform objectToLookAt;
    [SerializeField]
    Text distanceText1;
    [SerializeField]
    Text distanceText2;

    private void Update()
    {
        transform.LookAt(objectToLookAt);
        transform.position = new Vector3(transform.position.x, objectToLookAt.position.y, transform.position.z);

        distanceText1.text = Mathf.Round(Vector3.Distance(transform.position, objectToLookAt.position)).ToString();
        distanceText2.text = Mathf.Round(Vector3.Distance(transform.position, objectToLookAt.position)).ToString();
    }
}
