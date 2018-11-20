using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// >:D>--< destruccion
public class destruccion : MonoBehaviour {

    private juego j;
    public GameObject elJuego;
    private int band;
    //int[] alt = new int[4];
    // Use this for initialization
    void Start () {
    }

    private void Awake()
    {
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

                if(posit<=8)
                    for (int z = 0; z <= 3; z++)//caras
                    {
                        band = 0;
                        for (y = 0; y <= 3; y++)//filas
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
                        {
                            band++;
                            if (band >= 5)
                            {
                                doIt(posit, z);
                                bajar(z);
                                z--;
                            }
                        }
                        //alt[x] = posit;
                        //print("uno");
                    }
            
        }
    }

    private void doIt(int O, int c)//destruyelo david 
    {
        //destruir piezas

        Destroy(j.jueg[0, O, c]);
        j.jueg[0, O, c] = null;
        Destroy(j.jueg[1, O, c]);
        j.jueg[1, O, c] = null;
        Destroy(j.jueg[2, O, c]);
        j.jueg[2, O, c] = null;
        Destroy(j.jueg[3, O, c]);
        j.jueg[3, O, c] = null;
        print(c+"-"+O);

        try
        {
            if (c <= 2)//esto podria ser lo que truena
                Destroy(j.jueg[0, O, c + 1]);
            else
                Destroy(j.jueg[0, O, 0]);
            if (c <= 2)
                j.jueg[0, O, c + 1] = null;
            else
                j.jueg[0, O, 0] = null;
        }
        catch
        {
            print("damn");
        }
    }

    private void bajar(int ca)
    {
        int car;
        for(int y= 0; y <= 7; y++)
        {
            for (int x = 0; x <= 3; x++) {
                if (j.jueg[x, y+1, ca] != null && j.jueg[x, y, ca] == null)
                {
                    j.jueg[x, y+1, ca].transform.position = new Vector3(j.jueg[x, y + 1, ca].transform.position.x, j.jueg[x, y+1, ca].transform.position.y - 0.2f, j.jueg[x, y+1, ca].transform.position.z);
                    j.jueg[x, y, ca] = j.jueg[x, y + 1, ca];
                    j.jueg[x, y + 1, ca] = null;
                }
            }
            if (ca <= 2)// o esto
                car=ca +1;
            else
                car = 0;
            if (j.jueg[0, y + 1, car] != null && j.jueg[0, y, car] == null)
            {
                j.jueg[0, y + 1, car].transform.position = new Vector3(j.jueg[0, y + 1, car].transform.position.x, j.jueg[0, y + 1, car].transform.position.y - 0.2f, j.jueg[0, y + 1, car].transform.position.z);
                j.jueg[0, y, car] = j.jueg[0, y + 1, car];
                j.jueg[0, y + 1, car] = null;
            }
        }
        //print("3");
    }


    /*private void pabajo(GameObject pie, int x, int y)
    {
        float me = j.jueg[x, y, 0].transform.position.y - 0.2f;
        while (me < j.jueg[x, y, 0].transform.position.y)
        {
            j.jueg[0, y, 0].transform.position = new Vector3(0.4f, j.jueg[x, y, 0].transform.position.y - Time.deltaTime*90, j.jueg[x, y, 0].transform.position.z);
        }
        j.jueg[0, y, 0].transform.position = new Vector3(0.4f, me, j.jueg[0, y, 0].transform.position.z);
    }*/
}
