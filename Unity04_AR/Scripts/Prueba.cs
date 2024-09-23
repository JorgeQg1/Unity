using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba : MonoBehaviour {
    void Start() {
        gameObject.SetActive(false);
    }

    public void OnTargetTracked() {
        Debug.Log("Tracked" + gameObject.name);
        gameObject.SetActive(true);
    }

    public void OnTargetUntracked() {
        Debug.Log("Untracked" + gameObject.name);
        gameObject.SetActive(false);
    }
}
