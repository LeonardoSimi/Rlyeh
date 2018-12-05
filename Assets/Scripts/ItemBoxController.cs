using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBoxController : MonoBehaviour {
    public enum State { Selected, Deselected };
    public State Status;
    // Use this for initialization
    void Start () {
        this.Status = State.Deselected;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
