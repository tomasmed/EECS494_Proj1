using UnityEngine;
using System.Collections;

public class Potion : Item {
	public static Potion S;
	private bool done =false;
	void Awake()
	{
		S = this;
	}

	private Pokemon poke;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (done) Use ();
	}

	public void GivePoke(Pokemon poke_)
	{
		done = true;
		poke = poke_;
	}

	public override void Use()
	{
		//DialogScript.S.ShowMessage("On what Pokemon? ");
		if (!done) {
			UseOnPokeMenu.S.gameObject.SetActive (true);
		}
		//Pokemon objective = UseOnPokeMenu.S.PokeToUseOn ();

		else {
			Debug.Log ("Used potion on: " + poke.pokeName);
			if (poke.hp + 20 > poke.max_hp) poke.hp = poke.max_hp;
			else poke.hp += 20;
			done = false;
			gameObject.SetActive(false);
		}
		//What a potion does



	}
}
