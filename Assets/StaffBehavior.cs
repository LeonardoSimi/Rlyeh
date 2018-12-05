using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StaffBehavior : MonoBehaviour {

    public Player player;

    [SerializeField]
    private CircleCollider2D coll;
    [SerializeField]
    private SpriteRenderer staffSpr;

    private float _canFire = 0.0f;
    [SerializeField]
    private float _fireRate = 0.05f;

    // Use this for initialization
    void Start () {

        player = this.GetComponent<Player>();
        coll.enabled = false;
        staffSpr.enabled = false;
    }

    // Update is called once per frame
    void Update () {

        if (player.hasStaff)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (Time.time > _canFire)
                {
                    StartCoroutine(activateCollider());                   
                }
            }
        }
	}

    private IEnumerator activateCollider()
    {
        Debug.Log("Start staff coroutine");
        coll.enabled = true;
        staffSpr.enabled = true;
        yield return new WaitForSeconds(0.25f);
        _canFire = Time.time + _fireRate;
        Debug.Log("deactivating coll");
        coll.enabled = false;
        staffSpr.enabled = false;
    }
}
