using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BingoClassLibrary
{
    public class Bombo : IBombo
    {
        HashSet<IBola> _bolas = new HashSet<IBola>();

        public int NumeroBolas { get { return _bolas.Count; }  }


        public void MeterBola(IBola bola)
        {
            _bolas.Add(bola);
        }

        public bool EstaBola(IBola bola)
        {
            return _bolas.Contains(bola);
        }

        public void SacarBola(IBola bola)
        {
            if (EstaBola(bola)) _bolas.Remove(bola);
            else throw new ArgumentOutOfRangeException();
           
        }

        public IBola ElegirBola()
        {
            if (NumeroBolas <= 0) throw new ArgumentOutOfRangeException();
            Random ramdom = new Random(DateTime.Now.Millisecond);
            IBola bola = new Bola();
            do
            {
                int numAleatorio = ramdom.Next(1, 91);                
                bola.Numero = numAleatorio;
            }
            while (!EstaBola(bola));
            return bola;
        }

        public HashSet<IBola> Bolas { get { return _bolas; } }

        public void Rellenar()
        {
            for (int i = 0; i < 90; i++)
            {
                IBola bola = new Bola();
                bola.Numero = i + 1;
                this.MeterBola(bola);
            }
        }
    }
}
