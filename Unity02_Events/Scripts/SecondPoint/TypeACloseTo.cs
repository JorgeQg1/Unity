using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeACloseTo : MonoBehaviour
{
    public PlayerNotifier notificador;
    private Rigidbody rb;
    private float distanceToTheGround;

    // Start is called before the first frame update
    void Start()
    {   
        rb = this.GetComponent<Rigidbody>();
        notificador.OnCloseToTypeC += changeColor;
        notificador.OnCloseToTypeC += jump;
        distanceToTheGround = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTheGround = this.transform.position.y;
    }

    void changeColor() {
        var render = this.GetComponent<Renderer>();

        if (render.material.GetColor("_Color") != Color.red) {
            render.material.SetColor("_Color", Color.red);
        } else {
            render.material.SetColor("_Color", Color.blue);
        }
    }

    void jump() {
        if (distanceToTheGround < 1f) {
            Vector3 jumpVelocity = new Vector3(0f, 0.5f, 0f);
            rb.velocity += jumpVelocity;
        }
    }
}
