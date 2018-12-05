using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehavior : MonoBehaviour {

    public float Speed = 10.0f;

    public Player player;

    Vector3 pos;
    Vector3 velocity;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();

        if (player.isRight == true)
        {

            velocity = new Vector3(Speed * 1 * Time.deltaTime, 0, 0);


        }

        else if (player.isLeft == true)
        {

            velocity = new Vector3(Speed * -1 * Time.deltaTime, 0, 0);

        }

    }


    void Awake()
    {
        pos = transform.position;
        velocity = new Vector3(Speed * Time.deltaTime, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {

        pos += velocity;
        transform.position = pos;

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        /*if (other.tag == "Enemy")
        {

            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }*/
        if (other.tag == "Ground")
        {
            Destroy(this.gameObject);
        }

    }
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }


}



