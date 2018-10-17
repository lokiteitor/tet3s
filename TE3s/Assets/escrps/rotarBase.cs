using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotarBase : MonoBehaviour {
    int x;
    float angulo;
    // Use this for initialization
    void Start () {
        x = 0;
        angulo = 0;

    }
	
	// Update is called once per frame
	void Update () {

        switch (x)
        {
            case 0://no señal de vida
                if (Input.GetKeyDown("e"))
                {
                    if (angulo >= 360)
                        angulo = 0;
                    x = 1;
                    angulo += 90;

                }
                else if (Input.GetKeyDown("q"))
                    {
                        if (angulo <= 0)
                            angulo = 360;
                        angulo -= 90;
                        x = 2;
                    }
            break;
            case 1://lado
                rotar(1);
                x = 0;
                break;
            case 2://el otro
                rotar(-1);
                x = 0;
                break;
            

        }
    }

    private void rotar(float a)//rotar
    {
     
            //Debug.Log(transform.eulerAngles.y + "-" + angulo);
            transform.Rotate(Vector3.forward * Time.deltaTime * 90 * a);
        print(angulo);
        
        if ((transform.eulerAngles.x >= angulo && x == 1) || (transform.eulerAngles.x <= angulo && x == 2))
        {
            x = 0;
            actual();
        }
    }

    private void actual()//dejamos en numero exactos el pedo
    {
        float y = transform.eulerAngles.x;

        if ((y < 45 && y >= 0) || (y > 315 && y <= 360))
        {
            transform.rotation = Quaternion.AngleAxis(0, Vector3.right);
            angulo = 0;
        }
        else if (y >= 45 && y < 135)
        {
            transform.rotation = Quaternion.AngleAxis(90, Vector3.right);
            angulo = 90;
        }
        else if (y >= 135 && y < 225)
        {
            transform.rotation = Quaternion.AngleAxis(180, Vector3.right);
            angulo = 180;
        }
        else if (y >= 225 && y < 315)
        {
            transform.rotation = Quaternion.AngleAxis(270, Vector3.right);
            angulo = 270;
        }
    }
}
