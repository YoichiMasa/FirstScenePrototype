using UnityEngine;
using System.Collections;

public class AttackPlayer : MonoBehaviour 
{
	//public variables 
	public PlayerLocation pl;
	public Vector3 vectorToTarget;
	public GameObject home;
	public float delayTime = 1.5f;//made public just incase we make items that slow him down a little bit.
	public Transform trail;
	public  float moveSpeed = 2.0f;
	public bool attacking =  false;
	public bool wasAttacking = false;
	//private variables
	
	private Transform myTransform;
	private float countTimer = 4.0f;
	private int maxDistance;
	private Transform target;
	private GameObject patrol = new GameObject();
	private Transform goku;
	private Vector3 gokuMoves;
	
	void Awake() 
	{
		myTransform = transform;
		goku = transform;//assigning Transform Goku to the transform
		
	}
	// Use this for initialization
	void Start () 
	{
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		target = go.transform;
		moveSpeed = 1;
		maxDistance = 7;
		
		patrol = GameObject.FindGameObjectWithTag("WayPoint");
		trail = patrol.transform;
		goku.position = goku.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if (Vector3.Distance (target.position, myTransform.position) < maxDistance) {
			attacking = true;
			wasAttacking = true;
		} else {
			attacking = false;	
			if(wasAttacking == true) {
				wasAttacking = false;
				trail = home.transform;
			}
		}
		
		if (attacking == false) {
			MoveGoku ();
		}
		else 
		{
			FindAndChase ();
		}
	}
	
	void FindAndChase()
	{
		countTimer += Time.deltaTime;
		
		//if (Vector3.Distance (target.position, myTransform.position) < maxDistance) 
		//{
		//Debug.Log ("ATTACKING");
		//attacking = true;
		moveSpeed = 4;
		if (countTimer >= delayTime)
		{
			trail = pl.transform;
			vectorToTarget = target.position - myTransform.position;
			vectorToTarget.Normalize();
			countTimer = 0.0f;
			//Move towards target
		}
		//}
		//else 
		//{	
		//	attacking = false;
		//goku.trail = trail.transform;		
		
		//}
		
		
		
		myTransform.position += vectorToTarget * moveSpeed * Time.deltaTime;
	}
	void MoveGoku()
	{
		moveSpeed = 1;
		goku.position += gokuMoves * moveSpeed * Time.deltaTime;
		gokuMoves = trail.position - goku.position;
		
	}
	
}
