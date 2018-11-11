﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class juego : MonoBehaviour {
    private GameObject actual;//elobjeto utilizado
    private GameObject[] actualSon;
    public GameObject[,,] jueg;//mapa de objetos a destruir <3 [x][y][cara]
    public GameObject pref1;//prefabs
    public GameObject pref2;
    public GameObject pref3;
    public GameObject pref4;
    public GameObject pref5;
    public GameObject pref6;
    public GameObject pref7;
    private float[] posicion;//posicion de la pieza moviendose
    private float tiempo;//cuanto tiempo se espero por cada avanse
    private float tiempoTr;//tiempo transcurrido desde la ultima pasada
    public int cara;
    public GameObject baseJ;
    public GameObject dest;
    private destruccion destruct;
    public int equis;//x
    public int ye;//y
    //private Vector3[] actualPi;//posicion de las piezas

    void Start ()
    {// Use this for initialization
        destruct = dest.GetComponent <destruccion>();
        this.posicion = new float[2];
        tiempo = 1.5f;
        tiempoTr = 0f;
        //actualPi = new Vector3[4];
        cara = 0;
        jueg = new GameObject[5, 11, 4];
        actualSon = new GameObject[4];
        generar();
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("d") && (this.posicion[0]+0.2f)<0.4f)//mover lado
            moverL(1);
        else if (Input.GetKeyDown("a") && (this.posicion[0] + 0.2f) > -0.4f)//mover otro lado
            moverL(-1);
        else if (Input.GetKeyDown("s"))//rotar
            actual.transform.Rotate(Vector3.right * 90);

        bajarPieza();


    }

    private void moverL(int lado)//mover a los lados
    {
        bool t = true;
        for (int x = 0; x < 4 && t; x++)
        {
            equis = redondear(actualSon[x].transform.position.z) + 2;
            //ye =  Mathf.CeilToInt(5f * (actualSon[x].transform.position.y - 0.2f));
            ye = redondear(actualSon[x].transform.position.y) - 1;
            print(x+" "+(equis + lado));
            if ((equis + lado) > 4 && (equis + lado) < 0)
                t = false;
            else
                try
                {

                    if ((equis + lado) <= 3)
                    {
                        if (jueg[(equis + lado), ye, cara] != null)
                            t = false;
                    }
                    else if (cara <= 2)
                    {
                        if (jueg[0, ye, cara + 1] != null)
                            t = false;
                    }
                    else if (cara > 2)
                        if (jueg[0, ye, 0] != null)
                            t = false;
                }
                catch
                {
                    print("lo intente");
                }
            
        }
        if (t)
        {
            this.posicion[0] += (lado * 0.2f);
            this.actual.transform.position = new Vector3(0.4f, this.posicion[1], this.posicion[0]);
        }
    }

    private void generar()//genera aleatoriamente las figuras
    {
        switch (Random.Range(1, 8))//alguno
        {
            case 1:
                this.actual = Instantiate(pref1, new Vector3(.4f, 1.6f, 0f), Quaternion.identity) as GameObject;
                break;
            case 2:
                this.actual = Instantiate(pref2, new Vector3(.4f, 1.6f, 0f), Quaternion.identity) as GameObject;
                break;
            case 3:
                this.actual = Instantiate(pref3, new Vector3(.4f, 1.6f, 0f), Quaternion.identity) as GameObject;
                break;
            case 4:
                this.actual = Instantiate(pref4, new Vector3(.4f, 1.6f, 0f), Quaternion.identity) as GameObject;
                break;
            case 5:
                this.actual = Instantiate(pref5, new Vector3(.4f, 1.6f, 0f), Quaternion.identity) as GameObject;
                break;
            case 6:
                this.actual = Instantiate(pref6, new Vector3(.4f, 1.6f, 0f), Quaternion.identity) as GameObject;
                break;
            case 7:
                this.actual = Instantiate(pref7, new Vector3(.4f, 1.6f, 0f), Quaternion.identity) as GameObject;
                break;

        }
        int d = 0;
        foreach (Transform children in actual.transform)
        {
            //print("-" + d);
            this.actualSon[d++] = children.gameObject;
        }
        this.posicion[0] = 0f;
        this.posicion[1] = 1.6f;
    }

    private void bajarPieza()//esta funcion baja la pieza <3
    {//bajar piezas cada deternimado tiempo
        tiempoTr += Time.deltaTime;
        if (tiempoTr >= tiempo )
        {
            if (verifBajar())
            {
                //bajar pieza
                this.posicion[1] -= 0.2f;
                this.actual.transform.position = new Vector3(0.4f, this.posicion[1], this.posicion[0]);
                tiempoTr = 0;
                //mapear();
            }
            else
            {
                mapear();
                for (int p = 0; p < 4; p++)
                {
                    actualSon[p].transform.SetParent(baseJ.transform);
                }
                generar();
            }
        }
    }


    private bool verifBajar()
    {
        //float a;

        for(int x=0; x < 4; x++)//verificar piezas una por una
        {
            //equis =Mathf.CeilToInt((actualSon[x].transform.position.z * 5f) + 3f);
            equis = redondear(actualSon[x].transform.position.z)+2;
            //ye =  Mathf.CeilToInt(5f * (actualSon[x].transform.position.y - 0.2f));
            ye = redondear(actualSon[x].transform.position.y)-1;
            //print (equis+"-"+ye);

            // meter la pieza al mapa
            if (equis < 0)
                moverL(1);
            if (equis > 4)
                moverL(-1);

            if (ye <= 0)
                return false;
            else if (equis < 4)
            {
                if (jueg[equis,ye-1, cara] != null)
                    return false;
            }else
            {
                //print("entra pta");
                int f=cara;
                if (cara == 3)
                {
                    f = -1;
                }
                if (jueg[equis-4, ye-1, (f + 1)] != null)
                    return false;
            }
        }
        return true;
    }


    private void mapear()
    {
        for(int x = 0; x<4; x++)
        {
            //equis =Mathf.CeilToInt((actualSon[x].transform.position.z * 5f) + 3f);
            equis = redondear(actualSon[x].transform.position.z)+2;
            //ye =  Mathf.CeilToInt(5f * (actualSon[x].transform.position.y - 0.2f));
            ye = redondear(actualSon[x].transform.position.y)-1;
            //print(equis+"-"+ye);
            jueg[equis, ye, cara] = actualSon[x];
        }
    }

    public int getPos(int p, bool cor)//cordenadas de la cosa esa (pieza, x=t o y=f)
    {
        if(cor)
            return redondear(actualSon[p].transform.position.z) +2;
        else
            return redondear(actualSon[p].transform.position.y) - 1;
    }

    private int redondear(float pos)//numerito de cordenada
    {
        pos *= 5;
        if (Mathf.Ceil(pos) == Mathf.Floor(pos))
            return Mathf.FloorToInt(pos);
        else if ((pos - Mathf.Floor(pos)) > .5f)
            return Mathf.CeilToInt(pos);
        else
            return Mathf.FloorToInt(pos);
    }
}
