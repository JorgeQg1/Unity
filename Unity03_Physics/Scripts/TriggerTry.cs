using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTry : MonoBehaviour
{

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter(Collider other) {
      Rigidbody rb = other.attachedRigidbody;
      if (rb != null) {
        other.transform.position = transform.position + new Vector3(0, 4, 0);
        other.attachedRigidbody.velocity = new Vector3(0, 0, 0);
      }
    }
}
