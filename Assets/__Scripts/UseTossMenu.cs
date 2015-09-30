using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class UseTossMenu : MonoBehaviour {
	
	public static UseTossMenu S;
	private Item item;
	
	//public bool test = false;
	public int activeItem;
	public List<GameObject> battleItems;
	
	void Awake()
	{
		S = this;
	}
	
	
	public void Update_Menu()
	{
		this.Start ();
	}
	
	public void ActiveItem(Item inc_item)
	{
		item = inc_item;
	}
	// Use this for initialization
	void Start()
	{
		bool first = true;
		activeItem = 0;
		int j = 0;
		foreach (Transform child in transform)
		{
				battleItems.Add(child.gameObject);
		}
		foreach (GameObject go in battleItems)
		{
			GUIText itemText = go.GetComponent<GUIText>();
			if (first) itemText.color = Color.red;
			first = false;
		}
		gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.S))
		{
			gameObject.SetActive(false);
			ItemMenu.S.usetoss = false;
			//ItemMenu.S.gameObject.SetActive(true);
			print("Returning to Item menu");
		}
		else
		{
			if (Input.GetKeyDown(KeyCode.A))
			{
				switch (activeItem)
				{
				case 0:
					this.gameObject.SetActive(false);
					//ItemMenu.S.usetoss = false;
					print("Selected : Use ");
					item.Use ();
					Inventory.S.Remove(item);
					ItemMenu.S.Update_Menu();

					gameObject.SetActive(false);
					ItemMenu.S.gameObject.SetActive(true);
					break;
				case 1:
					this.gameObject.SetActive(false);
					//ItemMenu.S.usetoss = false;
//					Destroy (item);
					Inventory.S.Remove(item);
					ItemMenu.S.Update_Menu();
					print("TRying to destroy" + item.name );

					gameObject.SetActive(false);
					ItemMenu.S.gameObject.SetActive(true);
					break;
				}
			}
		}
		
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			MoveDownMenu();
		}
		else if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			MoveUpMenu();
		}
		
		
	}
	
	public void MoveDownMenu()
	{
		battleItems[activeItem].GetComponent<GUIText>().color = Color.black;
		activeItem = activeItem == battleItems.Count - 1 ? 0 : ++activeItem;
		battleItems[activeItem].GetComponent<GUIText>().color = Color.red;
	}
	public void MoveUpMenu()
	{
		battleItems[activeItem].GetComponent<GUIText>().color = Color.black;
		activeItem = activeItem == 0 ? battleItems.Count - 1 : --activeItem;
		battleItems[activeItem].GetComponent<GUIText>().color = Color.red;
	}
}
