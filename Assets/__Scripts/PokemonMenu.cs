using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PokemonMenu : MonoBehaviour
{

    static public PokemonMenu S;
    public int activePokemon;
    public List<GameObject> playerPokemon;

    void Awake()
    {
        S = this;
    }


    // Use this for initialization
    void Start()
    {
        bool first = true;
        activePokemon = 0;
   
        foreach (Transform child in transform)
        {
            playerPokemon.Add(child.gameObject);
           
        }
        for (int i =0; i  <  Party.S.pokemonInParty.Count ; i++)
        //foreach (GameObject go in playerPokemon)
        {
            GameObject go = playerPokemon[i];

            GUIText itemText = go.GetComponent<GUIText>();
            itemText.text = Party.S.pokemonInParty[i].pokeName;
            
            if (first) itemText.color = Color.red;
            first = false;
        }


        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            gameObject.SetActive(false);
            print("Returning to main menu");
            Menu.S.gameObject.SetActive(true);
            //MainScript.S.paused = false;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                switch (activePokemon)
                {
                    case 0:
                        print("Selected : " + Party.S.pokemonInParty[0].pokeName);
                        break;
                    case 1:
                        print("Selected : " + Party.S.pokemonInParty[1].pokeName);
                        break;
                    case 2:
                        print("Selected : " + Party.S.pokemonInParty[2].pokeName);
                        break;
                    case 3:
                        print("Selected : " + Party.S.pokemonInParty[3].pokeName);
                        break;
                    case 4:
                        print("Selected : " + Party.S.pokemonInParty[4].pokeName);
                        break;
                    case 5:
                        print("Selected : " + Party.S.pokemonInParty[5].pokeName);
                        break;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveMenuDown();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveMenuUp();
        }


    }

    public void MoveMenuDown()
    {
        playerPokemon[activePokemon].GetComponent<GUIText>().color = Color.black;
        activePokemon = activePokemon == playerPokemon.Count - 1 ? 0 : ++activePokemon;
        playerPokemon[activePokemon].GetComponent<GUIText>().color = Color.red;
    }
    public void MoveMenuUp()
    {
        playerPokemon[activePokemon].GetComponent<GUIText>().color = Color.black;
        activePokemon = activePokemon == 0 ? playerPokemon.Count - 1 : --activePokemon;
        playerPokemon[activePokemon].GetComponent<GUIText>().color = Color.red;
    }

}