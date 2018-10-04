using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotarBase : MonoBehaviour {
    public GameObject bas;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("q")) {
            float angulo= bas.transform.rotation.eulerAngles.z -90;
                while (bas.transform.rotation.eulerAngles.z >= angulo)
                    bas.transform.Rotate(-Vector3.forward * Time.deltaTime);
        }
        /*if (Input.GetKeyDown("q"))
            bas.transform.Rotate(-Vector3.up * Time.deltaTime);*/
    }
}
