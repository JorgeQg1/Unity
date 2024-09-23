using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeBCollition : MonoBehaviour
{
    public PlayerNotifier notificador;
    public float unitsMoved = 1f;

    // Start is called before the first frame update
    void Start()
    {   
        notificador.OnCollideTypeB += moveCloserToTypeC;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void moveCloserToTypeC() {
        GameObject typeC = GameObject.FindWithTag("TypeC");
        this.transform.position = Vector3.MoveTowards(this.transform.position, typeC.transform.position, unitsMoved);
    }
}
