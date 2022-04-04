using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BingoClassLibrary
{
    public class Carton : ICarton
    {
        HashSet<IBola> _bolas;
       int _numeros;

        public int NumeroBolasSinTachar { get { return _bolas.Count; } }

        public int Count { get { return _numeros; } }

        public HashSet<IBola> Original;

        public Carton(int numeros)
        {
            _numeros = numeros;
            _bolas = new HashSet<IBola>();            
            Rellenar();
            Original = new HashSet<IBola>(_bolas);
            
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
            _bolas.Remove(bola);
        }

    }
}
