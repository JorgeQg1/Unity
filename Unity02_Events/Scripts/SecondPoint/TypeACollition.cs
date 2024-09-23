using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeACollition : MonoBehaviour
{
    public PlayerNotifier notificador;

    // Start is called before the first frame update
    void Start()
    {   
        notificador.OnCollideTypeA += incrementSizeTypeB;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void incrementSizeTypeB() {
        this.transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
    }
}
