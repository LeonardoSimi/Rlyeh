using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckHuntProjectile : MonoBehaviour {

    public DuckHuntCrosshair crosshair;

    public DuckHuntGameManager gamemanager;

	// Use this for initialization
	void Start () {

        crosshair = GameObject.Find("crosshair").GetComponent<DuckHuntCrosshair>();
        gamemanager = GameObject.Find("DuckHuntGameManager").GetComponent<DuckHuntGameManager>();

        StartCoroutine(selfDestruct());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            gamemanager.score += 1;
            Debug.Log("duck collision");
            crosshair.duckHit = true;
            Destroy(other.gameObject);
        }
        else
        {
            gamemanager.strikes = gamemanager.strikes - 1;
        }

        Debug.Log("Collided with " + other.tag);

    }

    private IEnumerator selfDestruct()
    {
        //yield return new WaitForSeconds(0.25f);
        yield return new WaitForSeconds(0.25f);
        crosshair.duckHit = false;
        Destroy(this.gameObject);
    }
}
