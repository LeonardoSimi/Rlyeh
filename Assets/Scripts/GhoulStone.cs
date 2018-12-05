using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhoulStone : MonoBehaviour {

    public EnemyAI enemyai;
    private float _canFire = 0.0f;
    private float _fireRate = 1.5f;

    public GameObject headStone;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        ShootStone();	
	}

    void ShootStone()
    {
        if (enemyai.playerFound == true)
        {
                if (Time.time > _canFire)
                {

                    Instantiate(headStone, transform.position + new Vector3(2f, 0, 0), Quaternion.identity);

                    _canFire = Time.time + _fireRate;
                }
            }
        
    }

}
