using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;



public enum menuItem
{
    pokedex, 
    pokemon,
    item,
    player,
    save,
    option,
    exit
}


public class Menu : MonoBehaviour {
    static public Menu S;

    public int activeItem;
    public List<GameObject> menuItems;



    void Awake()
    {
        S = this;
    }
	// Use this for initialization
	void Start () {
        bool first = true;
        activeItem = 0;

        foreach(Transform child in transform)
        {
            menuItems.Add(child.gameObject);
        }

        menuItems = menuItems.OrderByDescending(m => m.transform.position.y).ToList();

        foreach (GameObject go in menuItems)
        {
            GUIText itemText = go.GetComponent<GUIText>();
            if (first) itemText.color = Color.red;
            first = false;
        }


        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.S))
        {
            gameObject.SetActive(false);
            MainScript.S.paused = false;
        }
        else if (MainScript.S.paused)
        {
            if(Input.GetKeyDown(KeyCode.A))
            {
                switch(activeItem)
                {
                    case (int)menuItem.pokedex:
                        print("pokedex menu selcted");
                        break;
                    case (int)menuItem.pokemon:
                        PokemonMenu.S.gameObject.SetActive(true);
                        gameObject.SetActive(false);
                        //MainScript.S.paused = false;
                        print("pokemon menu selcted");
                        break;
                    case (int)menuItem.item:
						ItemMenu.S.gameObject.SetActive(true);
						gameObject.SetActive(false);
                        print("item menu selcted");
                        break;
                    case (int)menuItem.player:
                        print("player menu selcted");
                        break;
                    case (int)menuItem.save:
                        print("save menu selcted");
                        break;
                    case (int)menuItem.option:
                        print("option menu selcted");
                        break;
                    case (int)menuItem.exit:
						gameObject.SetActive(false);
						MainScript.S.paused = false;
                        break;

                }
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveMenuDown();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveMenuUp();
        }

    }




    public void MoveMenuDown()
    {
        menuItems[activeItem].GetComponent<GUIText>().color = Color.black;
        activeItem = activeItem == menuItems.Count - 1 ? 0 : ++activeItem;
        menuItems[activeItem].GetComponent<GUIText>().color = Color.red;
    }
    public void MoveMenuUp()
    {
        menuItems[activeItem].GetComponent<GUIText>().color = Color.black;
        activeItem = activeItem == 0 ? menuItems.Count -1  : --activeItem;
        menuItems[activeItem].GetComponent<GUIText>().color = Color.red;
    }

}
