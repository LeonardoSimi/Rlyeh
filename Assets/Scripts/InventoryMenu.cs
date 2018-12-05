using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenu : MonoBehaviour {

    public enum State { Inactive, Active};
    public State Status;

    private Time defTime;

    public GameObject invBox;
    [SerializeField]
    private Text lifeText;
    [SerializeField]
    private Text soulText;
    [SerializeField]
    private Text bossText;
    [SerializeField]
    private Text enemyText;

    public Player player;

    // Use this for initialization
    void Start () {

        Status = State.Inactive;
        invBox.SetActive(false);

        player = GameObject.Find("Player").GetComponent<Player>();

	}

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (Status == State.Inactive)
            {
                Status = State.Active;
            }
            else if (Status == State.Active)
            {
                Status = State.Inactive;
            }
        }

        activateMenu();
        textUpdate();
	}

    void activateMenu()
    {
        if (Status == State.Active)
        {
            invBox.SetActive(true);
            Time.timeScale = 0;

        }
        else if (Status == State.Inactive)
        {

            Time.timeScale = 1;
            invBox.SetActive(false);

        }
    }

    void textUpdate()
    {
        lifeText.text = "x " + player.pLives.ToString();
        soulText.text = "x " + player.Souls.ToString();
        //ADD BOSS E ENEMY
    }

}
