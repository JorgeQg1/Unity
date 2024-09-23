using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggIncreaseSize : MonoBehaviour
{
	public MonsterCapability notificador;
	
    // Start is called before the first frame update
    void Start()
    {
        notificador.OnCollideChest += increaseSize;
    }
	
	void increaseSize() {
		this.transform.localScale += new Vector3(0.075f, 0.075f, 0.075f);
	}
}
