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
            Debug.Log("enemy tag " + this.tag);
            this.GetComponent<EnemyAI>().enabled = true;
            this.GetComponent<FriendlyEnemyAI>().enabled = false;

        }
        else if (this.tag == "FriendlyEnemy")
        {
            Debug.Log("enemy tag " + this.tag);
            this.GetComponent<FriendlyEnemyAI>().enabled = true;
            this.GetComponent<EnemyAI>().enabled = false;
        }
    }
}
