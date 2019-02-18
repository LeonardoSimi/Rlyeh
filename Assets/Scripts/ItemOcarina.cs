using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOcarina : MonoBehaviour
{

    public int quantity;
    [SerializeField]
    private bool oneTime;
    public Player player;
    public EnemyAI enemyAI;
    public float cooldown;
    private float minDist;
    [SerializeField]
    private CircleCollider2D coll;


    // Use this for initialization
    void Start()
    {

        minDist = 15.0f;
        cooldown = 1.0f;
        oneTime = false;
        Player player = this.GetComponent<Player>();
        
        //CircleCollider2D coll = this.GetComponent<CircleCollider2D>();
        coll.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyAI enemyAI = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyAI>();
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (quantity > 0)
            {
                StartCoroutine(OcarinaUse());
            }
        }
        if (quantity < 0)
        {
            quantity = 0;
        }
        /*if (oneTime == true && enemyAI.hitThunder == false)
        {
            player.hitsTaken = player.hitsTaken - 1;
            Debug.Log("Tuono a vuoto");
        }*/
    }

    private IEnumerator OcarinaUse()
    {
        if (quantity > 0)
        {
            if (oneTime == false)
            {
                quantity = quantity - 1;
                oneTime = true;
                coll.enabled = true;
                yield return new WaitForEndOfFrame();
                if (enemyAI != null)
                {
                    enemyAI.hitThunder = false;
                }
                yield return new WaitForSeconds(cooldown);
                coll.enabled = false;
                oneTime = false;
            }

            if (oneTime == true && enemyAI.hitThunder == false)
            {
                player.hitsTaken = player.hitsTaken - 1;
                Debug.Log("Tuono a vuoto");
                coll.enabled = false;
            }
        }
        }
    }

