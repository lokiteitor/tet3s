using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// >:D>--< destruccion
public class destruccion : MonoBehaviour {

    private juego j;
    public GameObject elJuego;
    private int band;
    int[] alt = new int[4];
    // Use this for initialization
    void Start () {
        j = elJuego.GetComponent<juego>();
    }
	
	// Update is called once per frame
	public void verificar() {//verificar si se destruye una linea;

        int c=0;//cosas importantes
        //bool a;
        int y;
        int posit;
        
        for(int x= 0;x <=3; x++)//piezas
        {
            posit = j.getPos(x, false);
            
            //a = true;
            /*for (y = 0; y <= 3; y++)//verificamos si la linea no fue destruida ya
                if (alt[y] == j.getPos(x, false))
                    a = false;
              */  
            //if (a)
            for(int z=0; z<=3;z++)//caras
            {
                band = 0;
                for (y = 0; y <= 3; y++)
                {
                    if (j.jueg[y, posit, z] != null)
                        band++;
                }
                if (z <= 2)
                    c = z + 1;
                else
                    c = 0;
                //print(band+"-"+z);
                if (j.jueg[0, posit, c] != null)
                    band++;
                //print(band);
                if (band >= 5)
                    doIt(posit,z);
                alt[x] = posit;
            }
        }
    }

    private void doIt(int O, int c)//destruyelo david 
    {
        //destruir piezas
        //mamada
        GameObject[] db = new GameObject[5];
        
        db[0] = j.jueg[0, O, c];
        db[1] = j.jueg[1, O, c];
        db[2] = j.jueg[2, O, c];
        db[3] = j.jueg[3, O, c];

        if (c <= 2)
            db[4] = j.jueg[0, O, c+1];
        else
            db[4] = j.jueg[0, O, 0];
        /*for (int x = 0; x <= 4; x++)
            print(x + ".-." + (db != null));*/
        Destroy(db[0]);
        Destroy(db[1]);
        Destroy(db[2]);
        Destroy(db[3]);
        Destroy(db[4]);
        
    }
}
