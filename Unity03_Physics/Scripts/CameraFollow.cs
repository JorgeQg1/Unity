using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float speed = 10.0f;

    void Start() {
        followTarget();
    }

    void LateUpdate()
    {
       followTarget();
    }

    void followTarget() {
        Vector3 position = Vector3.Lerp(transform.position, target.position + new Vector3(0, 5, -10), speed * Time.deltaTime);
        this.transform.position = position;
        this.transform.LookAt(target.position);
    }
}
