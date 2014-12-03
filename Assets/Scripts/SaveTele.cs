using UnityEngine;
using System.Collections;

public class SaveTele : MonoBehaviour {

	GameObject player;
	GameObject tele;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		tele = GameObject.FindGameObjectWithTag ("TelePoint");
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.transform.tag == "Player")
		{
			player.transform.position = tele.transform.position;
		}
	}
}
