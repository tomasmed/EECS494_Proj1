using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ItemMenu : MonoBehaviour {

    public static ItemMenu S;

    //public bool test = false;
    public int activeItem;
    public List<GameObject> battleItems;

	public bool usetoss= false;

    void Awake()
    {
        S = this;
    }


	public void Update_Menu()
	{
		this.Start ();
	}


    // Use this for initialization
    void Start()
    {
		battleItems = new List<GameObject>{}; 
        bool first = true;
        activeItem = 0;
		int j = 0;

		foreach (Transform child in transform)
		{
			child.gameObject.GetComponent<GUIText>().text = "";
		}

		foreach (Transform child in transform)
		{
			if(j >= Inventory.S.itemsInInventory.Count) break;
			else
			{
				battleItems.Add(child.gameObject);

				++j;
			}
		}




		for (int i = 0; i  <  Inventory.S.itemsInInventory.Count ; i++)
		{
			if (i == 5 )break;
			else 
			{
				GameObject go = battleItems[i];
				GUIText itemText = go.GetComponent<GUIText>();
				itemText.text = Inventory.S.itemsInInventory[i].name;
				itemText.color = Color.black;
				
				if (first) itemText.color = Color.red;
				first = false;
			}


		}
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.S))
		{
			gameObject.SetActive(false);
			print("Returning to main menu");
			//Menu.S.gameObject.SetActive(true);
			//MainScript.S.paused = false;
		}
		else
		{
			if (Input.GetKeyDown(KeyCode.A)&& !usetoss)
			{
				usetoss = true;
				switch (activeItem)
				{
				case 0:
					UseTossMenu.S.ActiveItem(Inventory.S.itemsInInventory[0]);
					UseTossMenu.S.gameObject.SetActive(true);
					print("Selected : " + Inventory.S.itemsInInventory[0].name);
					this.gameObject.SetActive(false);
					break;
				case 1:
					UseTossMenu.S.ActiveItem(Inventory.S.itemsInInventory[1]);
					UseTossMenu.S.gameObject.SetActive(true);
					print("Selected : " + Inventory.S.itemsInInventory[1].name);
					this.gameObject.SetActive(false);
					break;
				case 2:
					UseTossMenu.S.ActiveItem(Inventory.S.itemsInInventory[2]);
					UseTossMenu.S.gameObject.SetActive(true);
					print("Selected : " + Inventory.S.itemsInInventory[2].name);
					this.gameObject.SetActive(false);
					break;
				case 3:
					UseTossMenu.S.ActiveItem(Inventory.S.itemsInInventory[3]);
					UseTossMenu.S.gameObject.SetActive(true);
					print("Selected : " + Inventory.S.itemsInInventory[3].name);
					this.gameObject.SetActive(false);
					break;
				case 4:
					UseTossMenu.S.ActiveItem(Inventory.S.itemsInInventory[4]);
					UseTossMenu.S.gameObject.SetActive(true);
					print("Selected : " + Inventory.S.itemsInInventory[4].name);
					this.gameObject.SetActive(false);
					break;
				}
			}
		}
		
		if (Input.GetKeyDown(KeyCode.DownArrow) && !usetoss)
		{
			MoveDownMenu();
		}
		else if (Input.GetKeyDown(KeyCode.UpArrow)&& !usetoss)
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
