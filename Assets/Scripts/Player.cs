using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    
    public int _speed = 5;
    private int orSpeed;

    public int pLives = 3;

    public Vector2 jumpHeight;

    [SerializeField]
    private AudioClip _jumpSFX;

    [SerializeField]
    private AudioClip _projectileSFX;

    [SerializeField]
    private bool _isOnGround = false;

    [SerializeField]
    private bool _isInWater = false;

    public Vector2 pDirection;

    public bool isRight;
    public bool isLeft;

    [SerializeField]
    private GameObject _projectile;

    [SerializeField]
    private GameObject _fireProjectile;

    private float _canFire = 0.0f;
    [SerializeField]
    private float _fireRate = 0.45f;

    public bool hasStaff;
    public bool hasSword;
    public bool hasWhip;
    public bool hasFire;
    public bool hasRock;
    public bool hasProjectile;
    public bool hasBomb;

    public bool permProjectile;
    public bool permBomb;
    public bool permRock;
    public bool permFire;
    public bool permWhip;
    public bool permSword;
    public bool permStaff;

    public bool canMove;

    public bool damageTaken;

    public int Souls;
    public int hitsTaken;

    public RockSpriteChange rockSpriteChange;
    public WeaponAmmos weaponAmmos;

    public float invulTime; 
    public bool invulnerable = false;

    public BoxCollider2D coll;
    public BoxCollider2D originalColl;

    // Use this for initialization
    void Start () {

        //starting position
        transform.position = new Vector3(-7.3f, -2.0f);
        canMove = true;
        isRight = true;
        isLeft = false;
        pLives = 3; //mettilo nel gamemanager e aggiustalo
        damageTaken = false;
        rockSpriteChange = this.GetComponent<RockSpriteChange>();
        weaponAmmos = this.GetComponent<WeaponAmmos>();

        hasStaff = true;
        hasSword = false;
        hasWhip = false;
        hasFire = false;
        hasRock = false;
        hasProjectile = false;
        hasBomb = false;

        //coll = this.GetComponent<BoxCollider2D>();
        
    }

    void Awake()
    {
        //originalColl.size = new Vector2(0.1f, 0.2f);
        orSpeed = _speed;
        
    }


	// Update is called once per frame
	void Update () {

        getDirection();
        if (canMove)
        {
            Movement();
            ShootProjectile();
        }
        lifeLost();

	}

    /*private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Ground")
        {
            _isOnGround = true;
            Debug.Log("On the ground");
        }
        else if (other.tag == "Enemy")
        {
            pLives -= 1;
            //ADD COOLDOWN PLS
        }
    } */


    void OnTriggerEnter2D (Collider2D other)
    {
        if (rockSpriteChange.rockChange == false)
        {
            if (other.tag == "Enemy" || other.tag == "Bone" || other.tag == "GhostExplosion")
            {
                if (!invulnerable)
                {
                    StartCoroutine(pDamage());
                    StartCoroutine(JustHurt());
                    
                }
            }
            /*else if (other.tag == "GhostExplosion")
            {
                StartCoroutine(pDamage());
                StartCoroutine(JustHurt());
                //StartCoroutine(speedLoss());
                
            }*/

        }

    }
    IEnumerator JustHurt()
    {
        invulnerable = true;
        yield return new WaitForSeconds(invulTime);
        invulnerable = false;
    }

    IEnumerator pDamage()
    {

        //pLives -= 1;
        hitsTaken = hitsTaken - 1;
        yield return new WaitForSeconds(invulTime);
        damageTaken = true;
        yield return new WaitForSeconds(0.1f);
        damageTaken = false;
        yield return new WaitForSeconds(2.0f);
    }

    private void lifeLost()
    {
        if (hitsTaken <= 0)
        {
            pLives = pLives - 1;
        }
    }

    /*IEnumerator speedLoss()
    {
        _speed = _speed - 2;
        yield return new WaitForSeconds (5.0f);
        _speed = orSpeed;
    }*/

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Entered ground collision");

            _isOnGround = true;
        }

    }
    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Exited");
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isOnGround = false;
        }
        else if (collision.gameObject.CompareTag("Water"))
        {
            _isInWater = false;
        }
    }

        private void Movement()
    {
        if (rockSpriteChange.rockChange == false)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * _speed * horizontalInput * Time.deltaTime);


            if (_isOnGround == true || _isInWater == true)
            {
                //if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
                if (Input.GetButtonDown("Jump"))
                {
                    Debug.Log("Jump");
                    AudioSource.PlayClipAtPoint(_jumpSFX, Camera.main.transform.position, 0.5f);
                    GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
                    _isOnGround = false;

                }

            }
        }

    }


    public void getDirection()
    {

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            isRight = true;
            isLeft = false;

        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            isLeft = true;
            isRight = false;
        }

    }

    private void ShootProjectile()
    {
        if (hasProjectile == true)
        {
            if (this.weaponAmmos.currentProjectileAmmo > 0)
            {
                if (Input.GetKey(KeyCode.Return))
                {
                    if (Time.time > _canFire)
                    {
                        AudioSource.PlayClipAtPoint(_projectileSFX, Camera.main.transform.position, 0.5f);

                        Instantiate(_projectile, transform.position + new Vector3(0.1f, 0, 0), Quaternion.identity);

                        this.weaponAmmos.currentProjectileAmmo = this.weaponAmmos.currentProjectileAmmo - 1;

                        _canFire = Time.time + _fireRate;
                    }
                }
            }
        }
        else if (hasFire == true)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                if (Time.time > _canFire)
                {
                    if (weaponAmmos.currentFireAmmo > 0)
                    {
                        Instantiate(_fireProjectile, transform.position + new Vector3(0.1f, 0, 0), Quaternion.identity);
                        weaponAmmos.currentFireAmmo--;
                        _canFire = Time.time + _fireRate;
                    }
                }
            }
        }
    }




}
