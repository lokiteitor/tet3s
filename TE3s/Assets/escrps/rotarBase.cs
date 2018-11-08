using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotarBase : MonoBehaviour {
    int x;
    float angulo;//se usa para girar
    float comparador;//se usa para detener el giro
    float falta;//cuanto falta para 90 grgados
    int fais;
    public GameObject juego;
    private juego escrip;
    // Use this for initialization
    private void Awake()
    {
        escrip = juego.GetComponent<juego>();
    }

    void Start () {
        x = 0;
        angulo = 0;
        comparador=0;
        fais = 0;
    }


	// Update is called once per frame
	void Update () {

        switch (x)
        {
            case 0://no señal de vida
                if (Input.GetKeyDown("e") && verifGir(1))//girar
                {
                    juego.SetActive(false);//apagamos el bajado
                    if (angulo >= 270)
                        angulo = 355;
                    else
                        angulo += 90;
                    x = 1;
                }
                else if (Input.GetKeyDown("q") && verifGir(-1))
                    {
                    juego.SetActive(false);
                    if (angulo == 0)
                        angulo = 275;
                    else if (angulo <= 90)
                        angulo = 5;
                    else
                        angulo -= 90;
                        x = 2;
                    }
                break;
            case 1://lado
                rotar(1);
                //x = 0;
                break;
            case 2://el otro
                rotar(-1);
                //x = 0;
                break;
        }
    }

    private void rotar(int a)//rotar
    {
        transform.Rotate(Vector3.forward*Time.deltaTime * 120 * (float)a);
        //print(transform.eulerAngles.y + "=" + angulo);
        if ((transform.eulerAngles.y >= angulo && x == 1) || (transform.eulerAngles.y <= angulo && x == 2))
        {
            this.x = 0;

            actual(transform.eulerAngles.y);
            actCara(a);
        }
    }

    private void actCara(int a)//
    {
        escrip.cara += a;

        if (escrip.cara >= 4 || escrip.cara<=-1)
            escrip.cara = 0;
        fais = escrip.cara;
    }

    private void actual(float y)//dejamos en numero exactos el pedo
    {
        try
        {
            if ((y < 45 && y >= 0) || (y > 315 && y <= 360))
            {
                //print("1");
                transform.eulerAngles = new Vector3(270.0f, 0.0f, 0.0f);
                angulo = 0;
            }
            else if (y >= 45 && y < 135)
            {
                //print("2");
                transform.eulerAngles = new Vector3(270.0f, 0.0f, 0.0f);
                transform.Rotate(Vector3.forward * 90);
                angulo = 90;
            }
            else if (y >= 135 && y < 225)
            {
                //print("3");
                transform.eulerAngles = new Vector3(270.0f, 0.0f, 0.0f);
                transform.Rotate(Vector3.forward * 180);
                angulo = 180;
            }
            else if (y >= 225 && y < 315)
            {
                //print("4");
                transform.eulerAngles = new Vector3(270.0f, 0.0f, 0.0f);
                transform.Rotate(Vector3.forward * 270);
                angulo = 270;
            }
        }
        catch
        {
            print("damn");
        }

        juego.SetActive(true);
    }

    private bool verifGir(int a)
    {
        int ex, y, f;//equis ye feis
        f = escrip.cara + a;
        if (f >= 4 || f <= -1)
            f = 0;
        for (int b = 0; b<=3; b++)
        {
            ex = escrip.getPos(b, true);
            y = escrip.getPos(b, false);

            if(escrip.jueg[ex, y, f] != null)
            {
                //mandar señal de que no se puede
                print("huevos");
                return false;
            }
        }
        return true;
    }
}
