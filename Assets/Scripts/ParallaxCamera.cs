using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxCamera : MonoBehaviour {


    private float _speed;

    public Transform[] backgrounds;
    private float[] scales;
    public float smoothing = 1f;

    private Transform _cam; //main cam transform
    private Vector3 _previousCamPos; //position of the cam in previous frame


    void Awake()
    {
        _cam = Camera.main.transform;
    }


	// Use this for initialization
	void Start ()
    {
        _previousCamPos = _cam.position;

        scales = new float[backgrounds.Length];

        for (int i = 0; i < backgrounds.Length; i++)
        {
            scales[i] = backgrounds[i].position.z * -1;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallax = (_previousCamPos.x - _cam.position.x) * scales[i];

            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }
        _previousCamPos = _cam.position;

    }
}
