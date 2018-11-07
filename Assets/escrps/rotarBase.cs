using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotarBase : MonoBehaviour {
    int x;
    float angulo;//se usa para girar
    float comparador;//se usa para detener el giro
    float falta;//cuanto falta para 90 grgados
    // Use this for initialization
    void Start () {
        x = 0;
        angulo = 0;
        comparador=0;
    }
	
	// Update is called once per frame
	void Update () {

        switch (x)
        {
            case 0://no señal de vida
                if (Input.GetKeyDown("e"))
                {
                    if (angulo >= 270)
                        angulo = 355;
                    else
                        angulo += 90;
                    x = 1;
                }
                else if (Input.GetKeyDown("q"))
                    {
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

    private void rotar(float a)//rotar
    {
        transform.Rotate(Vector3.forward*Time.deltaTime * 120 * a);
        //print(transform.eulerAngles.y + "=" + angulo);
        if ((transform.eulerAngles.y >= angulo && x == 1) || (transform.eulerAngles.y <= angulo && x == 2))
        {
            this.x = 0;
            actual(transform.eulerAngles.y);
        }
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
    }
}
