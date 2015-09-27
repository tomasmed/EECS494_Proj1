using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Party : MonoBehaviour {

    static public Party S;

    public List<Pokemon> pokemonInParty;
    public Pokemon activePokemonInParty;



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
}
