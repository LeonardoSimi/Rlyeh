using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Player player;
    public WeaponAmmos weaponAmmos;

    public Text scoreText;

    public int score;

    public Text Lives;
    public Text SoulsText;
    public Text AmmoText;


    // Use this for initialization
    void Start () {

        player = GameObject.Find("Player").GetComponent<Player>();
        weaponAmmos = GameObject.Find("Player").GetComponent<WeaponAmmos>();
    }

    // Update is called once per frame
    void Update () {

        UpdateScore();
        livesNumber();
        soulsNumber();
        ammoNumber();
	}

    public void UpdateScore()
    {
        //score += 100;
        scoreText.text = "Score: " + score;
    }

    public void livesNumber()
    {

        scoreText.text = "x" + player.pLives.ToString();


    }

    public void soulsNumber()
    {
        SoulsText.text = "x" + player.Souls.ToString();
    }

    public void ammoNumber()
    {
        if (player.hasBomb)
        {
            AmmoText.text = weaponAmmos.currentBombAmmo + "/" + weaponAmmos.totalBombAmmo;
        }
        else if (player.hasFire)
        {
            AmmoText.text = weaponAmmos.currentFireAmmo + "/" + weaponAmmos.totalFireAmmo;
        }
        else if (player.hasProjectile)
        {
            AmmoText.text = weaponAmmos.currentProjectileAmmo + "/" + weaponAmmos.totalProjectileAmmo;
        }
        else if (player.hasRock)
        {
            AmmoText.text = weaponAmmos.currentStoneAmmo + "/" + weaponAmmos.totalStoneAmmo;
        }
        else if (player.hasSword)
        {
            AmmoText.text = weaponAmmos.currentSwordAmmo + "/" + weaponAmmos.totalSwordAmmo;
        }
        else if (player.hasWhip)
        {
            AmmoText.text = weaponAmmos.currentWhipAmmo + "/" + weaponAmmos.totalWhipAmmo;
        }
        else if (player.hasStaff)
        {
            AmmoText.text = "∞/∞";
        }
        else
        {
            AmmoText.text = "";
        }
    }
}
