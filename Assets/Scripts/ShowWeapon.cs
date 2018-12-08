using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ShowWeapon : MonoBehaviour {

    //[SerializeField]
    //private List<Image> WeaponPics = new List<Image>();

    [SerializeField]
    private Image[] weaponShow = new Image[6];
    [SerializeField]
    private Image thisBox;
    [SerializeField]
    private GameObject[] weaponBox;

    public Player player;
    public WeaponSwitcher weaponSwitcher;
    public Image showWeaponFull;

    private Vector2 boxLimit;

    private float trSpeed = 10.0f;
    private float showWeaponFullX;

    private Vector2 InitPos;

    public GameObject soulsImg;
    public GameObject livesImg;
    public GameObject soulsText;
    public GameObject livesText;

    [SerializeField]
    private Image unknSprite;
    [SerializeField]
    private Image[] weaponSprite;

   
    // Use this for initialization
    void Start () {
        
        player = GameObject.Find("Player").GetComponent<Player>();
        weaponSwitcher = GameObject.Find("Player").GetComponent<WeaponSwitcher>();
        boxLimit.y = this.transform.position.y;
        boxLimit.x = 200.0f;
        thisBox.enabled = true;


        foreach (GameObject i in weaponBox)
        {
            i.SetActive(false);
        }

    }

    void Awake()
    {
        InitPos = showWeaponFull.transform.position;

    }

    // Update is called once per frame
    void Update () {

        weaponBoxSee();
        showWeaponFullX = boxLimit.x;
        weaponSee();

        if (weaponSwitcher.showFullBox) //WIP
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                player.hasRock = true;
            }
            //ALTRI CON PAD INPUT
        }
    }

    void weaponBoxSee()
    {
        if (weaponSwitcher.showFullBox)
        {
            showWeaponFull.enabled = true;
            thisBox.enabled = false;
            showWeaponFull.transform.Translate(Vector3.right * trSpeed);

            foreach (GameObject i in weaponBox)
            {
                i.SetActive(true);
            }

            soulsImg.transform.parent = showWeaponFull.transform;
            livesImg.transform.parent = showWeaponFull.transform;
            soulsText.transform.parent = showWeaponFull.transform;
            livesText.transform.parent = showWeaponFull.transform;

            if (showWeaponFull.transform.position.x >= boxLimit.x)
            {
                showWeaponFull.transform.position = boxLimit;
            }
        }

        else if (!weaponSwitcher.showFullBox)
        {
            showWeaponFull.transform.Translate(Vector3.left * trSpeed);
            if (showWeaponFull.transform.position.x <= InitPos.x)
            {
                showWeaponFull.transform.position = InitPos;
                thisBox.enabled = true;
                showWeaponFull.enabled = false;

                foreach (GameObject i in weaponBox)
                {
                    i.SetActive(false);
                }
            }
        }
    }

    void weaponSee()
    {
        //oscura gli sprite
        if (player.permStaff)
        {
            Image img = weaponBox[0].GetComponent<Image>();
            img.sprite = weaponShow[0].sprite;

        }
        else if (!player.permStaff)
        {
            Image img = weaponBox[0].GetComponent<Image>();
            img.sprite = unknSprite.sprite;
            
        }

        if (player.permProjectile)
        {
            Image img = weaponBox[1].GetComponent<Image>();
            img.sprite = weaponShow[1].sprite;
        }
        else if (!player.permProjectile)
        {
            Image img = weaponBox[1].GetComponent<Image>();
            img.sprite = unknSprite.sprite;

        }

        if (player.permBomb)
        {
            Image img = weaponBox[2].GetComponent<Image>();
            img.sprite = weaponShow[2].sprite;
        }
        else if (!player.permBomb)
        {
            Image img = weaponBox[2].GetComponent<Image>();
            img.sprite = unknSprite.sprite;

        }

        if (player.permRock)
        {
            Image img = weaponBox[3].GetComponent<Image>();
            img.sprite = weaponShow[3].sprite;
        }
        else if (!player.permRock)
        {
            Image img = weaponBox[3].GetComponent<Image>();
            img.sprite = unknSprite.sprite;

        }
        if (player.permSword)
        {
            Image img = weaponBox[4].GetComponent<Image>();
            img.sprite = weaponShow[4].sprite;
        }
        else if (!player.permSword)
        {
            Image img = weaponBox[4].GetComponent<Image>();
            img.sprite = unknSprite.sprite;

        }
    }

    void weaponSelect()
    {

    }
   

}
