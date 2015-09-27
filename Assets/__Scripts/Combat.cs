using UnityEngine;
using System.Collections;

public class Combat : MonoBehaviour {
	static public Combat S;
	public bool playersTurn = true;
    public Pokemon oponentsPoke;

	void Awake()
	{
		S = this;
	}
	public IEnumerator Fight(Pokemon Oponent)
	{
		/*Color ColorOp = gameObject.GetComponentInChildren<GUITexture>().color;
		ColorOp.a = 255;
		gameObject.GetComponentInChildren<GUIText>().color = ColorOp;
		*/
		Debug.Log("Fetching fight images");

        oponentsPoke = Oponent;
		Pokemon playersPoke = Party.S.activePokemonInParty;

		GameObject.Find ("Player's_GUI").GetComponent<GUITexture>().texture = playersPoke.pokeTexture.texture;
		GameObject.Find ("Oponent's_GUI").GetComponent<GUITexture>().texture = Oponent.pokeTexture.texture;

        Debug.Log(playersPoke.name + " has " + playersPoke.hp + " hp VS " + Oponent.pokeName + "with " + Oponent.hp);
        bool alive = true;
        while (alive)
		{
            if (playersPoke.hp < 1)
            {
                Debug.Log(playersPoke.pokeName + "Fainted");
                alive = false;
                
                StartBattle.S.battleIsOver = true;
                break;
            }
                
            else if ( Oponent.hp < 1)
            {
                Debug.Log(Oponent.pokeName + "Fainted");
                playersPoke.xp += 25 * Oponent.lvl;
                Debug.Log(playersPoke.pokeName + " gained " + 25 * Oponent.lvl +  " xp");
                if (playersPoke.xp >99)
                {
                    Debug.Log(playersPoke.pokeName + " lvled up!");
                    playersPoke.xp = playersPoke.xp - 99;
                    playersPoke.lvl++;
                }

                alive = false;
                StartBattle.S.battleIsOver = true;
                break;

            }

            GameObject.Find ("Player's_GUI").GetComponent<GUIText>().text = ("Hp : " + playersPoke.hp);
			GameObject.Find ("Oponent's_GUI").GetComponent<GUIText>().text = ("Hp : " + Oponent.hp);

			if(playersTurn)
			{
				Debug.Log ("Players Turn");
				PlayerTurn(playersPoke , Oponent);
				//playersTurn = false;
			}
			//yield return new WaitForSeconds(5);
            yield return StartCoroutine(WaitForKeyDown(KeyCode.A));
            if (!playersTurn)
			{
				Debug.Log ("Oponent's Turn");
				OponentTurn(playersPoke , Oponent);
                yield return new WaitForSeconds(2);

            }
          

		}
        Debug.Log("Battle is Over");
        StartBattle.S.EndBattle();
        // alive = true;
        //yield return null;
        //BATTLE IS DONE

    }

    IEnumerator WaitForKeyDown(KeyCode keyCode)
    {
        while (!Input.GetKeyDown(keyCode))
            yield return null;
    }


    public void PlayerTurn(Pokemon playersPoke, Pokemon oponentsPoke)
	{
		BattleMenu.S.SelectOption (false, oponentsPoke, true); 
	}

	public void OponentTurn(Pokemon playersPoke, Pokemon oponentsPoke)
	{
		playersTurn = true;
		Debug.Log ("Oponent always attacks!");
		Debug.Log (oponentsPoke.pokeName + " Used " + oponentsPoke.move1);
		Damage (playersPoke, oponentsPoke.move1);
	}

	public void Damage(Pokemon objective, Move move)
	{
        //Logic for Super effective/Not very efective + misses
        int willhit = Random.Range(0, 101);
        int mult = 1;
        if (willhit - move.accuracy > 0)
        {
            Debug.Log("Attack missed!");
        }
        else
        {
            mult = SuperEffective(objective.type, move.type);
            Debug.Log(objective.pokeName + " Took " + move.damage + " from " + move.moveName);
            objective.hp -= move.damage*mult;
        }
    }
    public int SuperEffective(string target, string move)
    {
        if (target == "Normal" && move == "Fight")
        {
            Debug.Log("SUPER EFECTIVE");
            return 2;
        }
        else return 1;
    }

}
