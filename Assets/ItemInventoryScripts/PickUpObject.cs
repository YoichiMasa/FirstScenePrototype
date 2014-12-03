using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PickUpObject : MonoBehaviour {
	public PlayerInventory player;
	public PlayerMovement move;
	Item item;
	public int itemID;
	public ParticleSystem interactable;
	public bool isFull = false;
	bool tooHeavy = false;
	Rect windowRect = new Rect(Screen.width/2, Screen.height/2, 200f, 200f);

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerInventory>();
		move = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
	}

	void OnTriggerStay(Collider col)
	{
		if(col.transform.tag == "Player")
		{
			if(Input.GetKeyDown(KeyCode.F))
			{
				pickUp();
			}
		}
	}

//	void OnTriggerExit(Collider col)
//	{
//		if(col.transform.tag == "Player")
//		{
//			hasCollided = false;
//		}
//	}
	// Update is called once per frame
//	void Update () 
//	{
//		if(hasCollided == true)
//		{
//			if(Input.GetKeyDown(KeyCode.F))
//			{
//				pickUp();
//			}
//		}
//	}

	void pickUp()
	{
		ItemManager im = ItemManager.getInstance;
		Item item = im.SearchNewItem(itemID);
		if(player.checkWeight(item))
		{
			if(player.AddItemToInventory(itemID) > -1)
			{
				//player.AddItemToInventory (itemID);
				GameObject.Destroy(this.gameObject);
			}
			else
			{
				Debug.Log("Pack is full");
			}
		}
		else
		{
			Debug.Log("It's getting too heavy");
		}
	}
}
