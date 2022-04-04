namespace BingoClassLibrary
{
    public interface ICarton
    {
        int Count { get; }
        int NumeroBolasSinTachar { get; }

        void TacharBola(IBola bola);
        void Rellenar();
    }
}