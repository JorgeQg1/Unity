using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coloring : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        if (this.tag == "CylinderA") {
            this.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        } else if (this.tag == "CylinderB") {
            this.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }
    }
}
