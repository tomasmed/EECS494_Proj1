using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    public string name;

    public Sprite sprite;
    public SpriteRenderer sprend;
	public bool isKeyItem;

    public bool ____________;

    public string speech;

    public void PlayIDialog()
    {

        speech = Player.S.name + " found a " + name + "!";
        print(speech);
        DialogScript.S.gameObject.SetActive(true);
        Color noAlpha = GameObject.Find("DialogBackground").GetComponent<GUITexture>().color;
        noAlpha.a = 255;
        GameObject.Find("DialogBackground").GetComponent<GUITexture>().color = noAlpha;
        DialogScript.S.ShowMessage(speech);
        Pickup();
        Player.S.newItems++;
    }

    public void Pickup() {
		//GameObject.Find("Inventory")

		Inventory.S.itemsInInventory.Add (this);
		gameObject.GetComponent<BoxCollider> ().enabled = false;
		sprend.sprite = null;
		ItemMenu.S.Update_Menu ();

        //Player.S.inventory[Player.S.currentInvSize] = name;
        //Player.S.currentInvSize++;
    }


    // Use this for initialization
    void Start () {
        sprend = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	public virtual void Use()
	{

	}
}
