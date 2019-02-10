using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostExplode : MonoBehaviour {

    public EnemyAI enemyAI;
    public Transform playerT;
    public Sprite explosionSprite; //TEMP
    private SpriteRenderer spriteRenderer;
    public CircleCollider2D explosionCollider;
    private float chargeUpTime;

	// Use this for initialization
	void Start () {
        chargeUpTime = 1.2f;
        enemyAI = this.GetComponent<EnemyAI>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        explosionCollider.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (this.tag == "Enemy")
        {
            StartCoroutine(Dis());
        }
    }

    IEnumerator Dis()
    {
        if (playerT)
        {
            float dist = Vector3.Distance(playerT.position, transform.position);
            //print("Distance to player: " + dist);
            if (dist <= 13.0f)
            {
                this.tag = "IdleTag"; //no damage to player while exploding
                enemyAI.canMove = false;
                yield return new WaitForSeconds(chargeUpTime);
                Debug.Log("BOOM");
                spriteRenderer.sprite = explosionSprite;
                this.tag = "GhostExplosion";
                enemyAI.enabled = false;
                yield return new WaitForSeconds(1f);
                this.tag = "IdleTag";
                StartCoroutine(colliderSpawn());
                
            }
        }
    }

    IEnumerator colliderSpawn()
    {
        explosionCollider.enabled = true;
        yield return new WaitForSeconds(0.65f);
        Destroy(this.gameObject);
    }
}
