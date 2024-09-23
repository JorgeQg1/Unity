using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderCloseTo : MonoBehaviour
{
	public delegate void mensaje();
    public event mensaje OnCloseMonster;
	
	public float minimumDistance;
	
    // Start is called before the first frame update
    void Start()
    {
        minimumDistance = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject monster = GameObject.FindWithTag("Monster");
        if (Vector3.Distance(transform.position, monster.transform.position) < minimumDistance) {
            OnCloseMonster();
        }
    }
}
