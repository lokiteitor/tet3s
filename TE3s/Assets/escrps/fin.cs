using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fin : MonoBehaviour {//yo soy el inicio y el fin >:D
    public GameObject juego;
    private juego j;
    public GameObject basse;
    private rotarBase bas;
    bool a=false;

    // Use this for initialization
    void Awake () {
        j = juego.GetComponent<juego>();
        bas = basse.GetComponent<rotarBase>();
	}

    // Update is called once per frame
    private void Update()
    {
        if (a)
            vueltas();
    }


    public void finich()
    {
        for (int c = 0; c <= 3; c++)
        {
            for (int x = 0; x <= 3; x++)
            {
                if (j.jueg[x, 7, c] != null)
                    perder();
            }
        }
    }

    private void perder()
    {
        print("perdistes");
        juego.SetActive(false);
        //basse.SetActive(false);
        a = true;

    }

    private void vueltas()
    {
        basse.transform.Rotate(Vector3.forward * Time.deltaTime * 120);
    }
}
