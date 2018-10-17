using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fondo : MonoBehaviour {
    public Material fondo1;
    public Material fondo2;
    public Material fondo3;
    public Material fondo4;
    public GameObject plano;
    private Material[] fondos;
    private int index = 0;



    // Use this for initialization
    void Start () {
        fondos = new Material[] { fondo1, fondo2, fondo3, fondo4 };
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Renderer render = plano.GetComponent(typeof(Renderer)) as Renderer;
            if (render != null)
            {
                render.sharedMaterial = fondos[this.index];
                this.index += 1 ;
                Debug.Log("entro");
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Renderer render = plano.GetComponent(typeof(Renderer)) as Renderer;
            if (render != null)
            {
                render.sharedMaterial = fondos[this.index];
                this.index -= 1;
                Debug.Log("entro");
            }
        }

        if(this.index >= 4)
        {
            this.index = 0;
        }else if(this.index <= -1)
        {
            this.index = 3;
        }
		
	}
}
