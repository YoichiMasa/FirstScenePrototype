using UnityEngine;
using System.Collections;

[System.Serializable]
public class KeyItem: Item
{
	ItemManager im;
	void onStart()
	{
		im = ItemManager.getInstance;
	}
	public void ConfigureKeyItem(string name, int ID, string description, int baseWeight, int height, int width, ItemType type)
	{
		base.ConfigureItem (name, ID, description, baseWeight, height, width, type);
		itemName = name;
		itemID = ID;
		itemDescription = description;
		itemBaseWeight = baseWeight;
		itemHeight = height;
		itemWidth = width;
		itemType = type;

	}
}
