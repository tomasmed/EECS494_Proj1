using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StartBattle : MonoBehaviour {

    static public StartBattle S;
    public GUITexture battleMenu;
    public bool battleIsOver =false;

    void Awake()
    {
        S = this;
    }

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
    }
	// Update is called once per frame
	void Update () {}

    public void SetArena(List<Pokemon> enemies ,string message)
    {
		//NEED SOMETHING TO WAIT TILL player presses A
		/*
        DialogScript.S.gameObject.SetActive(true);
        Color noAlpha = GameObject.Find("DialogBackground").GetComponent<GUITexture>().color;
        noAlpha.a = 255;
        GameObject.Find("DialogBackground").GetComponent<GUITexture>().color = noAlpha;
        DialogScript.S.ShowMessage(message);*/
        
        gameObject.SetActive(true);
        Color ColorOp = gameObject.GetComponentInChildren<GUITexture>().color;
        ColorOp.a = 255;
        gameObject.GetComponentInChildren<GUIText>().color = ColorOp;

        BattleMenu.S.gameObject.SetActive(true);
        BattleMenu.S.InitializeBattle();
		foreach(Pokemon poke in enemies)
		{
            battleIsOver = false;
			StartCoroutine(Combat.S.Fight(poke));
		}
        Debug.Log("Combat is Over");
        if (battleIsOver)
        {
            gameObject.SetActive(false);
        }
        //gameObject.SetActive(false);
    }
    public void EndBattle()
    {
        MainScript.S.inBattle = false;
        BattleMenu.S.EndBattleMenu();
        gameObject.SetActive(false);
    }

}
