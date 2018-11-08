using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Figura
{
    public struct SFigura
    {
        public Vector3 posiciones;
        public GameObject figura;
        public SFigura(Vector3 posiciones, GameObject figura)
        {
            this.posiciones = posiciones;
            this.figura = figura;
        }
    }

}
