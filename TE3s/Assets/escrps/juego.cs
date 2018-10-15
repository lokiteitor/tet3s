using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class juego : MonoBehaviour {
    private GameObject actual;//elobjeto utilizado
    private GameObject[][][] jueg;//mapa de objetos a destruir <3
    public GameObject pref1;//prefabs
    public GameObject pref2;
    public GameObject pref3;
    public GameObject pref4;
    public GameObject pref5;
    public GameObject pref6;
    public GameObject pref7;
    private float[] posicion;
    // Use this for initialization
    void Start () {
        generar();
        posicion = new float[2];
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("d") && (posicion[0]+0.2f)<0.4f)
        {
            moverL(1);
        }
        else if (Input.GetKeyDown("a") && (posicion[0] + 0.2f) > -0.4f)
        {
            moverL(-1);
        }
    }
    
    private void moverL(int lado)//mover a los lados
    {
        posicion[0] += (lado * 0.2f);
        actual.transform.position = new Vector3(posicion[0], posicion[1], 0);
    }

    private void generar()//genera aleatoriamente las figuras
    {
        switch (Random.Range(1, 8))
        {
            case 1:
                actual = Instantiate(pref1, new Vector3(.4f, 1.2f, 0f), Quaternion.identity);
                break;
            case 2:
                actual = Instantiate(pref2, new Vector3(.4f, 1.2f, 0f), Quaternion.identity);
                break;
            case 3:
                actual = Instantiate(pref3, new Vector3(.4f, 1.2f, 0f), Quaternion.identity);
                break;
            case 4:
                actual = Instantiate(pref4, new Vector3(.4f, 1.2f, 0f), Quaternion.identity);
                break;
            case 5:
                actual = Instantiate(pref5, new Vector3(.4f, 1.2f, 0f), Quaternion.identity);
                break;
            case 6:
                actual = Instantiate(pref6, new Vector3(.4f, 1.2f, 0f), Quaternion.identity);
                break;
            case 7:
                actual = Instantiate(pref7, new Vector3(.4f, 1.2f, 0f), Quaternion.identity);
                break;
        }

        posicion[0] = 0.4f;
        posicion[1] = 1.2f;
    }
}
