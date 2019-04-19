using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twompAOEscript : MonoBehaviour {

	// Use this for initialization
	void Start () {

        StartCoroutine(destroyCoroutine());
	}
	
	// Update is called once per frame
	void Update () {
		

	}

    private IEnumerator destroyCoroutine()
    {
        yield return new WaitForSeconds(1.3f);
        Destroy(this.gameObject);
    }
}
