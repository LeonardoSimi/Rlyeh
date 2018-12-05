using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckHuntDuck : MonoBehaviour {

    public DuckHuntGameManager gameManager;

    private Vector2 initPos;

    [SerializeField]
    private float _speed;

    private bool isOffScreen;

    // Use this for initialization
    void Start () {

        gameManager = GameObject.Find("DuckHuntGameManager").GetComponent<DuckHuntGameManager>();
        isOffScreen = false;

    }

    void Awake()
    {
        if (gameManager.timer < 10)
        {
            _speed = Random.Range(0.1f, 0.2f);
        }
        else if (gameManager.timer > 25)
        {
            _speed = Random.Range(0.2f, 0.3f);
        }
        else if (gameManager.timer > 45)
        {
            _speed = Random.Range(0.5f, 0.7f);
        }
        else if (gameManager.timer > 70)
        {
            _speed = Random.Range(0.8f, 1f);
        }

        initPos.y = transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.right * _speed);

        outOfBonds();

    }

    void outOfBonds()
    {
        if (transform.position.x > 10.0f)
        {
            isOffScreen = true;
            gameManager.strikes = gameManager.strikes - 1;
            Destroy(this.gameObject);
        }
    }

   
}
