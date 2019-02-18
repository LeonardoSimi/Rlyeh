using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScoop : MonoBehaviour {

    public GameObject item_Scoop;
    public int quantity;
    [SerializeField]
    private bool oneTime;
    private float minDist;
    //public EnemyAI enemyAI;
    public float cooldown = 7.0f;
    private bool enemyFound;
    public Player player;

    //private CircleCollider2D t_collider;

    // Use this for initialization
    void Start () {

        quantity = 3; //TEMP
        enemyFound = false;
        minDist = 3.0f;
        oneTime = false;
        //enemyAI = GameObject.Find("EnemyAI").GetComponent<EnemyAI>();
        player = GameObject.Find("Player").GetComponent<Player>();

    }

    // Update is called once per frame
    void Update () {

        Debug.Log(enemyFound);
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (quantity > 0)
            {
                StartCoroutine(ScoopUse());
            }
        }
        if (quantity < 0)
        {
            quantity = 0;
        }
        
	}

    IEnumerator ScoopUse()
    {
        Debug.Log("SCOOP USED");
        oneTime = true;
        quantity = quantity - 1;

        CircleCollider2D t_collider = new CircleCollider2D();
        t_collider = this.gameObject.AddComponent<CircleCollider2D>(); //attach to a gameobject or it wont compile
        t_collider.offset = new Vector2(player.transform.position.x, player.transform.position.y);
        t_collider.radius = minDist;
        t_collider.isTrigger = true;
        yield return new WaitForSeconds(0.3f);
        Debug.Log("finito SCOOP");
        Destroy(t_collider);
        //yield return new WaitForSeconds(cooldown);
        oneTime = false;
        enemyFound = false;

    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" || other.tag == "IdleTag")
        {
            enemyFound = true;
            other.tag = "FriendlyEnemy";
        }
    }
}
