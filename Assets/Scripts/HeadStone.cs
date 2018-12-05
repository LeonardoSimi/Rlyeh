using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadStone : MonoBehaviour {

    public GhoulStone ghoulStone;
    [SerializeField]
    private bool _isOnGround;
    [SerializeField]
    private bool playerHit;
    [SerializeField]
    private float radius = 5f;

    public Player player;

    [SerializeField]
    private GameObject Ghost;

    public ParticleSystem spawnParticles;

    //public Renderer rend;

    // Use this for initialization
    void Start () {
        //rend = GetComponent<Renderer>();
        //rend.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isOnGround = true;
            StartCoroutine(Destruction());
        }
    }

    IEnumerator Destruction()
    {
        Instantiate(spawnParticles, transform.position, Quaternion.identity);

        yield return new WaitForSeconds(1.0f);
        Destroy(this.gameObject);
    }

    void OnDestroy()
    {

        Instantiate(Ghost, transform.position, Quaternion.identity);
    }

    /*void castShock()
    {
        if (_isOnGround)
        {
            rend.enabled = true;
        }
    }*/
    }
