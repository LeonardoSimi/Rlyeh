using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpriteChange : MonoBehaviour {

    public Sprite regularMoffi;
    public Sprite rockMoffi;
    public Player player;
    public bool rockChange;

    private Rigidbody2D rb;
    private float grav;
    private float _speed = 1.5f;

	// Use this for initialization
	void Start () {
        player = this.GetComponent<Player>();
        rockChange = false;
        rb = this.GetComponent<Rigidbody2D>();
        grav = rb.gravityScale;
	}
	
	// Update is called once per frame
	void Update () {
        changeSprite();
        if (player.hasRock)
        {
            //TODO ammos
            rockChange = true;
        }
        else
        { rockChange = false; }
	}

    void changeSprite()
    {
        if (rockChange)
        {
            rb.gravityScale = 10;
            this.GetComponent<SpriteRenderer>().sprite = rockMoffi;
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * _speed * horizontalInput * Time.deltaTime);
        }
        else if (rockChange == false)
        {
            rb.gravityScale = grav;
            this.GetComponent<SpriteRenderer>().sprite = regularMoffi;
        }
    }

}
