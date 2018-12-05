using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewDialog : MonoBehaviour {

    public TextMeshProUGUI textDisplay;
    [TextArea(3, 10)]
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public bool dialStart;
    private bool playerOnRange;

    [SerializeField]
    private Image buttonOverlay;
    [SerializeField]
    private Image textBox;

    [SerializeField]
    private AudioSource textScroll;

    public Player player;


    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        StartCoroutine(Type());
        textBox.enabled = false;
        textDisplay.enabled = false;
    }

    void Update()
    {
        if (playerOnRange)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                dialStart = true;
                textBox.enabled = true;
                textDisplay.enabled = true;
            }
        }
        if (dialStart)
        {
            player.canMove = false;
            buttonOverlay.enabled = false;
            if (textDisplay.text == sentences[index])
                {
                textScroll.Stop();
                if (Input.GetKeyDown(KeyCode.Space))
                    {              
                    NextSentence();
                    }
                }           
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        if (index < sentences.Length - 1)
        {
            textScroll.Play();
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            player.canMove = true;
            textScroll.Stop();
            textDisplay.text = "";
            dialStart = false;
            textDisplay.enabled = false;
            textBox.enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player")
        {
            playerOnRange = true;
            buttonOverlay.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "player")
        {
            playerOnRange = false;
            buttonOverlay.enabled = false;


        }
    }

}
