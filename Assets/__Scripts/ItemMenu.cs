using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ItemMenu : MonoBehaviour {

    public static ItemMenu S;

    //public bool test = false;
    public int activeItem;
    //public List<GameObject> items;
    public List<string> items;

    void Awake()
    {
        S = this;
    }

    // Use this for initialization
    void Start()
    {
        /*bool first = true;
        activeItem = 0;

        foreach (Transform child in transform)
        {
            battleItems.Add(child.gameObject);
        }

        battleItems = battleItems.OrderByDescending(m => m.transform.position.y).ToList();

        foreach (string name in Player.S.inventory)
        {
            GUIText itemText = go.GetComponent<GUIText>();
            if (first)
                itemText.color = Color.red;
            first = false;
        }*/
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*bool first = true;
        activeItem = 0;

        if (Player.S.newItems > 0)
        {
            //List<string> items;
            foreach (string name in Player.S.inventory)
            {
                items.Add(name);
            }

            items = items.OrderByDescending(m => m.transform.position.y).ToList();

            foreach (string name in items)
            {
                //GUIText itemText = go.GetComponent<GUIText>();
                if (first)
                    name.color = Color.red;
                first = false;
            }
            //gameObject.SetActive(false);

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                //MoveDownIMenu();
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
               // MoveUpIMenu();
            }
        }*/
    }

    /*public void MoveDownIMenu()
    {
        battleItems[activeItem].GetComponent<GUIText>().color = Color.black;
        activeItem = activeItem == battleItems.Count - 1 ? 0 : ++activeItem;
        battleItems[activeItem].GetComponent<GUIText>().color = Color.red;
    }
    public void MoveUpIMenu()
    {
        battleItems[activeItem].GetComponent<GUIText>().color = Color.black;
        activeItem = activeItem == 0 ? battleItems.Count - 1 : --activeItem;
        battleItems[activeItem].GetComponent<GUIText>().color = Color.red;
    }*/
}
