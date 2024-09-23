using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeFromTarget : MonoBehaviour
{
    public Transform target;
    public float minimumDistance = 5f;
    public float speed = 10f; 

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, target.position) < minimumDistance) {
            Vector3 direction = (this.transform.position - target.position).normalized;
            direction.y = 0;
            this.transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}
