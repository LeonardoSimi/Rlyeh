using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnabler : MonoBehaviour {

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (this.tag == "Enemy")
        {
            this.GetComponent<EnemyAI>().enabled = true;
        }
        else if (this.tag == "FriendlyEnemy")
        {
            this.GetComponent<FriendlyEnemyAI>().enabled = true;
        }
	}
}
