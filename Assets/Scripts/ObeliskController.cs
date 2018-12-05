using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class ObeliskController : MonoBehaviour {

    [SerializeField]
    private Image buttonOverlay;

    [SerializeField]
    private Image AlertBox;
    public TextMeshProUGUI textDisplay;


    //public bool CheckpointPressed;

    public Vector2 obeliskPosition;

    public Vector2 playerSpawnPosition;

    public enum State {Inactive, Active, Used};
    public State Status;
    public ParticleSystem activateParticles;

    public Player player;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player").GetComponent<Player>();
	}

    void Awake()
    {
        AlertBox.enabled = false;
        textDisplay.enabled = false;
        obeliskPosition = transform.position;
    }

	// Update is called once per frame
	void Update () {
        ActivateObelisk();
 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Status == State.Inactive)
        {
            if (other.tag == "player")
            {
                if (player.Souls >= 10)
                {
                    buttonOverlay.enabled = true;
                    //Debug.Log("COLLISIONE OBELISCO");
                    Status = State.Active;
                }
                else
                {
                    StartCoroutine(AlertBoxActivate());
                }

            }
        }
    }

    IEnumerator AlertBoxActivate()
    {
        AlertBox.enabled = true;
        textDisplay.enabled = true;
        yield return new WaitForSeconds(3);
        AlertBox.enabled = false;
        textDisplay.enabled = false;
    }

    void OnTriggerExit2D(Collider2D other)
    {

            if (other.tag == "player")
            {
                buttonOverlay.enabled = false;
                Status = State.Inactive;
            }
        
    }

    void ActivateObelisk()
    {
        if (Status == State.Active)
        {

                if (Input.GetKeyDown(KeyCode.Z))
                {
                    Instantiate(activateParticles, transform.position, Quaternion.identity);
                    //CheckpointPressed = true;
                    playerSpawnPosition = obeliskPosition;
                    Status = State.Used;
                    player.Souls -= 10;
                }
            
        }
    }
}
