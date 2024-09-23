using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCapability : MonoBehaviour
{
	public delegate void mensaje();
    public event mensaje OnCollideChest;
	public SpiderCloseTo notificador0;
	public SpiderCloseTo notificador1;
	public SpiderCloseTo notificador2;
	public SpiderCloseTo notificador3;
	public float health;
	
    // Start is called before the first frame update
    void Start()
    {
		health = 100f;
        notificador0.OnCloseMonster += decreaceHealth;
		notificador1.OnCloseMonster += decreaceHealth;
		notificador2.OnCloseMonster += decreaceHealth;
		notificador3.OnCloseMonster += decreaceHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "Chest") {
			OnCollideChest();
        }
    }
	
	void decreaceHealth() {
		health = health - 0.001f;
	}
}
