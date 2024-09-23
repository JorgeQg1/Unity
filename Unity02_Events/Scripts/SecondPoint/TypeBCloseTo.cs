using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeBCloseTo : MonoBehaviour
{
    public PlayerNotifier notificador;

    // Start is called before the first frame update
    void Start()
    {   
        notificador.OnCloseToTypeC += lookAtObjetive;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = this.transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(this.transform.position, forward * 100f, Color.red);
    }

    void lookAtObjetive() {
        GameObject objetive = GameObject.FindWithTag("Objetive");

        Vector3 targetDirection = objetive.transform.position - this.transform.position;
        Vector3 newDirection = Vector3.RotateTowards(this.transform.forward, targetDirection, 1.0f, 0.0f);

        this.transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
