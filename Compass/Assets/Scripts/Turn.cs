using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    [SerializeField]
    Transform objectToLookAt;

    private void Update()
    {
        transform.LookAt(objectToLookAt);
        transform.position = new Vector3(transform.position.x, objectToLookAt.position.y, transform.position.z);
    }
}
