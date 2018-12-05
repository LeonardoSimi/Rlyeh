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

    public Player player;
    public WeaponSwitcher weaponSwitcher;
	// Use this for initialization
	void Start () {
        
        player = GameObject.Find("Player").GetComponent<Player>();
        weaponSwitcher = GameObject.Find("Player").GetComponent<WeaponSwitcher>();
    }

    // Update is called once per frame
    void Update () {
        weaponEnable();
	}

    void weaponEnable()
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
    }

}
