using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour {

    public Player player;
    public ElevatorController elevatorLink;
    [SerializeField]
    //private GameObject elevatorLink;
    public bool enteredCollision;


    // Use this for initialization
    void Start () {
        enteredCollision = false;
        player = GameObject.Find("Player").GetComponent<Player>();
        elevatorLink = GameObject.Find("elevatorLink").GetComponent<ElevatorController>();
    }

    void Awake()
    {
        Vector2 elevatorLinkPos = elevatorLink.transform.position;

    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (enteredCollision == true)
            {
                player.transform.position = elevatorLink.transform.position;
            }
        }

	}

    void OnTriggerEnter2D (Collider2D other)
    {
       if (other.tag == "player")
        {
            Debug.Log("collisione elevator");
            enteredCollision = true;
            /*elevatorLink.enteredCollision = true;
            if (elevatorLink != null)
                if (enteredCollision == true)
                {
                    {
                        player.transform.position = elevatorLink.transform.position;
                    }
                }*/
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "player")
        {
            enteredCollision = false;
            elevatorLink.enteredCollision = false;
        }
    }

}
