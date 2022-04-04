using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BingoClassLibrary
{
    public class Carton2:ICarton
    {
        HashSet<IBola> _bolas;

        public HashSet<IBola> Bolas
        {
            get { return _bolas; }
            set { _bolas = value; }
        }

        public int NumeroBolasSinTachar { get { return _bombo.Bolas.Intersect(this._bolas).Count(); } }

        public int Count { get { return _numeros; } }

        int _numeros;
        IBombo _bombo;
        public Carton2(int numeros, IBombo bombo)
        {
            _numeros = numeros;
            _bombo = bombo;
            _bolas = new HashSet<IBola>();
            Rellenar();
        }
        public void Rellenar()
        {
            Random ramdom = new Random(DateTime.Now.Millisecond);
            do
            {
                IBola bola = new Bola();
                int numAleatorio = ramdom.Next(1, 91);
                bola.Numero = numAleatorio;
                _bolas.Add(bola);
            }
            while (_bolas.Count < _numeros);
        }
        public void TacharBola(IBola bola)
        {
            
        }

    }
}
