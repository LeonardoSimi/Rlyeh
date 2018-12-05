using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour {

    public int weaponCount;
    public Player player;

    // Use this for initialization
    void Start () {
        player = this.GetComponent<Player>();
	}

    void Awake()
    {
        weaponCount = 0;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.C))
        {
            weaponCount += 1;
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            weaponCount -= 1;
        }
        weaponLimit();
        weaponEnable();
	}
    void weaponLimit()
    {
        if (weaponCount > 5)
        {
            weaponCount = 0;
        }
        else if (weaponCount < 0)
        {
            weaponCount = 5;
        }
    }
    void weaponEnable()
    {
        switch (weaponCount)
        {
            case 0:
                if (player.permProjectile)
                {
                    player.hasProjectile = true;
                    player.hasSword = false;
                    //player.hasWhip = false;
                    player.hasFire = false;
                    player.hasRock = false;
                    player.hasBomb = false;
                    player.hasStaff = false;

                }
                break;
            case 1:
                if (player.permSword)
                {
                    player.hasSword = true;
                    //player.hasWhip = false;
                    player.hasFire = false;
                    player.hasRock = false;
                    player.hasProjectile = false;
                    player.hasBomb = false;
                    player.hasStaff = false;

                }
                else
                {
                    weaponCount = 0;
                }
                break;

            case 2:
                if (player.permFire)
                {
                    player.hasFire = true;
                    player.hasSword = false;
                    //player.hasWhip = false;
                    player.hasRock = false;
                    player.hasProjectile = false;
                    player.hasBomb = false;
                    player.hasStaff = false;

                }
                else
                {
                    weaponCount = 0;
                }
                break;

            case 3:
                if (player.permRock)
                {
                    player.hasRock = true;
                    player.hasSword = false;
                    //player.hasWhip = false;
                    player.hasFire = false;
                    player.hasProjectile = false;
                    player.hasBomb = false;
                    player.hasStaff = false;

                }
                else
                {
                    weaponCount = 0;
                }
                break;

            case 4:
                if (player.permBomb)
                {
                    player.hasBomb = true;
                    player.hasSword = false;
                    //player.hasWhip = false;
                    player.hasFire = false;
                    player.hasRock = false;
                    player.hasProjectile = false;
                    player.hasStaff = false;

                }
                else
                {
                    weaponCount = 0;
                }
                break;

            case 5:
                if (player.permStaff)
                {
                    //player.hasWhip = false;
                    player.hasSword = false;
                    player.hasFire = false;
                    player.hasRock = false;
                    player.hasProjectile = false;
                    player.hasBomb = false;
                    player.hasStaff = true;

                }
                else
                {
                    weaponCount = 0;
                }
                break;

            /*case 6:
                if (player.permStaff)
                {
                    player.hasWhip = false;
                    player.hasSword = false;
                    player.hasWhip = false;
                    player.hasFire = false;
                    player.hasRock = false;
                    player.hasProjectile = false;
                    player.hasBomb = false;
                    player.hasStaff = true;
                }
                else
                {
                    weaponCount = 0;
                }
                break; */
        }
    }
}
