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
   

    // Use this for initialization
    void Start () {
        
        player = GameObject.Find("Player").GetComponent<Player>();
        weaponSwitcher = GameObject.Find("Player").GetComponent<WeaponSwitcher>();
        boxLimit.y = this.transform.position.y;
        boxLimit.x = 200.0f;
        thisBox.enabled = true;

    }

    void Awake()
    {
        InitPos = showWeaponFull.transform.position;
    }

    // Update is called once per frame
    void Update () {
        //weaponEnable();
        weaponSelect();
        showWeaponFullX = boxLimit.x;

    }

    void weaponSelect()
    {
        if (weaponSwitcher.showFullBox)
        {
            showWeaponFull.enabled = true;
            thisBox.enabled = false;
            showWeaponFull.transform.Translate(Vector3.right * trSpeed);

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

            }
        }
    }

    /*void weaponEnable()
    {
        if (weaponSwitcher.weaponCount == 0)
        {
            if (player.permProjectile)
            {
                weaponShow[0].enabled = true;
                weaponShow[1].enabled = false;
                weaponShow[2].enabled = false;
                weaponShow[3].enabled = false;
                weaponShow[4].enabled = false;
                weaponShow[5].enabled = false;
            }
            else {
                weaponShow[0].enabled = false;
                weaponShow[1].enabled = false;
                weaponShow[2].enabled = false;
                weaponShow[3].enabled = false;
                weaponShow[4].enabled = false;
                weaponShow[5].enabled = false;
            }
        }
        else if (weaponSwitcher.weaponCount == 1)
        {
            if (player.permSword)
            {
                weaponShow[0].enabled = false;
                weaponShow[1].enabled = true;
                weaponShow[2].enabled = false;
                weaponShow[3].enabled = false;
                weaponShow[4].enabled = false;
                weaponShow[5].enabled = false;
            }
            else
            {
                weaponShow[0].enabled = true;
                weaponShow[1].enabled = false;
                weaponShow[2].enabled = false;
                weaponShow[3].enabled = false;
                weaponShow[4].enabled = false;
                weaponShow[5].enabled = false;
            }
        }
        else if (weaponSwitcher.weaponCount == 2)
        {
            if (player.permFire)
            {
                weaponShow[0].enabled = false;
                weaponShow[1].enabled = false;
                weaponShow[2].enabled = true;
                weaponShow[3].enabled = false;
                weaponShow[4].enabled = false;
                weaponShow[5].enabled = false;
            }
            else
            {
                weaponShow[0].enabled = false;
                weaponShow[1].enabled = false;
                weaponShow[2].enabled = false;
                weaponShow[3].enabled = false;
                weaponShow[4].enabled = false;
                weaponShow[5].enabled = false;
            }
        }
        else if (weaponSwitcher.weaponCount == 3)
        {
            if (player.permRock)
            {
                weaponShow[0].enabled = false;
                weaponShow[1].enabled = false;
                weaponShow[2].enabled = false;
                weaponShow[3].enabled = true;
                weaponShow[4].enabled = false;
                weaponShow[5].enabled = false;
            }
            else
            {
                weaponShow[0].enabled = true;
                weaponShow[1].enabled = false;
                weaponShow[2].enabled = false;
                weaponShow[3].enabled = false;
                weaponShow[4].enabled = false;
                weaponShow[5].enabled = false;
            }
        }
        else if (weaponSwitcher.weaponCount == 4)
        {
            if (player.permBomb)
            {
                weaponShow[0].enabled = false;
                weaponShow[1].enabled = false;
                weaponShow[2].enabled = false;
                weaponShow[3].enabled = false;
                weaponShow[4].enabled = true;
                weaponShow[5].enabled = false;
            }
            else
            {
                weaponShow[0].enabled = true;
                weaponShow[1].enabled = false;
                weaponShow[2].enabled = false;
                weaponShow[3].enabled = false;
                weaponShow[4].enabled = false;
                weaponShow[5].enabled = false;
            }
            }
        else if (weaponSwitcher.weaponCount == 5)
        {
            if (player.permWhip)
            {
                weaponShow[0].enabled = false;
                weaponShow[1].enabled = false;
                weaponShow[2].enabled = false;
                weaponShow[3].enabled = false;
                weaponShow[4].enabled = false;
                weaponShow[5].enabled = true;
            }
            else
            {
                weaponShow[0].enabled = true;
                weaponShow[1].enabled = false;
                weaponShow[2].enabled = false;
                weaponShow[3].enabled = false;
                weaponShow[4].enabled = false;
                weaponShow[5].enabled = false;
            }
            }
    } */

}
