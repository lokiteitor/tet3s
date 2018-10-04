using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotar : MonoBehaviour {
    public GameObject figura;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("s"))
            figura.transform.Rotate(Vector3.right * 90);
	}
}
