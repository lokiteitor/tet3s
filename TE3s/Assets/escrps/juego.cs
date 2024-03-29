﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class juego : MonoBehaviour , KinectGestures.GestureListenerInterface
{
    private GameObject actual;//elobjeto utilizado
    public GameObject[] actualSon;
    public GameObject[,,] jueg;//mapa de objetos a destruir <3 [x][y][cara]
    public GameObject pref1;//prefabs
    public GameObject pref2;
    public GameObject pref3;
    public GameObject pref4;
    public GameObject pref5;
    public GameObject pref6;
    public GameObject pref7;
    public GameObject camara;
    private fin cam;
    private float[] posicion;//posicion de la pieza moviendose
    private float tiempo;//cuanto tiempo se espero por cada avanse
    private float tiempoTr;//tiempo transcurrido desde la ultima pasada
    public int cara;
    public GameObject baseJ;
    private destruccion destruct;
    public int equis;//x
    public int ye;//y
    private bool autoChangeAlfterDelay = false;
    public KinectManager manager;
    //private Vector3[] actualPi;//posicion de las piezas

    void Start ()
    {// Use this for initialization
        cam = camara.GetComponent<fin>();
        this.posicion = new float[2];
        tiempo = 1.5f;
        tiempoTr = 0f;
        //actualPi = new Vector3[4];
        cara = 0;
        jueg = new GameObject[5, 11, 4];
        actualSon = new GameObject[4];
        generar();
        destruct = baseJ.GetComponent<destruccion>();
    }

	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("d") && (this.posicion[0] + 0.2f) < 0.4f)//mover lado
            moverL(1);
        else if (Input.GetKeyDown("a"))//mover otro lado
            moverL(-1);
        else if (Input.GetKeyDown("s"))//rotar
            rotar();



        bajarPieza();

    }

    private void rotar()
    {
        bool a=true;
        int ca = cara, ex;
        actual.transform.Rotate(Vector3.right * 90);
        for(int x=0; x < 4; x++)
        {
            equis = redondear(actualSon[x].transform.position.z) + 2;
            ye = redondear(actualSon[x].transform.position.y) - 1;
            ex = equis;
            if(equis > 3)
            {
                ex = 0;
                if (cara <= 2)
                    ca++;
                else
                    ca = 0;
            }
            if ((equis > 4 || equis < 0 || ye < 0) && a)
            {
                actual.transform.Rotate(Vector3.right * -90);
                a = false;
            }else if(jueg[ex, ye, ca] != null)
            {
                actual.transform.Rotate(Vector3.right * -90);
                a = false;
            }
        }
    }

    private void moverL(int lado)//mover a los lados
    {
        bool t = true;
        //print(":|");
        for (int x = 0; x < 4 && t; x++)
        {
            equis = redondear(actualSon[x].transform.position.z) + 2;
            //ye =  Mathf.CeilToInt(5f * (actualSon[x].transform.position.y - 0.2f));
            ye = redondear(actualSon[x].transform.position.y) - 1;
            //print(x+"-"+ye + " " + equis);
            if ((equis + lado) > 4 || (equis + lado) < 0)
                t = false;
            else
            {
                //try
                //{

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

                /*}
                catch
                {
                    print("lo intente");
                }*/
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
                destruct.verificar();
                Destroy(actual);
                cam.finich();
                generar();
                tiempo -= 0.03f;
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
            ye = redondear(actualSon[x].transform.position.y)-1;

            // meter la pieza al mapa
            /*if (equis < 0)
                moverL(1);
            if (equis > 4)
                moverL(-1);
                */
            if (ye <= 0)
                return false;
            else if (equis < 4)
            {
                if (jueg[equis,ye-1, cara] != null)
                    return false;
            }else
            {
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
            //print(equis+"-"+ye+"-"+cara);
            if(equis<=3)
                jueg[equis, ye, cara] = actualSon[x];
            else
                if(cara <=2)
                    jueg[0, ye, cara+1] = actualSon[x];
                else
                    jueg[0, ye, 0] = actualSon[x];

        }
    }

    public int getPos(int p, bool cor)//cordenadas de la cosa esa (pieza, x=t o y=f)
    {
        if (actualSon[p] != null)
        {
            if (cor)
                return redondear(actualSon[p].transform.position.z) + 2;
            else
                return redondear(actualSon[p].transform.position.y) - 1;
        }
        return 9;
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

    public void UserDetected(uint userId, int userIndex)
    {

        manager.DetectGesture(userId, KinectGestures.Gestures.RaiseLeftHand);
        manager.DetectGesture(userId, KinectGestures.Gestures.RaiseRightHand);
        manager.DetectGesture(userId, KinectGestures.Gestures.Jump);
        Debug.Log("Usuario Detectado");
    }

    public void UserLost(uint userId, int userIndex)
    {
        // TODO : pasar el juego;
        return;
    }

    public void GestureInProgress(uint userId, int userIndex, KinectGestures.Gestures gesture, float progress, KinectWrapper.NuiSkeletonPositionIndex joint, Vector3 screenPos)
    {
        // esperar
        Debug.Log("Gesto en progreso" + gesture);        
        return;
    }

    public bool GestureCompleted(uint userId, int userIndex, KinectGestures.Gestures gesture, KinectWrapper.NuiSkeletonPositionIndex joint, Vector3 screenPos)
    {
    	Debug.Log(gesture);
        // se completo el swiftleft
        if(gesture == KinectGestures.Gestures.RaiseRightHand)
        {
            // aplicar el codigo de 'd'
            moverL(1);

        }
        if(gesture == KinectGestures.Gestures.RaiseLeftHand)
        {
            // aplicar el codigo 'a'
            moverL(-1);
        }
        if(gesture == KinectGestures.Gestures.Jump)
        {
            rotar();
        }

        return true;
    }

    public bool GestureCancelled(uint userId, int userIndex, KinectGestures.Gestures gesture, KinectWrapper.NuiSkeletonPositionIndex joint)
    {
        return true;
    }
}
