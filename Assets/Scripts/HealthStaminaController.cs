using UnityEngine;
using System.Collections;
using System;
public class HealthStaminaController : MonoBehaviour {

	public PlayerMovement player;
	public PlayerInventory inven;
	public GUISkin HpStam;
	public float HP = 100f;
	public float maxHP = 100f;
	public float stamina = 1000f;
	public float maxStamina = 1000f;
	public float minStamina = -1000f;

	//Base Values for Stamina Consumption
	public float baseIdle = 1f;
	public float baseMove = 0.05f;
	public float baseSprint = 0.1f;
	public float baseJump = 2f;
	public float baseClimb = 0.1f;
	public float baseAttack;
	public readonly float origMove = .05f;

	//visuals
	public Texture2D HPBar;
	public Material mat1;
	public Texture2D StaminaBar;
	public Material mat2;
	public Texture2D backing;
	public Material mat3;

	//screen coodinates and dimensions
//	public float x1 = 0;
//	public float y1 = 0;
//	public float w1;
//	public float h1;
	public Rect hpBarRect;

//	public float x2 = 0;
//	public float y2 = 0;
//	public float w2;
//	public float h2;
	public Rect stamBarRect;

	public Vector2 textHP;
	public Vector2 textStamina;

	//Update Draw Animator things
	private float healthy;
	private float energized;

	//GUITexts
	public GUIText HealthGUI;
	public GUIText StaminaGUI;

	float defaultScreen = 1200f;
	

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMovement> ();
		inven = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerInventory> (); 
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (player.alive == true) 
		{
						//for Animating Health and Stamina Bars
						healthy = (1 - (HP / maxHP));
						//		if(healthy == 0f){
						//			healthy = 0.1f;
						//		}
						mat1.SetFloat ("_Cutoff", healthy);
			
						energized = (1 - (stamina / maxStamina));
						//		if(energized == 0f){
						//			energized = 0.1f;
						//		}
						mat2.SetFloat ("_Cutoff", energized);
						
						//Idle
						if (stamina > minStamina)
						{
							stamina = stamina - ((baseIdle + baseIdle*(float)inven.currentWeight/inven.weightLimit)*Time.deltaTime);
						}
						//Moving
						if (player.rigidbody.velocity != Vector3.zero) 
						{
							stamina = stamina - ((baseMove + baseMove*(float)inven.currentWeight/inven.weightLimit)*Time.deltaTime);
						}
						if (stamina <= 0) 
						{
							HP -= (1f * Time.deltaTime / 3f);
						}
		}
	}

	void OnGUI() {
		GUI.skin = HpStam;
		GUIStyle hp = HpStam.GetStyle ("HP");
		GUIStyle stam = HpStam.GetStyle ("Stamina");
		if(Event.current.type.Equals(EventType.Repaint))
		{
			Rect box3 = new Rect (Screen.width/2 - Screen.width*hpBarRect.x, Screen.height - Screen.height *hpBarRect.y, Screen.width*hpBarRect.width, Screen.height*hpBarRect.height);
			Graphics.DrawTexture (box3, backing, mat3);
			
			Rect box4 = new Rect (Screen.width/2 - Screen.width*stamBarRect.x, Screen.height - Screen.height *stamBarRect.y, Screen.width*stamBarRect.width, Screen.height*stamBarRect.height);
			Graphics.DrawTexture (box4, backing, mat3);



			Rect box1 = new Rect(Screen.width/2 - Screen.width*hpBarRect.x, Screen.height - Screen.height *hpBarRect.y, Screen.width*hpBarRect.width, Screen.height*hpBarRect.height);
			Graphics.DrawTexture(box1, HPBar, mat1);

			Rect box2 = new Rect(Screen.width/2 - Screen.width*stamBarRect.x, Screen.height - Screen.height *stamBarRect.y, Screen.width*stamBarRect.width, Screen.height*stamBarRect.height);
			Graphics.DrawTexture(box2, StaminaBar, mat2);


			//Health
			hp.fontSize = (int)(getScale() * 60f);
			Rect hpText = new Rect(Screen.width/2 - Screen.width*textHP.x, Screen.height - Screen.height *textHP.y, Screen.width*hpBarRect.width, Screen.height*hpBarRect.height);
			if(HP == maxHP)
			{
				GUI.Label(hpText, "| "+HP, HpStam.GetStyle("HP"));
			}
			else if(HP < 100 && HP > 9)
			{
				//GUI.Label(hpText, "0"+HP+" |", HpStam.GetStyle("HP"));
				GUI.Label(hpText, "| "+(float)Math.Round((double)(HP),2));
			}
			else if(HP <= 9)
			{
				//GUI.Label(hpText, "00"+HP+" |", HpStam.GetStyle("HP"));
				GUI.Label(hpText, "| "+(float)Math.Round((double)(HP),2));
			}

			//Stamina
			stam.fontSize = (int)(getScale() * 60f);
			Rect staminaText = new Rect(Screen.width/2 - Screen.width*textStamina.x, Screen.height - Screen.height *textStamina.y, Screen.width*stamBarRect.width, Screen.height*stamBarRect.height);
			if(stamina == maxStamina)
			{
				//GUI.Label (staminaText, ""+((stamina/maxStamina)*100)+".0% |", stam);
				GUI.Label (staminaText, "| "+((stamina/maxStamina)*100)+".0%", stam);
			}
			if(stamina < 0)
			{
				GUI.Label (staminaText, "| "+0+".0%", stam);
			}
			else if(stamina < maxStamina)
			{
				GUI.Label (staminaText, "| "+(float)Math.Round((double)(stamina/maxStamina)*100f,2)+"%", stam);
			}
		}
	}
	float getScale()
	{
		return (Screen.height / defaultScreen);
	}
}
