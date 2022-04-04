using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BingoClassLibrary;
using System.Collections.Generic;

namespace BingoUnitTestProject
{
    [TestClass]
    public class BingoUnitTest
    {
        [TestMethod]
        public void ConstructorBola_SinParametros_EsNoNulo()
        {
            IBola bola = new Bola();
            Assert.IsNotNull(bola);
         }

        [TestMethod]
        public void NumeroBola_AsignaValorUno_EsIgualAUno()
        {
            IBola bola = new Bola();
            bola.Numero = 1;
            Assert.AreEqual(bola.Numero, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NumeroBola_AsignaValorCero_Exception()
        {
            IBola bola = new Bola();
            bola.Numero = 0;            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NumeroBola_AsignaValorMayor90_Exception()
        {
            IBola bola = new Bola();
            bola.Numero = 91;
        }

        [TestMethod]
        public void ConstructorBombo_SinParametros_EsNoNulo()
        {
            IBombo bombo = new Bombo();
            Assert.IsNotNull(bombo);
        }

        [TestMethod]
        public void NumeroBolasBombo_Inicial_EsIgualACero()
        {
            IBombo bombo = new Bombo();
            Assert.AreEqual(bombo.NumeroBolas,0);
        }

        [TestMethod]
        public void NumeroBolasBombo_MeterUnaBola_EsIgualAUno()
        {
            IBombo bombo = new Bombo();
            IBola bola = new Bola();
            bola.Numero = 1;
            bombo.MeterBola(bola);
            Assert.AreEqual(bombo.NumeroBolas, 1);
        }

        [TestMethod]
        public void EstaBolaBombo_MeterUnaBola_EsCierto()
        {
            IBombo bombo = new Bombo();
            IBola bola = new Bola();
            bola.Numero = 1;
            bombo.MeterBola(bola);
            bool estaBola = bombo.EstaBola(bola);
            Assert.IsTrue(estaBola);
        }

        [TestMethod]
        public void EstaBolaBombo_MeterMisnaBolaDosVeces_EsCierto()
        {
            IBombo bombo = new Bombo();
            IBola bola = new Bola();
            bola.Numero = 1;
            bombo.MeterBola(bola);
            Bola mismaBola = new Bola();
            mismaBola.Numero = 1;
            bool estaBola = bombo.EstaBola(mismaBola);
            Assert.IsTrue(estaBola);
        }

        [TestMethod]
        public void Igualdad_DosBolasDistintasMismoNumero_EsCierto()
        {
            IBola bola = new Bola();
            bola.Numero = 1;
            IBola otraBola = new Bola();
            otraBola.Numero = 1;
            Assert.IsTrue(bola.Equals(otraBola));
        }

        [TestMethod]
        public void EstaBolaBombo_MeterBolaBomboCreadoCambiarlaNoEstaDentroTest()
        {
            IBombo bombo = new Bombo();
            IBola bola = new Bola();
            bola.Numero = 1;
            bombo.MeterBola(bola);
            bola.Numero = 2;
            bool estaBola = bombo.EstaBola(bola);
            Assert.IsFalse(estaBola);
        }

        [TestMethod]
        public void EstaBolaBombo_MeterYSacarMismaBola_esFalso()
        {
            IBombo bombo = new Bombo();
            IBola bola = new Bola();
            bola.Numero = 1;
            bombo.MeterBola(bola);
            bombo.SacarBola(bola);
            bool estaBola = bombo.EstaBola(bola);
            Assert.IsFalse(estaBola);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SacarBolaBombo_SinMeter_Excepcion()
        {
            IBombo bombo = new Bombo();
            IBola bola = new Bola();
            bola.Numero = 1;
            bombo.SacarBola(bola);
        }

        [TestMethod]
        public void NumeroBolasBombo_Metidas90_Es90()
        {
            IBombo bombo = new Bombo();
            for (int i = 0; i < 90; i++)
            {
                IBola bola = new Bola();
                bola.Numero = i+1;
                bombo.MeterBola(bola);
            }            
            Assert.AreEqual(bombo.NumeroBolas,90);
        }

        [TestMethod]
        public void NumeroBolasBombo_Metidas90YSacadas90_Es0()
        {
            IBombo bombo = new Bombo();
            for (int i = 0; i < 90; i++)
            {
                IBola bola = new Bola();
                bola.Numero = i + 1;
                bombo.MeterBola(bola);
            }
            for (int i = 0; i < 90; i++)
            {
                IBola bola = new Bola();
                bola.Numero = i + 1;
                bombo.SacarBola(bola);
            }
            Assert.AreEqual(bombo.NumeroBolas, 0);
        }

        [TestMethod]
        public void NumeroBolasBombo_MetidaMismaDosVeces_Es1()
        {
            IBombo bombo = new Bombo();
            IBola bola = new Bola();
            bola.Numero = 1;
            bombo.MeterBola(bola);
            bombo.MeterBola(bola);
            Assert.AreEqual(bombo.NumeroBolas, 1);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SacarBolaBombo_DespuesDeMetidaYSacada_Excepcion()
        {
            IBombo bombo = new Bombo();
            IBola bola = new Bola();
            bola.Numero = 1;
            bombo.MeterBola(bola);
            bombo.SacarBola(bola);
            bombo.SacarBola(bola);
        }

        [TestMethod]
        public void NextRamdom_Entre1y91_Valores1y90Incluidos()
        {            
            Random ramdom = new Random(DateTime.Now.Millisecond);
            int numeroAleatorio = ramdom.Next(1, 91);
            Assert.IsTrue((numeroAleatorio >= 1 && numeroAleatorio <= 90));
        }

        [TestMethod]
        public void EstaBolaBombo_SacarBolaAleatoriaDeBomboLleno_EsFalso()
        {
            Random ramdom = new Random(DateTime.Now.Millisecond);
            int numeroAleatorio = ramdom.Next(1, 91);
            IBola bolaAleatoria = new Bola();
            bolaAleatoria.Numero = numeroAleatorio;

            IBombo bombo = new Bombo();
            for (int i = 0; i < 90; i++)
            {
                IBola bola = new Bola();
                bola.Numero = i + 1;
                bombo.MeterBola(bola);
            }

            bombo.SacarBola(bolaAleatoria);
            Assert.IsFalse(bombo.EstaBola(bolaAleatoria));
        }

        [TestMethod]
        public void EstaBolaBombo_SacarBolaAleatoriaDeBomboAleatorio_EsFalso()
        {
            IBombo bombo = new Bombo();
            Random ramdom = new Random(DateTime.Now.Millisecond);
            int totalAleatorio = ramdom.Next(1, 91);
            for (int i = 0; i < totalAleatorio; i++)
            {
                IBola bola = new Bola();
                int numeroAleatorio = ramdom.Next(1, 91);
                bola.Numero = numeroAleatorio;
                bombo.MeterBola(bola);
            }

            IBola bolaAleatoria = bombo.ElegirBola();

            bombo.SacarBola(bolaAleatoria);
            Assert.IsFalse(bombo.EstaBola(bolaAleatoria));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SacarBolaBombo_MeterYSacarMismasBolasAleatoriamente_Excepcion()
        {
            IBombo bombo = new Bombo();
            Random ramdom = new Random(DateTime.Now.Millisecond);
            int totalAleatorio = ramdom.Next(1, 91);
            for (int i = 0; i < totalAleatorio; i++)
            {
                IBola bola = new Bola();
                int numeroAleatorio = ramdom.Next(1, 91);
                bola.Numero = numeroAleatorio;
                bombo.MeterBola(bola);
                bombo.SacarBola(bola);
            }

            int numeroAleatorioSacar = ramdom.Next(1, 91);
            IBola bolaAleatoria = bombo.ElegirBola();

            bombo.SacarBola(bolaAleatoria);
        }

        [TestMethod]
        public void ConstructorCarton_Parametro15_EsNoNulo()
        {
            ICarton carton = new Carton(15);
            Assert.IsNotNull(carton);
        }

        [TestMethod]
        public void NumeroBolasSinTacharCarton__Parametro15_EsIgualA15()
        {
            ICarton carton = new Carton(15);
            Assert.AreEqual(carton.NumeroBolasSinTachar,15);
        }

        [TestMethod]
        public void NumeroBolasSinTacharCarton_SacarTodasLasBolasDeBomboYTacharCarton_EsCero()
        {
            IBombo bombo = new Bombo();
            for (int i = 0; i < 90 ; i++)
            {
                IBola bola = new Bola();
                bola.Numero = i + 1;
                bombo.MeterBola(bola);
            }
            ICarton carton = new Carton(15);
            for (int i = 0; i < 90; i++)
            {
                IBola bola = new Bola();
                bola.Numero = i + 1;
                bombo.SacarBola(bola);
                carton.TacharBola(bola);
            }
            Assert.AreEqual(carton.NumeroBolasSinTachar, 0);
        }

        [TestMethod]
        public void NumeroBolasSinTacharCarton2_SacarTodasLasBolasDeBomboYTacharCarton_EsCero()
        {
            IBombo bombo = new Bombo();
            for (int i = 0; i < 90; i++)
            {
                IBola bola = new Bola();
                bola.Numero = i + 1;
                bombo.MeterBola(bola);
            }
            ICarton carton = new Carton2(15,bombo);
            for (int i = 0; i < 90; i++)
            {
                IBola bola = new Bola();
                bola.Numero = i + 1;
                bombo.SacarBola(bola);
            }
            Assert.AreEqual(carton.NumeroBolasSinTachar, 0);
        }

        [TestMethod]
        public void NumeroBolasSinTachar_DinamicaJuego1000Cartones_EsCero()
        {
            IBombo bombo = new Bombo();
            bombo.Rellenar();
            List<ICarton> cartones = new List<ICarton>();
            List<ICarton> cartonesGanadores = new List<ICarton>();
            for (int i = 0; i < 1000; i++)
            {
                cartones.Add(new Carton(15));
            }
            bool finJuego = false;
            while (!finJuego)
            {
                IBola bola = bombo.ElegirBola();
                bombo.SacarBola(bola);
                foreach (ICarton carton in cartones)
                {
                    carton.TacharBola(bola);
                    if (carton.NumeroBolasSinTachar == 0) cartonesGanadores.Add(carton);
                    finJuego = (carton.NumeroBolasSinTachar == 0);
                }
            }
            Assert.IsTrue(finJuego);
        }

        [TestMethod]
        public void NumeroBolasSinTachar_DinamicaJuego1000Cartones2_EsCero()
        {
            IBombo bombo = new Bombo();
            bombo.Rellenar();
            List<ICarton> cartones2 = new List<ICarton>();
            List<ICarton> cartones2Ganadores = new List<ICarton>();
            for (int i = 0; i < 1000; i++)
            {
                cartones2.Add(new Carton2(15,bombo));
            }
            bool finJuego = false;
            while (!finJuego)
            {
                IBola bola = bombo.ElegirBola();
                bombo.SacarBola(bola);
                foreach (ICarton carton2 in cartones2)
                {
                    if (carton2.NumeroBolasSinTachar == 0) cartones2Ganadores.Add(carton2);
                    finJuego = (carton2.NumeroBolasSinTachar == 0);
                }
            }
            Assert.IsTrue(finJuego);
        }


    }
}
