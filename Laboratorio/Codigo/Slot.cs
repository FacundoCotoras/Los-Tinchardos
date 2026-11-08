using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TowerDefense
{
    struct Slot
    {
        public Vector2 PosicionTorre;
        public Rectangle AreaConstruccion;
        public bool TorreColocada;
        public TipoTorre Tipo;

    }
}
