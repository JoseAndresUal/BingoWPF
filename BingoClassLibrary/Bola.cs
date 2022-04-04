using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BingoClassLibrary
{
    public class Bola :  IEquatable<Bola>, IBola
    {
       
        private int _numero;
        public int Numero
        {
            get { return _numero; }
            set
            {
                if (value < 1 || value > 90) throw new ArgumentOutOfRangeException();
                else _numero = value;
            }
        }

        public Bola()
        {
        }
        public Bola(int numero)
        {
            _numero = numero;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (ReferenceEquals(obj, null)) return false;
            Bola bola = (obj as Bola);
            if (ReferenceEquals(bola, null)) return false;
            else return this.Numero.Equals(bola.Numero);
        }
        public override int GetHashCode()
        {
            return this.Numero.GetHashCode();
        }


        public int GetHashCode(Bola obj)
        {
            return obj.Numero.GetHashCode();
        }

        public bool Equals(Bola other)
        {
           return Equals(this,other);
        }

        public static bool operator ==(Bola a, Bola b)
        {
            if (!(a is null))
            return a.Equals(b);
            if (!(b is null))
                return b.Equals(a);
            return true;
        }
        public static bool operator !=(Bola a, Bola b)
        {
            return !(a==b);
        }

        public override string ToString()
        {
            if (Numero < 0)  return " X ";
            else   return Numero.ToString();
        }
    }
}
