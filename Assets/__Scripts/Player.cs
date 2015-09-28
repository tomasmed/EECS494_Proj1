using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Direction
{
    down,
    left, 
    up,
    right
}


public class Player : MonoBehaviour {

	public static Player S;

    public float moveSpeed;
    public int tileSize;
    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;

    public SpriteRenderer sprend;


    public bool              _____________________________;

    public bool moving = false;
    public Vector3 targetPos;
    public Direction direction;
    public Vector3 moveVec;
    public RaycastHit hitInfo;


    public string[] inventory = new string[50];
    public int currentInvSize = 0;
    public int newItems = 0;


    void Awake(){
		S = this;
	}

	void Start(){
        sprend = gameObject.GetComponent<SpriteRenderer>();
	}

	void FixedUpdate(){
        //If the Player is not moving find the input and change his direction to that side
        // Because of the if-else costruction there will be a precedence order within the movement scheme  --------------------- Maybe change to different construction
        if (!moving && !MainScript.S.inDialog && !MainScript.S.paused && !MainScript.S.inBattle)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                CheckForAction(); // HERE IS WHERE you add Items-------------------------------------------------------------
            }


            if (Input.GetKey(KeyCode.RightArrow))
            {
                moveVec = Vector3.right;
                direction = Direction.right;
                sprend.sprite = rightSprite;
                moving = true;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                moveVec = Vector3.left;
                direction = Direction.left;
                sprend.sprite = leftSprite;
                moving = true;
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                moveVec = Vector3.up;
                direction = Direction.up;
                sprend.sprite = upSprite;
                moving = true;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                moveVec = Vector3.down;
                direction = Direction.down;
                sprend.sprite = downSprite;
                moving = true;
            }
            else
            {
                moveVec = Vector3.zero;
                moving = false;
            }
            if( (Physics.Raycast(GetRay(), out hitInfo, 1f, GetLayerMask(new string[] { "Immovable" , "NPC" ,"WaterTile" , "Item" , "Trainer"}) ) ) || (Physics.Raycast(GetRay(), out hitInfo, 1f, GetLayerMask(new string[] { "Ledge" })) && !(direction == Direction.down)))
            //if (Physics.Raycast(GetRay(), 1f, GetLayerMask(new string[] { "Immovable,NPC"}) ) )
            {
                moveVec = Vector3.zero;
                moving = false;
            }
            else if (Physics.Raycast(GetRay(), out hitInfo, 1f, GetLayerMask(new string[] { "Ledge" })) && direction == Direction.down)
            {
                moveVec = Vector3.down;
                direction = Direction.down;
                sprend.sprite = downSprite;
                moving = true;
                targetPos = transform.position + moveVec;
                transform.position += ((targetPos - transform.position).normalized * moveSpeed * Time.fixedDeltaTime).normalized;
            }
            else if (Physics.Raycast(GetRay(), out hitInfo, 1f, GetLayerMask(new string[] { "Grass" })))
            {
                int chance = Random.Range(0, 15);
                if (chance < 2 && moving)
                {
                    MainScript.S.inBattle = true;
					List<Pokemon> enemyPoke = new List<Pokemon>{};
                    Pokemon wildPoke = AreaPokemon.S.WildPoke();
					enemyPoke.Add(wildPoke);
					StartBattle.S.SetArena(enemyPoke, "A wild pokemon appeared");
                    //Destroy(wildPoke);
                }
            }
                //
                targetPos = this.transform.position + moveVec;
        }
        // If player is ready to move (moving == true) move him by a unit in the obj direction
        else
        {
            // If we would overshoot our target by moving too fast 
            if((targetPos - transform.position).magnitude < moveSpeed*Time.fixedDeltaTime)
            {
                transform.position = targetPos;
                moving = false;
            }
            else
            {
                // We can move
                transform.position += (targetPos - transform.position).normalized * moveSpeed * Time.fixedDeltaTime;
            }
        }



	}

    public void CheckForAction()
    {
        if (Physics.Raycast(GetRay(), out hitInfo,  1f, GetLayerMask(new string[] { "NPC" })))
        {
            NPC npc = hitInfo.collider.gameObject.GetComponent<NPC>();
            npc.FacePlayer(direction);
            npc.PlayDialog();
        }
        else if (Physics.Raycast(GetRay(), out hitInfo, 1f, GetLayerMask(new string[] { "Trainer" })))
        {
            Trainer trainer = hitInfo.collider.gameObject.GetComponent<Trainer>();
            trainer.FacePlayer(direction);
            trainer.PlayDialog();
            MainScript.S.inTrainerDialog = true;
        }
        else if (Physics.Raycast(GetRay(), out hitInfo, 1f, GetLayerMask(new string[] { "Item" })))
        {
            Item item = hitInfo.collider.gameObject.GetComponent<Item>();
            item.sprend.sprite = null;
            item.PlayIDialog();
        }
    }


    Ray GetRay()
    {
        switch(direction)
        {
            case Direction.down:
                return new Ray(transform.position, Vector3.down);
               
            case Direction.left:
                return new Ray(transform.position, Vector3.left);
                
            case Direction.right:
                return new Ray(transform.position, Vector3.right);
       
            case Direction.up:
                return new Ray(transform.position, Vector3.up);
            default: return new Ray();

        }
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

    public void MoveThroughDoor(Vector3 doorLoc)
    {
        if (doorLoc.z <= 0) doorLoc.z = transform.position.z;

        moving = false;
        moveVec = Vector3.zero;
        transform.position = doorLoc;
    }

}
