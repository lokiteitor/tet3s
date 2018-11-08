using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float angulo = 0;
		if (Input.GetKeyDown(KeyCode.E))
		{
			// girar la base
			Debug.Log("Girar");
			while (angulo <= 90)
			{
				this.transform.Rotate(Vector3.forward*Time.deltaTime * 90 * angulo);
				angulo+=1;
			}			
		}
		if(Input.GetKeyDown(KeyCode.Q)){
			while(angulo <= 90){
				this.transform.Rotate(Vector3.back*Time.deltaTime * 90 * angulo);
			}
		}
		
	}
}
