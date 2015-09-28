using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AreaPokemon : MonoBehaviour {
	static public AreaPokemon S;

	public List <Pokemon> areaPoke;
	public int numberOfPoke = 0;

	void Awake()
	{
		S = this;
	}

    public Pokemon WildPoke()
    {
        //GameObject go = Instantiate(Resources.Load("MyPrefab")) as GameObject;
        int chance = Random.Range(0, 100);
        if (chance < 50)
        {
            return Instantiate(areaPoke[0]);
        }
        else return Instantiate(areaPoke[1]);
        
    }
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
