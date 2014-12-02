using UnityEngine;
using System.Collections;

public class TrapTrigger : MonoBehaviour {

	Rigidbody player;
	PlayerMovement obj;
	Transform trap;
	Vector3 doom;
	bool trapTriggered = false;
	bool force = false;
	bool waiting = false;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody>();
		trap = GameObject.FindGameObjectWithTag ("Trap").GetComponent<Transform> ();
		obj = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMovement> ();
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.transform.tag == "Player")
		{
			trapTriggered = true;
		}
	}

	void OnTriggerExit(Collider col)
	{
		if(col.transform.tag == "Player")
		{
			trapTriggered = false;
		}
	}

	void Update()
	{
		if(trapTriggered == true)
		{
			force = true;
			if(force == true)
			{
				if(player.velocity.magnitude < 6f)
				{
					player.AddForce(Vector3.right*15);
				}	
			}
			if(Input.anyKeyDown && !waiting)
			{
				force = false;
				Wait (3);
			}
		}
	}

	IEnumerator Wait(float sec)
	{
		waiting = true;
		yield return new WaitForSeconds(sec);
		force = true;
	}
}
