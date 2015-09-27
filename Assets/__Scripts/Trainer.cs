using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Trainer : MonoBehaviour {
    public string speech;
    public bool trainer;
    public float moveSpeed;

    public RaycastHit hitInfo;
    public NPCDirection direction;
    public Vector3 targetPos;

    public Sprite rightSprite;
    public Sprite leftSprite;
    public Sprite upSprite;
    public Sprite downSprite;

    public SpriteRenderer sprend;


    public List<Pokemon> trainersPoke;

    // Use this for initialization
    void Start()
    {
        sprend = gameObject.GetComponent<SpriteRenderer>();
    }

    public void PlayDialog()
    {
        print(speech);
        DialogScript.S.gameObject.SetActive(true);
        Color noAlpha = GameObject.Find("DialogBackground").GetComponent<GUITexture>().color;
        noAlpha.a = 255;
        GameObject.Find("DialogBackground").GetComponent<GUITexture>().color = noAlpha;
        DialogScript.S.ShowMessage(speech);
        MainScript.S.inTrainerDialog = true;
    }

    public void FacePlayer(Direction playerDir)
    {
        switch (playerDir)
        {
            case Direction.right:
                sprend.sprite = leftSprite;
                break;
            case Direction.left:
                sprend.sprite = rightSprite;
                break;
            case Direction.up:
                sprend.sprite = downSprite;
                break;
            case Direction.down:
                sprend.sprite = upSprite;
                break;
        }
    }

    /*public void Battle(){
		if (trainer && Main.S.inDialog && Input.GetKeyDown (KeyCode.X)) {
			Main.S.inBattle = true;
            Dialog.S.HideDialogBox();
		}
	}*/


    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(GetRay(), out hitInfo, 3f, GetLayerMask(new string[] { "Player" })) && !MainScript.S.inBattle)
        {
            FacePlayer(Player.S.direction);
            Vector3 npcvec;
            switch (Player.S.direction)
            {
                case Direction.right:
                    npcvec = Vector3.left;
                    direction = NPCDirection.left;
                    break;
                case Direction.left:
                    npcvec = Vector3.right;
                    direction = NPCDirection.right;
                    break;
                case Direction.up:
                    npcvec = Vector3.down;
                    direction = NPCDirection.down;
                    break;
                case Direction.down:
                    npcvec = Vector3.up;
                    direction = NPCDirection.up;
                    break;
                default:
                    npcvec = Vector3.zero;
                    break;
            }
            targetPos = pos + npcvec;
            pos += (targetPos - pos).normalized * moveSpeed * Time.fixedDeltaTime;
            PlayDialog();

            MainScript.S.inBattle = true;
            StartBattle.S.SetArena(trainersPoke, "Trainer wants to battle!");

        }
        /*if (trainer && Main.S.inDialog && Input.GetKeyDown(KeyCode.X))
        {
            Main.S.inBattle = true;
            Dialog.S.HideDialogBox();
        }*/

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
