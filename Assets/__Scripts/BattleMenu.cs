using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleMenu : MonoBehaviour {

    static public BattleMenu S;
    public int activeOption;
    public List<GameObject> BattleOptions;
	private bool choiceSelected = false;
    private bool requ = false;

    public Pokemon PlayerPoke;
    public Pokemon EnemyPoke;

    void Awake()
    {
        S = this;
    }

	// Use this for initialization
	public void InitializeBattle(){

		Debug.Log ("Battle Initialized");
		bool first = true;
        activeOption = 0;

        foreach (Transform child in transform)
        {
            BattleOptions.Add(child.gameObject);
        }
        foreach (GameObject go in BattleOptions)
        {
            GUIText itemText = go.GetComponent<GUIText>();
            if (first) itemText.color = Color.red;
            first = false;
        }

        gameObject.SetActive(true);

    }
	
	// Update is called once per frame
	public void Update () {
		if (MainScript.S.inDialog)
		{
			Color noAlpha = gameObject.GetComponent<GUITexture>().color;
			noAlpha.a = 0;
			gameObject.GetComponent<GUITexture>().color  = noAlpha;
		}
		else 
		{
			if (Input.GetKeyDown(KeyCode.A) && !MainScript.S.inDialog)
			{
				gameObject.SetActive(true);
				switch (activeOption)
				{
				case 0:
					ATKMenu.S.gameObject.SetActive(true);
					gameObject.SetActive(false);
					choiceSelected = true;
					break;
				case 1:
					choiceSelected = true;
					break;
				case 2:
					choiceSelected = true;
					break;
				case 3:
					choiceSelected = true;
					break;
				}
			}
			//playerturn = true;
			else if (Input.GetKeyDown(KeyCode.DownArrow)&& !MainScript.S.inDialog)
			{
				MoveMenuDown();
			}
			else if (Input.GetKeyDown(KeyCode.UpArrow)&& !MainScript.S.inDialog)
			{
				MoveMenuDown();
			}
			if (Input.GetKeyDown(KeyCode.LeftArrow)&& !MainScript.S.inDialog)
			{
				MoveMenuRight();
			}
			else if (Input.GetKeyDown(KeyCode.RightArrow)&& !MainScript.S.inDialog)
			{
				MoveMenuRight();
			}
		}
		//else choiceSelected = false;
		//yield return null;
        
    }
	public IEnumerator PressA(KeyCode keyCode)
	{
		while (!Input.GetKeyDown(keyCode))
			yield return null;
	}


	public bool SelectOption(bool fromATKmenu , Pokemon opo, bool fromTurn)
	{
        if (fromTurn) requ = true;
        if (fromATKmenu && requ)
        {
            Debug.Log("Trying to damage enemy");
            Move dmgMove = ATKMenu.S.atkMove();
            Combat.S.Damage(Combat.S.oponentsPoke, dmgMove);
            Debug.Log("Just called Damage");
            Combat.S.playersTurn = false;
            requ = false;
            
        }

		return choiceSelected;
	}

    public void StartBattle()
    {
        this.gameObject.SetActive(true);
    }

    public void EndBattleMenu()
    {
        ATKMenu.S.EndATKMenu();
        gameObject.SetActive(false);

    }


     public void MoveMenuDown()
    {
        BattleOptions[activeOption].GetComponent<GUIText>().color = Color.black;
		if (activeOption == 0)  activeOption = 1; 
        else if (activeOption == 1) activeOption = 0;
		else if (activeOption == 2) activeOption = 3;
		else if (activeOption == 3) activeOption = 2;
        BattleOptions[activeOption].GetComponent<GUIText>().color = Color.red;
    }
    public void MoveMenuRight()
    {
        BattleOptions[activeOption].GetComponent<GUIText>().color = Color.black;
		if (activeOption == 0) activeOption = 2;
		else if (activeOption == 1) activeOption = 3;
		else if (activeOption == 2) activeOption = 0;
		else if (activeOption == 3) activeOption = 1;
        BattleOptions[activeOption].GetComponent<GUIText>().color = Color.red;
    }

}
