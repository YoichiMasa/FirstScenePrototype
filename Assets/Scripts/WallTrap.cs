using UnityEngine;
using System.Collections;

public class WallTrap : MonoBehaviour {
	
	GameObject player;
	HealthStaminaController bars;
	PlayerMovement alive;
	
	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		alive = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMovement> ();
		bars = GameObject.FindGameObjectWithTag ("HPSYS").GetComponent<HealthStaminaController>();
	}
	void OnCollisionEnter(Collision col)
	{
		if(col.transform.tag == "Player")
		{
			if(alive.alive == true)
			{
				if(bars.HP > 0)
				{bars.HP -= bars.maxHP* .10f;}
				if(bars.stamina > bars.minStamina)
				{bars.stamina -= bars.maxStamina*.15f;}
			}
		}
	}
}
