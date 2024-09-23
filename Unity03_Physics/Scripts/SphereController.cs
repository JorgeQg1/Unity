using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    public float velocity;
    public float rotationVelocity;

    // Start is called before the first frame update
    void Start() {
        velocity = 10;
        rotationVelocity = 1;
        this.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
    }

    // Update is called once per frame
    void Update() {
        Debug.DrawRay(this.transform.position, this.transform.TransformDirection(Vector3.forward) * 5f, Color.blue);

        if (Input.GetButton("Eje_Y")) {
            this.transform.Translate(Vector3.forward * Input.GetAxis("Eje_Y") * velocity * Time.deltaTime);
        }

        if (Input.GetButton("Eje_X")){
            this.transform.Rotate(0, Input.GetAxis("Eje_X") * rotationVelocity, 0);
        } 
    }
}
