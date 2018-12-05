using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour {
    Vector3 initPosition;
    public Player player;
    [SerializeField]
    private float cameraSpeed;
	// Use this for initialization
	void Start () {

        player = GameObject.Find("Player").GetComponent<Player>();
        cameraSpeed = player._speed - 1.0f;
        
    }

    void Awake()
    {
        initPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z); ;
    }

    // Update is called once per frame
    void Update () {

        Scroll();
        Reposition();
        
	}

    private void Scroll()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * cameraSpeed  * horizontalInput * Time.deltaTime);

    }
    private void Reposition()
    {
        if (transform.position.x <= -0.25f)
        {
            transform.position = new Vector3 (-0.24f, transform.position.y, transform.position.z);
        }
    }
}
