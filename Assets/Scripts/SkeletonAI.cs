using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAI : MonoBehaviour {

    public EnemyAI enemyAI;
    public GameObject boneProjectile;
    private float _canFire = 0.0f;
    private float _fireRate = 1.7f;

    // Use this for initialization
    void Start () {

        enemyAI = this.GetComponent<EnemyAI>();

	}
	
	// Update is called once per frame
	void Update () {

        ShootBone();

	}

    void ShootBone()
    {
        if (enemyAI.playerFound)
        {
            if (Time.time > _canFire)
            {
                StartCoroutine(boneRoutine());
                _canFire = Time.time + _fireRate;
            }
        }
    }

    IEnumerator boneRoutine()
    {
        Instantiate(boneProjectile, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1.5f);

    }
}
