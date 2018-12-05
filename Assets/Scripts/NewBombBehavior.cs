using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBombBehavior : MonoBehaviour {

    public Transform target;
    private Vector2 dis;
    public Transform throwPoint;
    public float timeTillHit = 1f;
    public Player player;
    public WeaponAmmos weaponAmmos;
    private float dir;
    private float _canFire = 0.0f;
    [SerializeField]
    private float _fireRate = 0.45f;

    [SerializeField]
    private GameObject _bombPrefab;

    // Use this for initialization
    void Start () {
        player = GetComponent<Player>();
        weaponAmmos = GameObject.Find("Player").GetComponent<WeaponAmmos>();
        dis = new Vector2(1f, 1f);
    }
    void Awake()
    {
    }
    // Update is called once per frame
    void Update () {

        throwPoint.position = (transform.position);

        if (player.hasBomb == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (Time.time > _canFire)
                {
                    if (weaponAmmos.currentBombAmmo > 0)
                    {
                        GetDir();
                        Throw();
                        weaponAmmos.currentBombAmmo--;
                        _canFire = Time.time + _fireRate;
                    }
                }
            }
        }
    }

    void Throw()
    {
        float xdistance = 8.0f;
        //xdistance = dis.x - throwPoint.position.x;
        if (xdistance <= 0)
        {
            xdistance = 1;
        }

        float ydistance;
        ydistance = dis.y - throwPoint.position.y;

        float throwAngle; // in radian
                          //OLD
                          //throwAngle = Mathf.Atan ((ydistance + 4.905f) / xdistance);
                          //UPDATED
        throwAngle = Mathf.Atan((ydistance + 4.905f * (timeTillHit * timeTillHit)) / xdistance);
        //OLD
        //float totalVelo = xdistance / Mathf.Cos(throwAngle) ;
        //UPDATED
        float totalVelo = xdistance / (Mathf.Cos(throwAngle) * timeTillHit);

        float xVelo, yVelo;
        xVelo = totalVelo * Mathf.Cos(throwAngle) * dir;
        yVelo = totalVelo * Mathf.Sin(throwAngle);

        GameObject Bomb = Instantiate(_bombPrefab, throwPoint.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
        Rigidbody2D rigid;
        rigid = Bomb.GetComponent<Rigidbody2D>();

        rigid.velocity = new Vector2(xVelo, yVelo);
    }

    void GetDir()
    {
        if (player.isLeft)
        {
            dir = -1;
        }
        else if (player.isRight)
        {
            dir = 1;
        }
    }
}

