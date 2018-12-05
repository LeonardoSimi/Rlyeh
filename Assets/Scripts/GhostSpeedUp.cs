using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpeedUp : MonoBehaviour {

    public EnemyAI enemyAI;

	// Use this for initialization
	void Start () {
        enemyAI = GetComponent<EnemyAI>();
	}
	
	// Update is called once per frame
	void Update () {
        if (enemyAI.playerFound)
        {
            enemyAI._speed += 3;
            this.enabled = false;
        }
	}

}
