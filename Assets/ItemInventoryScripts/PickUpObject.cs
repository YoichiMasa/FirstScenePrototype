using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PickUpObject : MonoBehaviour {
	RaycastHit	hit;
	public bool hasCollided = false;
	string labelText = "";
	public PlayerInventory player;
	public PlayerMovement move;
	public ParticleSystem interactable;
	Item item;
	public bool isFull = false;
	bool tooHeavy = false;
	Rect windowRect = new Rect(Screen.width/2, Screen.height/2, 200f, 200f);
	public int itemID;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerInventory>();
		move = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
		interactable = GameObject.FindGameObjectWithTag ("Interactable").GetComponentInChildren<ParticleSystem> ();
	}

	void OnTriggerStay(Collider col)
	{
		if(col.transform.tag == "Player")
		{
//			hasCollided = true;
//			labelText = "Pick up: E";
			//interactable.Play();
			if(Input.GetKeyDown(KeyCode.F))
			{
				pickUp();
			}
		}
	}


	void OnGUI()
	{
		if(isFull)
		{
			StartCoroutine(ShowMessage("Pack is Full", 2));

		}
		if(tooHeavy)
		{
			StartCoroutine(ShowMessage("Getting too Heavy", 2));
		}
	}

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
				isFull = true;

			}
		}
		else
		{
			tooHeavy = true;

		}
	}

	IEnumerator ShowMessage(string message, float delay)
	{
//		guiText.text = message;
//		guiText.enabled = true;
		GUI.Label(windowRect, message, GUI.skin.GetStyle("Weight"));
		yield return new WaitForSeconds(delay);
		tooHeavy = false;
		isFull = false;
		//guiText.enabled = false;
	}
}
