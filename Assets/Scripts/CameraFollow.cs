using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, 5.0f, transform.position.z);
    }
}
