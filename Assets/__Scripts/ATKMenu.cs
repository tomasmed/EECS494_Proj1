using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ATKMenu : MonoBehaviour {
	static public ATKMenu S;

	public int activeATK;
	public List<GameObject> ATKOptions;
    private Move dmgMove;
	
	void Awake()
	{
		S = this;
		gameObject.SetActive (false);
	}


	public void UpdateOptions()
	{
		Start ();
	}


	void Start () {
		bool first = true;
		activeATK = 0;
		
		foreach (Transform child in transform)
		{
			ATKOptions.Add(child.gameObject);
		}
		foreach (GameObject go in ATKOptions)
		{

            GUIText itemText = go.GetComponent<GUIText>();
            if (go == ATKOptions[0]) itemText.text = Party.S.activePokemonInParty.move1.moveName;
            else if (go == ATKOptions[1]) itemText.text = Party.S.activePokemonInParty.move2.moveName;
            else if (go == ATKOptions[2]) itemText.text = Party.S.activePokemonInParty.move3.moveName;
            else if (go == ATKOptions[3]) itemText.text = Party.S.activePokemonInParty.move4.moveName;


            if (first) itemText.color = Color.red;
			first = false;
		}
		
		gameObject.SetActive(true);
		
	}
	
	// Update is called once per frame
	void Update () {

		if (MainScript.S.inDialog) {
			Color noAlpha = gameObject.GetComponent<GUITexture> ().color;
			noAlpha.a = 0;
			gameObject.GetComponent<GUITexture> ().color = noAlpha;
		} 
		else 
		{
            Color noAlpha = gameObject.GetComponent<GUITexture>().color;
            noAlpha.a = 255;
            gameObject.GetComponent<GUITexture>().color = noAlpha;
            if (Input.GetKeyDown (KeyCode.S)) {
				gameObject.SetActive (false);
				print ("Returning to main Battle menu");
				BattleMenu.S.can_move = true;
				BattleMenu.S.gameObject.SetActive (true);
				//MainScript.S.paused = false;
			} 
			if (Input.GetKeyDown (KeyCode.A) && !MainScript.S.inDialog) {
               
                switch (activeATK) {
				case 0:
					//print("Selected : Move1");
					dmgMove = Party.S.activePokemonInParty.move1;
					BattleMenu.S.SelectOption (true, Combat.S.oponentsPoke, false, false);
					break;
				case 1:
					//print("Selected : Move2");
					dmgMove = Party.S.activePokemonInParty.move2;
					BattleMenu.S.SelectOption (true, Combat.S.oponentsPoke, false, false);
					break;
				case 2:
					//print("Selected : move3");
					dmgMove = Party.S.activePokemonInParty.move3;
					BattleMenu.S.SelectOption (true, Combat.S.oponentsPoke, false, false);
					break;
				case 3:
					//print("Selected : Move4");
					dmgMove = Party.S.activePokemonInParty.move4;
					BattleMenu.S.SelectOption (true, Combat.S.oponentsPoke, false, false);
					break;
				}
			} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
				MoveMenuDown ();
			} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
				MoveMenuDown ();
			}
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				MoveMenuRight ();
			} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
				MoveMenuRight ();
			}
		}


	}


    public Move atkMove()
    {
        return dmgMove;
    }

	public void MoveMenuDown()
	{
		ATKOptions[activeATK].GetComponent<GUIText>().color = Color.black;
		if (activeATK == 0)  activeATK = 2; 
		else if (activeATK == 1) activeATK = 3;
		else if (activeATK == 2) activeATK = 0;
		else if (activeATK == 3) activeATK = 1;
		ATKOptions[activeATK].GetComponent<GUIText>().color = Color.red;
	}
	public void MoveMenuRight()
	{
		ATKOptions[activeATK].GetComponent<GUIText>().color = Color.black;
		if (activeATK == 0) activeATK = 1;
		else if (activeATK == 1) activeATK = 0;
		else if (activeATK == 2) activeATK = 3;
		else if (activeATK == 3) activeATK = 2;
		ATKOptions[activeATK].GetComponent<GUIText>().color = Color.red;
	}
	

    public void EndATKMenu()
    {
        gameObject.SetActive(false);
    }
}
