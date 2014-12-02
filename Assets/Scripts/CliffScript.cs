using UnityEngine;
using System.Collections;

public class CliffScript : MonoBehaviour {
	GameObject player;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	void OnTriggerEnter(Collider col)
	{
		if(col.transform.tag == "Player")
		{
			Destroy (player);
			player.GetComponent<PlayerMovement>().alive = false;
		}
	}
}
