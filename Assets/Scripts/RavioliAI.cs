using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RavioliAI : MonoBehaviour {

    public Player player;
    public EnemyAI enemyAI;
    public GameObject tinyRavioli;
    private Rigidbody2D _rigidBody2D;
    private bool groundColl;
    [SerializeField]
    public float jumpHeight;
    public LayerMask groundLayer;
    private bool isJumping;
    private bool canJump;
    private Vector2 randomDir;
    [SerializeField]
    private GameObject miniSlime;

    // Use this for initialization
    void Start() {
        player = gameObject.GetComponent<Player>();
        enemyAI = this.GetComponent<EnemyAI>();
        //StartCoroutine(startingCoroutine());     
    }

    private void Awake()
    {
        _rigidBody2D = this.GetComponent<Rigidbody2D>();
        StartCoroutine(jumpCooldown());
        canJump = false;

    }

    private void Update()
    {
        randomDir = new Vector2(Random.Range(1, -2), 0);
        if (canJump && !isJumping)
        {
            _rigidBody2D.velocity = transform.up * jumpHeight;
            transform.Translate(randomDir * Time.deltaTime);
            
            //isJumping = true;
        }

        Debug.Log("Ravioli is jumping" + isJumping);
        Debug.Log("Ravioli can jump " + canJump);
        Debug.Log(randomDir);

        enemyAI.canMove = false;

        //Wander();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

        private IEnumerator jumpCooldown()
    {
        while (true)
        {
            canJump = true;
            yield return new WaitForSeconds(0.2f);
            canJump = false;
            yield return new WaitForSeconds(2f);

        }
    }

    void OnDestroy()
    {
        Instantiate(miniSlime, transform.position, Quaternion.identity);
        Instantiate(miniSlime, transform.position, Quaternion.identity);
        Instantiate(miniSlime, transform.position, Quaternion.identity);
        Instantiate(miniSlime, transform.position, Quaternion.identity);

    }

}

