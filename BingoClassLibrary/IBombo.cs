using System.Collections.Generic;

namespace BingoClassLibrary
{
    public interface IBombo
    {
        HashSet<IBola> Bolas { get; }
        int NumeroBolas { get; }

        IBola ElegirBola();
        bool EstaBola(IBola bola);
        void MeterBola(IBola bola);
        void Rellenar();
        void SacarBola(IBola bola);
    }
}