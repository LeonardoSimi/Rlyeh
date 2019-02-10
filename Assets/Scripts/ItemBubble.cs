using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBubble : MonoBehaviour
{

    public GameObject item_Bubble;
    public int quantity;
    //public bool canUse; //accedi da inventorylist
    //private bool enemyFound;
    [SerializeField]
    private bool oneTime;
    public Player player;
    private float cooldown = 3.0f;
   // private BoxCollider2D originalColl;

    // Use this for initialization
    void Start()
    {
        oneTime = false;
        quantity = 0;
        player = GameObject.Find("Player").GetComponent<Player>();

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) //PROVVISORIO
        {
            if (oneTime == false)
            {
                if (quantity > 0)
                {
                    quantity = quantity - 1;
                    StartCoroutine(bubbleUse());
                    if (quantity < 0)
                    {
                        quantity = 0;
                    }
                }
            }
        }

        Debug.Log(player.coll.size);
        Debug.Log(player.tag);
    }

   /* void itemBubbleUse()
    {
        if (quantity > 0)
        {
            //if (canUse)
            //{
                //COROUTINE
                //animazione gonfiaggio
                player.tag = "Bubble";
                oneTime = true;

                if (oneTime)
                {
                    player.coll.size = player.coll.size * 2;
                    oneTime = false;
                }
                else
                {
                    player.coll.size = originalColl.size;
                }
            //}
        }
    }*/

    IEnumerator bubbleUse() //public?
    {
        oneTime = true;
        player.invulnerable = true;
        player.invulTime = cooldown;
        player.coll.size = player.coll.size * 2;
        player.tag = "Bubble";
        yield return new WaitForSeconds(cooldown);
        Debug.Log("3 secondi passati");
        player.coll.size = player.originalColl.size;
        player.invulnerable = false;
        player.tag = "player";
        yield return new WaitForSeconds(cooldown);
        oneTime = false;
        Debug.Log("finito");
    }
}
