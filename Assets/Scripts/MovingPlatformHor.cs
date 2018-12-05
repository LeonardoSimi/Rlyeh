using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformHor : MonoBehaviour {

    private Vector3 startPos;
    public float delta = 1.5f;
    [SerializeField]
    private float _speed = 2.0f;

    [SerializeField]
    private bool Horizontal;

    [SerializeField]
    private bool Vertical;

    // Use this for initialization
    void Start() {

    }
    void Awake()
    {
        startPos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (Horizontal)
        {
            Vector3 v = startPos;
            v.x += delta * Mathf.Sin(Time.time * _speed);
            transform.position = v;
        }
        else if (Vertical)
        {
            Vector3 v = startPos;
            v.y += delta * Mathf.Sin(Time.time * _speed);
            transform.position = v;
        }
        }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            collision.collider.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            collision.collider.transform.SetParent(null);
        }
    }
}
