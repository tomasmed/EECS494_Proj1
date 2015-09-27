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

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
