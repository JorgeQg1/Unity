using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesDistances : MonoBehaviour
{
    private GameObject playerCube;
    private GameObject playerSphere; 
    public float minimumDistance = 10f;
    public float speed = 10f; 

    // Start is called before the first frame update
    void Start()
    {
        playerCube = GameObject.FindWithTag("Player");
        playerSphere = GameObject.FindWithTag("Sphere");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, playerCube.transform.position) < minimumDistance) {
            this.transform.localScale *= 0.999f;
        }

        if (Vector3.Distance(this.transform.position, playerSphere.transform.position) < minimumDistance) {
            this.transform.localScale *= 1.001f;
        }
    }
}
