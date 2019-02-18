using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPotion : MonoBehaviour {

    [SerializeField]
    private int[] effects;
    [SerializeField]
    private int randomEffect;
    public float cooldown;
    public int quantity;
    public bool oneTime;
    public Player player;
    public ItemOcarina itemOcarina;
    private Vector2 pScale;

    // Use this for initialization
    void Start () {

        cooldown = 1f;
        //effects = new int[10];
        oneTime = false;
        player = GameObject.Find("Player").GetComponent<Player>();
        itemOcarina = GameObject.Find("itemThunder").GetComponent<ItemOcarina>();
        pScale = new Vector2(player.transform.localScale.x, player.transform.localScale.y);
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(potionUse());
        }

	}

    private IEnumerator potionUse()
    {
        if (oneTime == false)
        {
            if (quantity > 0)
            {
                oneTime = true;
                randomEffect = effects[Random.Range(0, effects.Length)];
                Debug.Log("randomized effect");
                effectUse();
                yield return new WaitForSeconds(cooldown);
                oneTime = false;
            }
        }
        }

    private IEnumerator pInv()
    {
        player.invulnerable = true;
        Debug.Log("pInv");
        yield return new WaitForSeconds(15f);
        player.invulnerable = false;
    }

    private IEnumerator pBig()
    {
        player.transform.localScale = new Vector2(pScale.x * 2, pScale.y * 2);
        Debug.Log("pBig");
        yield return new WaitForSeconds(15f);
        player.transform.localScale = new Vector2(pScale.x / 2, pScale.y / 2);

    }

    private IEnumerator pTiny()
    {
        player.transform.localScale = new Vector2(pScale.x / 2, pScale.y / 2);
        Debug.Log("pTiny");
        yield return new WaitForSeconds(15f);
        player.transform.localScale = new Vector2(pScale.x * 2, pScale.y * 2);
    }

    private IEnumerator pFast()
    {
        player._speed = player._speed * 2;
        Debug.Log("pFast");
        yield return new WaitForSeconds(15f);
        player._speed = player._speed / 2;
    }

    private IEnumerator pSlow()
    {
        player._speed = player._speed / 2;
        Debug.Log("pSlow");
        yield return new WaitForSeconds(15f);
        player._speed = player._speed * 2;

    }

    private void effectUse()
    {
        if (oneTime == true)
        {
            switch (randomEffect)
            {
                case 0:
                    player.pLives = player.pLives - 1;
                    Debug.Log("diminuzione pLives");
                    break;

                case 1:
                    player.Souls = player.Souls + 10;
                    Debug.Log("aumento souls");
                    break;

                case 2:
                    player.Souls = player.Souls - 15;
                    Debug.Log("diminuzione souls");
                    break;

                case 3:
                    StartCoroutine(itemOcarina.OcarinaUse());
                    Debug.Log("usa ocarina");
                    break; 

                case 4:
                    player.weaponAmmos.currentBombAmmo += 10;
                    player.weaponAmmos.currentStoneAmmo += 10;
                    player.weaponAmmos.currentSwordAmmo += 10;
                    player.weaponAmmos.currentProjectileAmmo += 10;
                    Debug.Log("aumento ammo");
                    break;

                case 5:
                    StartCoroutine(pInv());
                    break;

                case 6:
                    StartCoroutine(pBig());
                    break;

                case 7:
                    StartCoroutine(pTiny());
                    break;

                case 8:
                    StartCoroutine(pFast());
                    break;

                case 9:
                    StartCoroutine(pSlow());
                    break;
            }
        }
    }
}
