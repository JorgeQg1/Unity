using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTeleport : MonoBehaviour
{
	private GameObject[] teleportPoints;
    // Start is called before the first frame update
    void Start()
    {
        teleportPoints = GameObject.FindGameObjectsWithTag("TeleportPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.T)) {
			int randomPointIndex = Random.Range(0, teleportPoints.Length);
			this.transform.position = teleportPoints[randomPointIndex].transform.position;
        }
    }
}
