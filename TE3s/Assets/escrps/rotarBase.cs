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
        if (x == 0)
        {
            if (Input.GetKeyDown("e"))
            {
                x = 1;
                angulo += 90;
                if (angulo > 360)
                    angulo = 0;
            }
            if (Input.GetKeyDown("q"))
            {
                angulo -= 90;
                x = 2;
                if (angulo < 0)
                    angulo = 360;
            }
        }

        if (x == 1)
            rotar(1);
        else
        if (x == 2)
            rotar(-1);
    }

    private void rotar(float a)
    {
        print(transform.eulerAngles.z +"-"+ transform.eulerAngles.y +"-"+ transform.eulerAngles.z);
        transform.Rotate(Vector3.forward*Time.deltaTime * 90 * a);

        if ((transform.eulerAngles.y >= angulo && x==1) || (transform.eulerAngles.y <= angulo && x==2))
            x = 0;
    }
}
