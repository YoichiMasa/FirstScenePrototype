using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {

	Rigidbody platform;

	void Start()
	{
		platform = GameObject.FindGameObjectWithTag ("Platform").GetComponent<Rigidbody>();
	}
	void OnTriggerStay(Collider col)
	{
		if(col.transform.tag == "Player")
		{
			platform.AddForce(Vector3.up*20);
		}
	}
}
