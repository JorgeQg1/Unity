using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNotifier : MonoBehaviour
{
    public delegate void mensaje();
    public event mensaje OnCollideTypeA;
    public event mensaje OnCollideTypeB;
    public event mensaje OnCloseToTypeC;
    
    private double minimumDistance = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject typeC = GameObject.FindWithTag("TypeC");
        if (Vector3.Distance(transform.position, typeC.transform.position) < minimumDistance) {
            OnCloseToTypeC();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "TypeB") {
            OnCollideTypeB();
        } else if (collision.collider.tag == "TypeA") {
            OnCollideTypeA();
        }
    }
}
