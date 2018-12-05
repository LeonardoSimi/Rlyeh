using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckHuntCrosshair : MonoBehaviour {

    private float _speed = 9.0f;
    private Renderer renderer;
    private Color startColor;

    private float _canFire = 0.0f;
    private float _fireRate = 0.35f;

    [SerializeField]
    private GameObject projectile;

    public bool duckHit;

    // Use this for initialization
    void Start () {
        renderer = this.GetComponent<Renderer>();
        renderer.material.color = new Color32(174, 196, 64, 255);
    }

    void Awake()
    {
        //startColor = this.renderer.material.color;
    }

    // Update is called once per frame
    void Update() {

        if (duckHit)
        {
            Debug.Log("duck hit");
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * _speed * horizontalInput * Time.deltaTime);

        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * _speed * verticalInput * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Instantiate(projectile, this.transform.position, Quaternion.identity);
            Shoot();
        }
    }

    void Shoot()
    {
        if (Time.time > _canFire)
        {
            StartCoroutine(projectileShot());
            _canFire = Time.time + _fireRate;
        }
        //StartCoroutine(changeColor());
    }

    private IEnumerator projectileShot()
    {
        Debug.Log("Coroutine changeColor started");
        renderer.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        renderer.material.color = new Color32(174, 196, 64, 255);

    }
}
