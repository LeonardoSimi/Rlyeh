using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckHuntGameManager : MonoBehaviour {

    public float timer;
    public int score;
    [SerializeField]
    private GameObject duck;
    public bool gameOver;

    public int strikes;

    // Use this for initialization
    void Start() {
        timer = 0;
        score = 0;
        strikes = 3;
        gameOver = false;
        StartCoroutine(duckSpawn());

    }

    // Update is called once per frame
    void Update() {

        timer = Time.timeSinceLevelLoad;
        isGameOver();
    }

    void isGameOver()
    {
        if (strikes == 0)
        {
            gameOver = true;
        }
    }

    private IEnumerator duckSpawn()
    {
        while (gameOver == false)
        {
            Instantiate(duck, new Vector3(-10.0f, -2.39f, 0.0f), Quaternion.identity);
            if (timer < 10)
            {
                yield return new WaitForSeconds(5f);
            }
            else if (timer > 25)
            {
                yield return new WaitForSeconds(3f);
            }
            else if (timer > 45)
            {
                yield return new WaitForSeconds(2.5f);
            }
            else if (timer > 70)
            {
                yield return new WaitForSeconds(1.5f);
            }
            else
            {
                yield return new WaitForSeconds(0.7f);
            }
        }
    }


}
