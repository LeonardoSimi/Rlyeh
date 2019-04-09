using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour {

    public enum State { Good, Evil };
    public State Status;

    public GameObject Soul;
    public GameObject[] soulInt;

    public Player player;

    // Use this for initialization
    void Start () {

        player = GameObject.Find("Player").GetComponent<Player>();

    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player")
        {
            Destroy(this.gameObject);
        }
    }

    void OnDestroy()
    {
        if (Status == State.Good)
        {
            soulInt = new GameObject[Random.Range(3, 6)];
            for (int i = 0; i < soulInt.Length; i++)
            {
                GameObject clone = (GameObject)Instantiate(Soul, Vector3.zero, Quaternion.identity);
                soulInt[i] = clone;
            }
        }

        else if (Status == State.Evil)
        {
            player.hitsTaken = player.hitsTaken - 1;

        }
    }
}
