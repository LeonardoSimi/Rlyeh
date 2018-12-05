using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplode : MonoBehaviour {

    public ParticleSystem explodeParticles;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground" || other.tag == "Enemy")
        {
            Explode();
        }
    }

    void Explode()
    {
        Destroy(this.gameObject);
    }

    void OnDestroy()
    {
        Instantiate(explodeParticles, transform.position, Quaternion.identity);
    }
}
