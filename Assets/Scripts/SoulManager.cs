using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulManager : MonoBehaviour {

    public Player player;
    
	// Use this for initialization
	void Start () {

        player = GameObject.Find("Player").GetComponent<Player>();

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player")
        {
            player.Souls += 1;
            Destroy(this.gameObject);
        }

    }
}
