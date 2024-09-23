using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCapability : MonoBehaviour
{
    public int score;
    public Text textElement;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        textElement.text = "Puntuacion: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        textElement.text = "Puntuacion: " + score;
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "Cylinder") {
            collision.transform.localScale *= 1.25f;
            score++;
        }
    }

    void OnCollisionStay(Collision collision) {
        if (collision.collider.tag == "CylinderA") {
            if (Input.GetKey(KeyCode.Space)) { 
                Vector3 direction = collision.transform.position - this.transform.position;
                collision.rigidbody.AddForce(direction * 100000);
            }
        }
    }
}
