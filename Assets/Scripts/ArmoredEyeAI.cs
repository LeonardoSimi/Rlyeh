using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmoredEyeAI : MonoBehaviour {

    public Player player;
    public EnemyAI enemyAI;
    public GameObject proj;
    public int ammoInt;
    private int startingAmmo = 6;
    private float _canFire = 0.0f;
    private float _fireRate = 0.35f;
    private bool triggeredEye;

    // Use this for initialization
    void Start()
    {

        player = gameObject.GetComponent<Player>();
        enemyAI = this.GetComponent<EnemyAI>();

        triggeredEye = false;
    }

    void Awake()
    {
        ammoInt = startingAmmo;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (enemyAI.playerFound)
        {
            triggeredEye = true;
        }

        else
        {
            triggeredEye = false;
        }

        eyeController();
        tagController();
    }

    private void eyeController()
    {
        if (triggeredEye == true)
        {
            if (ammoInt > 0)
            {
                if (Time.time > _canFire)
                {
                    StartCoroutine(eyeShoot());
                    _canFire = Time.time + _fireRate;
                }

            }
            else
            {
                StartCoroutine(eyeReload());
            }
        }
    }

    private void tagController()
    {
        if (ammoInt > 0)
        {
            this.tag = "InvulEye";
        }
        else
        {
            this.tag = "Enemy";
        }
    }

    IEnumerator eyeShoot()
    {
        Debug.Log("shoot eye");
        Instantiate(proj, this.transform.position, Quaternion.identity);
        ammoInt = ammoInt - 1;
        yield return new WaitForSeconds(0.7f);
    }

    IEnumerator eyeReload()
    {
        yield return new WaitForSeconds(4f);
        ammoInt = startingAmmo;

    }

}
