using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Figura;

public class Generador : MonoBehaviour {

	private List<SFigura> figuras;
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
                figuraActual = Instantiate(pref1, new Vector3(.4f, 1.2f, 0f), Quaternion.identity);
                break;
            case 2:
                figuraActual = Instantiate(pref2, new Vector3(.4f, 1.2f, 0f), Quaternion.identity);
                break;
            case 3:
                figuraActual = Instantiate(pref3, new Vector3(.4f, 1.2f, 0f), Quaternion.identity);
                break;
            case 4:
                figuraActual = Instantiate(pref4, new Vector3(.4f, 1.2f, 0f), Quaternion.identity);
                break;
            case 5:
                figuraActual = Instantiate(pref5, new Vector3(.4f, 1.2f, 0f), Quaternion.identity);
                break;
            case 6:
                figuraActual = Instantiate(pref6, new Vector3(.4f, 1.2f, 0f), Quaternion.identity);
                break;
            case 7:
                figuraActual = Instantiate(pref7, new Vector3(.4f, 1.2f, 0f), Quaternion.identity);
                break;
            
        }
        SFigura figura = new SFigura(new Vector3(.4f, 1.2f, 0), figuraActual);
        figuras.Add(figura);
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
