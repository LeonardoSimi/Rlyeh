using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Player player;
    public GameObject[] obelisk;
    public ObeliskController[] obeliskController;

    [SerializeField]
    private int previousPLives;

    public bool isGameOver;

    [SerializeField]
     private Vector2 newPlayerStartPosition;

    //private Vector3 LevelStartPosition;

	// Use this for initialization
	void Start () {

        //obelisk = GameObject.Find("obelisk").GetComponent<ObeliskController>();
        obelisk = GameObject.FindGameObjectsWithTag("Obelisk");

        obeliskController = new ObeliskController[obelisk.Length];

        for (int i = 0; i < obelisk.Length; i++)
        {
            obeliskController[i] = obelisk[i].GetComponent<ObeliskController>();
        }

        isGameOver = false;

	}

    void Awake()
    {
        previousPLives = player.pLives;
    }
	
	// Update is called once per frame
	void Update () {
         
        //GameOver();
        GetSpawnPos();
        if (previousPLives != player.pLives)
        {
            previousPLives = player.pLives;
            StartCoroutine(lifeLostRespawn());
        }
        
    }

    IEnumerator lifeLostRespawn()
    {
        yield return new WaitForSeconds(0.2f);
        if (player != null)
        {
            player.transform.position = new Vector3(newPlayerStartPosition.x, newPlayerStartPosition.y, player.transform.position.z);
            yield return new WaitForSeconds(2.0f);
        }
    }


    /*void GameOver()    TODO
    {
        if (previousPLives <= 0)
        {
            isGameOver = true;
        }
        if (isGameOver)
        {
            StartCoroutine(gameOverRespawn());
        }

    }

    IEnumerator gameOverRespawn()
    {
        //Destroy(player.gameObject);
        Instantiate(player, newPlayerStartPosition, Quaternion.identity);
        isGameOver = false;
        yield return new WaitForSeconds(0.5f);
        player.pLives = 3;
    }*/

    void GetSpawnPos()
    {
        for (int i = 0; i < obelisk.Length; i++)
        {
            if (obeliskController[i].Status == ObeliskController.State.Used)
            {
                if (newPlayerStartPosition != obeliskController[i].playerSpawnPosition)
                {
                    newPlayerStartPosition = obeliskController[i].playerSpawnPosition;
                    obeliskController[i].Status = ObeliskController.State.Used;
                }
            }
        }
    }

} 
