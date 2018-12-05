using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DuckHuntScore : MonoBehaviour {

    public DuckHuntGameManager gameManager;

    public Text scoreText;

    public  Image[] duckStrikes;

	// Use this for initialization
	void Start () {

        gameManager = GameObject.Find("DuckHuntGameManager").GetComponent<DuckHuntGameManager>();

    }

    // Update is called once per frame
    void Update () {

        scoreText.text = "DUCKS KILLED: " + gameManager.score.ToString();
        changeSprite();
    }

    void changeSprite()
    {
        if (gameManager.strikes == 3)
        {
            duckStrikes[0].enabled = true;
            duckStrikes[1].enabled = false;
            duckStrikes[2].enabled = false;
            duckStrikes[3].enabled = false;
        }
        else if (gameManager.strikes == 2)
        {
            duckStrikes[0].enabled = false;
            duckStrikes[1].enabled = true;
            duckStrikes[2].enabled = false;
            duckStrikes[3].enabled = false;
        }
        else if (gameManager.strikes == 1)
        {
            duckStrikes[0].enabled = false;
            duckStrikes[1].enabled = false;
            duckStrikes[2].enabled = true;
            duckStrikes[3].enabled = false;
        }
        else if (gameManager.strikes == 0)
        {
            duckStrikes[0].enabled = false;
            duckStrikes[1].enabled = false;
            duckStrikes[2].enabled = false;
            duckStrikes[3].enabled = true;
        }
    }
}
