using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class juego : MonoBehaviour {
    private GameObject actual;//elobjeto utilizado
    private GameObject[][][] jueg;//mapa de objetos a destruir <3 [x][y][cara]
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
        if (Input.GetKeyDown("d") && (this.posicion[0]+0.2f)<0.4f)
            moverL(1);
        else if (Input.GetKeyDown("a") && (this.posicion[0] + 0.2f) > -0.4f)
            moverL(-1);
    }
    
    private void moverL(int lado)//mover a los lados
    {
        this.posicion[0] += (lado * 0.2f);
        this.actual.transform.position = new Vector3(this.posicion[0], this.posicion[1], 0);
    }

    private void generar()//genera aleatoriamente las figuras
    {

        this.posicion[0] = 0.4f;
        this.posicion[1] = 1.2f;

        switch (Random.Range(1, 8))//alguno
        {
            case 1:
                this.actual = Instantiate(pref1, new Vector3(.4f, 1.2f, 0f), Quaternion.identity) as GameObject;
                break;
            case 2:
                this.actual = Instantiate(pref2, new Vector3(.4f, 1.2f, 0f), Quaternion.identity) as GameObject;
                break;
            case 3:
                this.actual = Instantiate(pref3, new Vector3(.4f, 1.2f, 0f), Quaternion.identity) as GameObject;
                break;
            case 4:
                this.actual = Instantiate(pref4, new Vector3(.4f, 1.2f, 0f), Quaternion.identity) as GameObject;
                break;
            case 5:
                this.actual = Instantiate(pref5, new Vector3(.4f, 1.2f, 0f), Quaternion.identity) as GameObject;
                break;
            case 6:
                this.actual = Instantiate(pref6, new Vector3(.4f, 1.2f, 0f), Quaternion.identity) as GameObject;
                break;
            case 7:
                this.actual = Instantiate(pref7, new Vector3(.4f, 1.2f, 0f), Quaternion.identity) as GameObject;
                break;
            
        }

        
    }

    /*private void mapear()
    {
        //Position = .2x - .4
        Vector3 vt = new Vector3();
        foreach(Transform children in actual.transform)
        {
            children.transform.parent = transform;
            vt = children.position;
            jueg
        }
    }*/
}
