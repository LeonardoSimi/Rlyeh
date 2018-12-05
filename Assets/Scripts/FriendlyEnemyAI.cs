using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyEnemyAI : MonoBehaviour {

    public Player player;
    private Vector2 pos;
	// Use this for initialization
	void Start () {

        player = GameObject.Find("Player").GetComponent<Player>();

    }

    // Update is called once per frame
    void Update () {

        if (this.tag != "FriendlyEnemy")
        {
            this.enabled = false;
        }
        pos.x = player.transform.position.x - 2;
        pos.y = player.transform.position.y;
        transform.position = Vector3.MoveTowards(transform.position, pos, .08f);
    }

}
