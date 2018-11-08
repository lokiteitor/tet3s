using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Figura;

public class Generador : MonoBehaviour {

	private List<SFigura> figuras = new List<SFigura>();
    private GameObject figuraActual;
    public GameObject pref1;//prefabs
    public GameObject pref2;
    public GameObject pref3;
    public GameObject pref4;
    public GameObject pref5;
    public GameObject pref6;
    public GameObject pref7;

    // Use this for initialization
    void Start () {
		generar();
		
	}

    private void generar()//genera aleatoriamente las figuras
    {
        
        switch (Random.Range(1, 8))
        {
            case 1:
                this.figuraActual = Instantiate(pref1, new Vector3(.4f, 1.2f, 0f), Quaternion.identity) as GameObject;
                break;
            case 2:
                this.figuraActual = Instantiate(pref2, new Vector3(.4f, 1.2f, 0f), Quaternion.identity) as GameObject;
                break;
            case 3:
                this.figuraActual = Instantiate(pref3, new Vector3(.4f, 1.2f, 0f), Quaternion.identity) as GameObject;
                break;
            case 4:
                this.figuraActual = Instantiate(pref4, new Vector3(.4f, 1.2f, 0f), Quaternion.identity) as GameObject;
                break;
            case 5:
                this.figuraActual = Instantiate(pref5, new Vector3(.4f, 1.2f, 0f), Quaternion.identity) as GameObject;
                break;
            case 6:
                this.figuraActual = Instantiate(pref6, new Vector3(.4f, 1.2f, 0f), Quaternion.identity) as GameObject;
                break;
            case 7:
                this.figuraActual = Instantiate(pref7, new Vector3(.4f, 1.2f, 0f), Quaternion.identity) as GameObject;
                break;
            
        }
        SFigura figura = new SFigura(new Vector3(.4f, 1.2f, 0), this.figuraActual);
        figuras.Add(figura);
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
