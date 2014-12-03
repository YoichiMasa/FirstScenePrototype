using UnityEngine;
using System.Collections;

public class WayPoint : MonoBehaviour
{
	public Transform otherPoint;
	
	// transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * rate); 
	//Above is to slow down player and make him turn when close to waypoint.
	// Use this for initialization
	void Start () 
	{
		
	}
	
	void Awake()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.name.Equals("FinalGoku")) 
		{
			AttackPlayer gp = (AttackPlayer) col.gameObject.GetComponent("AttackPlayer");
			gp.trail = otherPoint;
			gp.attacking = false;
		}
	}
	
}

