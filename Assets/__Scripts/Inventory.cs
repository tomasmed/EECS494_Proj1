using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Inventory : MonoBehaviour {

	public static Inventory S;
	public List<Item> itemsInInventory;

	void Awake()
	{
		S = this;
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Remove(Item item)
	{
		itemsInInventory.Remove (item);
		/*foreach (Item it in itemsInInventory) 
		{
			if (it == item) itemsInInventory.Remove(item)
		}*/
	}
}
