using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Leaf : MonoBehaviour {

    public float Speed;
    public Player player;
    public WindTree windTree;

    private Vector3 dir;
    private Vector3 pLastPos;

    // Use this for initialization
    void Start()
    {

        player = GameObject.Find("Player").GetComponent<Player>();
        windTree = GameObject.Find("WindTree").GetComponent<WindTree>();
        pLastPos = new Vector3(player.transform.position.x, windTree.transform.position.y - 1, windTree.transform.position.z);

    }

    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, pLastPos, Speed * Time.deltaTime);

    }

    void getDir()
    {
        //dir = 
        // dir.y = 0.0f; //not changing y dir
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
        else if (other.tag == "player")
        {
            Destroy(this.gameObject);
            StartCoroutine(pDamage());
        }
    }

    IEnumerator pDamage()
    {
        player.pLives = player.pLives - 1;
        yield return new WaitForSeconds(2.0f);
    }
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}

