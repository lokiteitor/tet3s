using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapa : MonoBehaviour {
	public int[,,] map;
	// Use this for initialization
	void Start () {
		//[cara,columna,fila]
		map= new int[4,4,10];//no olvidar que la primera columna es la ultima de la cara pasada
		for(int x=0; x<4;x++)
			for(int y=0; y<4;y++)
				for(int z=0; z<10;z++)
					map[x,y,z]=0;
	}

	void verificar(){

		int band;//encontrar lineas a destruir
		for(int x=0; x<4;x++)//cara
			for(int y=0; y<10;y++){//columna
				band=0;
				for(int z=0; z<=4;z++){//fila
						if(z!=4){
							if(map[x,z,y]!=0)
								band++;
						}else{
							if(x!=3)
								if(map[x+1,z,y]!=0)
									band++;
							else
							if(map[0,z,y]!=0)
								band++;
						}
                    
				}
                if (band == 5)
                {
                    //destruir columna Y en cara x y primer cubo de la cara de la derecha
                }
			}
	}

	// Update is called once per frame
	void Update () {

	}
}
