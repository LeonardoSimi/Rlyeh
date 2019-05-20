using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RavioliAI : MonoBehaviour {

    public Player player;
    public EnemyAI enemyAI;
    public GameObject tinyRavioli;
    private Rigidbody2D rb;
    private bool groundColl;
    [SerializeField]
    private float jumpFloat;
    public LayerMask groundLayer;
    private bool hasStarted;
    private Vector2 startingY;
    private float step;

    // Use this for initialization
    void Start () {
        player = gameObject.GetComponent<Player>();
        enemyAI = this.GetComponent<EnemyAI>();
        rb = this.GetComponent<Rigidbody2D>();
        //StartCoroutine(startingCoroutine());
    }

    private void Awake()
    {
        startingY = new Vector2(0, this.transform.position.y);
        hasStarted = false;
        groundColl = false;
    }

    // Update is called once per frame
    void Update () {
        jumpingMovement();
        Debug.Log("ravioli ground " + groundColl);
        IsGrounded();
        step = enemyAI._speed * Time.deltaTime;
    }

    void jumpingMovement()
    {
        if (enemyAI.canMove)
        {
            StartCoroutine(jumpCoroutine());
        }

        if (groundColl)
        {
            StartCoroutine(jumpCooldown());
        }
    }

   

    IEnumerator jumpCoroutine()
    {
        while (groundColl == false)
        {
            rb.velocity = new Vector2(1f, 1f);
            yield return new WaitForSeconds(0.5f);
            //rb.velocity = new Vector2(0.0f, -1f); lascia commentato
            transform.position = Vector2.MoveTowards(transform.position, startingY, step*2);
            yield return new WaitForSeconds(0.5f);
        }

    }

    IEnumerator jumpCooldown()
    {
            rb.velocity = new Vector2(0.0f, -0.0f);
            transform.position = transform.position;
            enemyAI.canMove = false;
            yield return new WaitForSeconds(jumpFloat);
            enemyAI.canMove = true;
            StartCoroutine(startingCoroutine());
    }

    IEnumerator startingCoroutine()
    {
        hasStarted = false;
        yield return new WaitForSeconds(0.2f);
        hasStarted = true;
    }

    bool IsGrounded()
    {
        if (hasStarted == true)
        {
            Vector2 position = this.transform.position;
            Vector2 direction = Vector2.down;
            float distance = 1.6f;

            RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
            if (hit.collider != null)
            {
                Debug.Log("ravioli ground true");
                groundColl = true;
                return true;
            }
            Debug.Log("ravioli ground false");
            groundColl = false;
            return false;
        }
        else
        {
            groundColl = false;
        }
        return false;
    }
    
}
