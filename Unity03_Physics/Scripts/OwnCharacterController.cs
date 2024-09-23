using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnCharacterController : MonoBehaviour
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

        if (Input.GetButton("Vertical")) {
            this.transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * velocity * Time.deltaTime);
        }

        if (Input.GetButton("Horizontal")){
            this.transform.Rotate(0, Input.GetAxis("Horizontal") * rotationVelocity, 0);
        } 
    }
}
