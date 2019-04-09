using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPill : MonoBehaviour
{

    public float cooldown = 10;
    public int quantity;
    public bool oneTime;
    public Player player;

    // Use this for initialization
    void Start()
    {

        oneTime = false;
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(pillUse());
        }
    }

    private IEnumerator pillUse()
    {
        if (oneTime == false)
        {
            if (quantity > 0)
            {
                player.isStrong = true;
                Debug.Log("stronk");
                yield return new WaitForSeconds(cooldown);
                player.isStrong = false;
            }
        }
    }
}
