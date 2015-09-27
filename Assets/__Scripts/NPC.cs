using UnityEngine;
using System.Collections;

public enum NPCDirection
{
    down,
    left,
    up,
    right
}


public class NPC : MonoBehaviour {

    public bool isTrainer = false;
    public string speech;

    public float moveSpeed;
    public int movementPattern;


    public RaycastHit hitInfo;
    public NPCDirection direction;
    public Vector3 targetPos;
    public Vector3 npcvec;

    public GameObject action;
    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite rightSprite;
    public Sprite leftSprite;

    public SpriteRenderer sprend;

    public bool ______________________________; 

	// Use this for initialization
	void Start () {
        sprend = gameObject.GetComponent<SpriteRenderer>();
	}


    public void PlayDialog()
    {
        print(speech);
        DialogScript.S.gameObject.SetActive(true);
        Color noAlpha = GameObject.Find("DialogBackground").GetComponent<GUITexture>().color;
        noAlpha.a = 255;
        GameObject.Find("DialogBackground").GetComponent<GUITexture>().color = noAlpha;


        //Here is where we ge the next part of the speech
        DialogScript.S.ShowMessage(speech);
        if (isTrainer)
        {
            //Do the stuff id its a trainer
        }

    }

    public void FacePlayer(Direction playerDir)
    {
        switch(playerDir)
        {
            case Direction.down:
                sprend.sprite = upSprite;
                break;
            case Direction.up:
                sprend.sprite = downSprite;
                break;
            case Direction.right:
                sprend.sprite = leftSprite;
                break;
            case Direction.left:
                sprend.sprite = rightSprite;
                break;
        }
    }
	
	// Update is called once per frame
    void Update () {
	
	    }

    int GetLayerMask(string[] layerNames)
    {
        int layerMask = 0;

        foreach (string layer in layerNames)
        {
            layerMask = layerMask | (1 << LayerMask.NameToLayer(layer));
        }

        return layerMask;
    }

    public Vector3 pos
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    Ray GetRay()
    {
        switch (direction)
        {
            case NPCDirection.right:
                return new Ray(pos, Vector3.right);
            case NPCDirection.left:
                return new Ray(pos, Vector3.left);
            case NPCDirection.up:
                return new Ray(pos, Vector3.up);
            case NPCDirection.down:
                return new Ray(pos, Vector3.down);
            default:
                return new Ray();
        }
    }

}