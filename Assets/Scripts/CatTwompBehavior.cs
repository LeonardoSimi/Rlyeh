using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatTwompBehavior : MonoBehaviour {

    public EnemyAI enemyAI;
    private Rigidbody2D rb;
    private float gravStd = 3.5f;
    private float gravUp = -0.3f;
    private float gravDown = 6.5f;

    [SerializeField]
    private float cooldown;
    public GameObject twompObj;
    public Transform AOEtwomp;

	// Use this for initialization
	void Start () {

        enemyAI = this.GetComponent <EnemyAI>();
        rb = this.GetComponent<Rigidbody2D>();
        rb.gravityScale = gravStd;
        twompObj.SetActive(false);
    }

    // Update is called once per frame
    void Update () {

        twompAttack();


	}

    void twompAttack()
    {
        if (enemyAI.playerFound)
        {
            StartCoroutine(attackCoroutine());
        }
    }

    private IEnumerator attackCoroutine()
    {
        rb.gravityScale = gravUp;
        yield return new WaitForSeconds(2.5f);
        rb.gravityScale = gravDown;
        yield return new WaitForSeconds(0.7f);
        twompObj.SetActive(true);
        AOEtwomp.parent = null;
        Destroy(this.gameObject);
    }

    /*private void OnDestroy()
    {
        Destroy(this.gameObject);
    }*/

}

