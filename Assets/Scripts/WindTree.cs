using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindTree : MonoBehaviour {

    public Player player;
    public EnemyAI enemyAI;
    public Rigidbody2D playerRb;
    public GameObject windArea;
    [SerializeField]
    private bool windActive;
    public GameObject leafProj;
    public GameObject[] leafInt;
    private float _canFire = 0.0f;
    private float _fireRate = 0.75f;

    // Use this for initialization
    void Start () {

        player = gameObject.GetComponent <Player>();
        enemyAI = this.GetComponent<EnemyAI>();
        windArea.SetActive(false);
        windActive = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (enemyAI.playerFound)
        {
            StartCoroutine(windAttack());
        }

        if (windActive == true)
        {
            windArea.SetActive(true);
            enemyAI.canMove = false;
            if (Time.time > _canFire)
            {
                StartCoroutine(leafShoot());
                _canFire = Time.time + _fireRate;
            }
        }
        else if (windActive == false)
        {
            windArea.SetActive(false);
            enemyAI.canMove = true;
        }
    }

    IEnumerator windAttack()
    {
        Debug.Log("start wind");
        //windArea.SetActive(true);
        windActive = true;
        yield return new WaitForSeconds(4f);
        windActive = false;
        //windArea.SetActive(false);
        Debug.Log("stop wind");
        yield return new WaitForSeconds(4f);

    }

    IEnumerator leafShoot()
    {
        Debug.Log("shoot leaves");
        Instantiate(leafProj, this.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(0.5f);
    }

    //       GetComponent<Rigidbody> ().AddForce(windDirectionInVector3 * windSpeed);
}
