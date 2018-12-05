using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostExplode : MonoBehaviour {

    public EnemyAI enemyAI;
    public Transform playerT;
    public Sprite explosionSprite; //TEMP
    private SpriteRenderer spriteRenderer;
    public CircleCollider2D explosionCollider;

	// Use this for initialization
	void Start () {

        enemyAI = this.GetComponent<EnemyAI>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        explosionCollider.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        Dis();
	}

    void Dis()
    {
        if (playerT)
        {
            float dist = Vector3.Distance(playerT.position, transform.position);
            //print("Distance to player: " + dist);
            if (dist <= 13.0f)
            {
                Debug.Log("BOOM");
                spriteRenderer.sprite = explosionSprite;
                this.tag = "GhostExplosion";
                enemyAI.enabled = false;
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
