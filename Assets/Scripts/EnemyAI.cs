using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    public Player player;
    //public DamageText damageText;

    [SerializeField]
    private float hp;
    [SerializeField]
    private bool dps;

    float dist;

    public float selfDamage;

    Vector3 dir;

    public float _speed = 4.0f;

    public bool isDead;

    public GameObject Soul;
    public GameObject damageText;

    [SerializeField]
    private float minDist = 20.0f;

    public float delta = 1.5f; //movement max off chasing

    private Vector3 startPos;

    public bool playerFound;
    public bool enemyFound;

    public ParticleSystem explodeParticles;

    public bool canMove;


    // Use this for initialization
    void Start()
    {
        canMove = true;
        dps = false;
        player = GameObject.Find("Player").GetComponent<Player>();
        //damageText = GameObject.Find("DmgText").GetComponent<DamageText>();
    }

    void Awake()
    {
        isDead = false;
        startPos = transform.position;

    }
    // Update is called once per frame
    void Update()
    {

        distanceFromPlayer();
        //getToPlayer();
        newGetToPlayer();
        Death();

        //CRITICAL CRITICAL CRITICAL CRITICAL CRITICAL
        if (this.tag != "Enemy")
        {
            this.enabled = false;
        }
    }

    void distanceFromPlayer()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        //Debug.Log("Distance to player: " + dist);

    }

    /*private void getToPlayer()
    {
        if (dist <= minDist)
        {

            Vector3 dir = (player.transform.position - transform.position).normalized;
            dir.y = 0.0f; //not changing y dir

            transform.Translate(dir * _speed * Time.deltaTime);

        }

    }*/


    private void newGetToPlayer()
    {
        if (canMove)
        {
    
        Collider2D[] foundColliders = Physics2D.OverlapCircleAll(transform.position, minDist);

        playerFound = false;

        foreach (Collider2D coll in foundColliders)
        {
            if (coll.tag == "player")
                playerFound = true;
        }

        if (playerFound)
        {
            Vector3 dir = (player.transform.position - transform.position).normalized;
            dir.y = 0.0f; //not changing y dir

            transform.Translate(dir * _speed * Time.deltaTime);
        }

        else
        {
            Wander();
        }
    }
}



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Projectile")
        {
            selfDamage = 2;
            //Instantiate(damageText.dmgText, transform.position, Quaternion.identity);
            GameObject dmgTxt = Instantiate<GameObject>(damageText, new Vector3(transform.position.x, 0.5f, 0), Quaternion.identity);
            dmgTxt.transform.parent = this.transform;
            Destroy(other.gameObject);
            hp -= selfDamage;
        }
        else if (other.tag == "Bomb")
        {
            selfDamage = 4;
            //Instantiate(damageText.dmgText, transform.position, Quaternion.identity);
            GameObject dmgTxt = Instantiate<GameObject>(damageText, new Vector3(transform.position.x, 0.5f, 0), Quaternion.identity);
            dmgTxt.transform.parent = this.transform;
            Destroy(other.gameObject);
            hp -= selfDamage;
        }
        else if (other.tag == "Fire")
        {
            Destroy(other.gameObject);
            //Instantiate(damageText.dmgText, transform.position, Quaternion.identity);
            GameObject dmgTxt = Instantiate<GameObject>(damageText, new Vector3(transform.position.x, 0.5f, 0), Quaternion.identity);
            dmgTxt.transform.parent = this.transform;
            dps = true;
            StartCoroutine(FireDPS());
        }

        else if (other.tag == "Enemy")
        {
            transform.position = (transform.position - other.transform.position).normalized * 2 + other.transform.position;
        }

        else if (other.tag == "Staff")
        {
            selfDamage = 1;
            GameObject dmgTxt = Instantiate<GameObject>(damageText, new Vector3(transform.position.x, 0.5f, 0), Quaternion.identity);
            dmgTxt.transform.parent = this.transform;
            hp -= selfDamage;
        }

        else if (other.tag == "Bubble")
        {
            selfDamage = 8;
            GameObject dmgTxt = Instantiate<GameObject>(damageText, new Vector3(transform.position.x, 0.5f, 0), Quaternion.identity);
            dmgTxt.transform.parent = this.transform;
            hp -= selfDamage;
        }

        else if (other.tag == "FriendlyEnemy")
        {
            selfDamage = 5;
            GameObject dmgTxt = Instantiate<GameObject>(damageText, new Vector3(transform.position.x, 0.5f, 0), Quaternion.identity);
            dmgTxt.transform.parent = this.transform;
            hp -= selfDamage;
        }
    }

    private IEnumerator FireDPS()
    {
        while (dps)
        {
            selfDamage = 2;
            //Instantiate(damageText.dmgText, transform.position, Quaternion.identity);
            GameObject dmgTxt = Instantiate<GameObject>(damageText, new Vector3(transform.position.x, 0.5f, 0), Quaternion.identity);
            dmgTxt.transform.parent = this.transform;
            hp -= selfDamage;
            yield return new WaitForSeconds(1.5f);
        }
        yield return new WaitForSeconds(4.5f);
            dps = false;
    }

    private void Wander()
    {

        Vector3 v = startPos;
        v.x += delta * Mathf.Sin(Time.time * (_speed-2));
        transform.position = v;


    }

    private void Death()
    {
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        if (this.tag == "Enemy")
        {
            Instantiate(explodeParticles, transform.position, Quaternion.identity);
        }
        Instantiate(Soul, transform.position, Quaternion.identity);

    }

}
