using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehavior : MonoBehaviour {

    public Player player;
    public WeaponAmmos weaponAmmos;
    public GameObject Sword;
    public GameObject swordProjectile;
    Quaternion rotation;

    // Use this for initialization
    void Start () {
        player = this.GetComponent<Player>();
        weaponAmmos = this.GetComponent<WeaponAmmos>();
        rotation = Sword.transform.rotation;

    }

    // Update is called once per frame
    void Update () {
        EnableSword();
        if (player.hasSword)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (weaponAmmos.currentSwordAmmo > 0)
                {
                    weaponAmmos.currentSwordAmmo--;
                    Instantiate(swordProjectile, transform.position, Quaternion.identity);
                }
                }
        }
	}

    void EnableSword()
    {
        if (player.hasSword)
        {
            Sword.SetActive(true);

        }
        else if (player.hasSword == false)
        {
            Sword.SetActive(false);
        }
    }
}
