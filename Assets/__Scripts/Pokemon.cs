using UnityEngine;
using System.Collections;

public class Pokemon : MonoBehaviour {

    public string pokeName;
	public GUITexture pokeTexture;
    
	public string type;

    public int lvl = 1;
    public int xp = 0;
	public int hp ;
	public int speed;
	public int attack;
	public int defense;
	//public int accuracy;
	//public int specAtk;


	public Move move1;
	public Move move2;
	public Move move3;
	public Move move4;

    public bool ______________________;
    

    // Use this for initialization
    void Start () {

        GetComponent<GUIText>().text = pokeName;

        Color noAlpha = GetComponent<GUIText>().color;
        noAlpha.a = 0;
        GetComponent<GUIText>().color = noAlpha;

    }
	
	// Update is called once per frame
	void Update () {
	
	}


    public void LvlUp()
    {
        if(xp >= 100)
        {
            lvl++;
            xp -= 100;
        }
    }


}
