using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Main.Microventas.Facturacion
{
    public class CodigoControImpuestos
    {

        #region "Propiedades"

        public long NroFactura { get; set; }

        public long NumeroAutorizacion { get; set; }

        public long Nit { get; set; }

        public long Fecha { get; set; }

        public long Monto { get; set; }

        public string LlaveDosificacion { get; set; }
        #endregion

        #region "Metodos"

        static long ObtieneVerhoeff(string numero)
        {
            long vVerhoeffDigit;

            int[,] vMul = {
                {0,1,2,3,4,5,6,7,8,9},
                {1,2,3,4,0,6,7,8,9,5},
                {2,3,4,0,1,7,8,9,5,6},
                {3,4,0,1,2,8,9,5,6,7},
                {4,0,1,2,3,9,5,6,7,8},
                {5,9,8,7,6,0,4,3,2,1},
                {6,5,9,8,7,1,0,4,3,2},
                {7,6,5,9,8,2,1,0,4,3},
                {8,7,6,5,9,3,2,1,0,4},
                {9,8,7,6,5,4,3,2,1,0}
            };

            int[,] vPermu = {
                {0,1,2,3,4,5,6,7,8,9},
                {1,5,7,6,2,8,3,0,9,4},
                {5,8,0,3,7,9,6,1,4,2},
                {8,9,1,6,0,4,3,5,2,7},
                {9,4,5,3,1,2,6,8,7,0},
                {4,2,8,6,5,7,3,9,0,1},
                {2,7,9,3,8,0,6,4,1,5},
                {7,0,4,6,9,1,3,2,5,8}
            };

            int[] vInver = { 0, 4, 3, 2, 1, 5, 6, 7, 8, 9 };



            string vCadNumber = "";

            for (int i = 0; i < numero.Length; i++)
            {
                vCadNumber = numero[i] + vCadNumber;
            }

            int vDigit = 0;
            for (int i = 0; i < vCadNumber.Length; i++)
            {
                int vIndexI = Convert.ToInt32(vCadNumber[i].ToString());
                int vIndexJ = vPermu[(i + 1) % 8, vIndexI];
                vDigit = vMul[vDigit, vIndexJ];
            }

            vVerhoeffDigit = vInver[vDigit];
            return vVerhoeffDigit;
        }

        static void Inter(ref int x, ref int y)
        {
            int vInter;
            vInter = x;
            x = y;
            y = vInter;
        }

        static int ObtieneASCII(char car)
        {
            return ASCIIEncoding.ASCII.GetBytes(car.ToString())[0];
        }

        private static long SumASCII(int begin, string cad, int intervalo)
        {
            long vSum = 0;
            for (int i = begin; i < cad.Length; i += intervalo)
            {
                char vChar = cad[i];
                vSum += ObtieneASCII(vChar);
            }
            return vSum;
        }

        static string ObtieneAllegedRC4(string cadConcat, string keyVerhoeff)
        {
            string vResult = "";

            int[] vState = new int[257];

            for (int i = 0; i < 256; i++)
                vState[i] = i;

            int vIndex1 = 0;
            int vIndex2 = 0;

            for (int i = 0; i < 256; i++)
            {
                vIndex2 = (ObtieneASCII(keyVerhoeff[vIndex1]) + vState[i] + vIndex2) % 256;
                Inter(ref vState[i], ref vState[vIndex2]);
                vIndex1 = (vIndex1 + 1) % keyVerhoeff.Length;
            }

            int X = 0;
            int Y = 0;
            int NMen;
            for (int i = 0; i < cadConcat.Length; i++)
            {
                X = (X + 1) % 256;
                Y = (vState[X] + Y) % 256;
                Inter(ref vState[X], ref vState[Y]);
                NMen = ObtieneASCII(cadConcat[i]) ^ (vState[(vState[X] + vState[Y]) % 256]);
                vResult += FillCero(NMen);
            }

            return vResult;
        }

        private static string FillCero(int nMen)
        {
            string vResult;
            vResult = string.Format("{0:x}", nMen);
            if (vResult.Length < 2)
                vResult = "0" + vResult;
            return vResult.ToUpper();
            //return vResult;
        }

        static string ObtieneBase64(long num)
        {
            string vResult = "";
            char[] vDictionary = {
                '0','1','2','3','4','5','6','7','8','9',
                'A','B','C','D','E','F','G','H','I','J',
                'K','L','M','N','O','P','Q','R','S','T',
                'U','V','W','X','Y','Z','a','b','c','d',
                'e','f','g','h','i','j','k','l','m','n',
                'o','p','q','r','s','t','u','v','w','x',
                'y','z','+','/'
            };

            long vCociente = 1;
            long vResto;

            while (vCociente > 0)
            {
                vCociente = num / 64;
                vResto = num % 64;
                vResult = vDictionary[vResto] + vResult;
                num = vCociente;
            }

            return vResult;
        }

        public string GeneraCodigoControl()
        {
            string vResult = "";
            long vNroFactura;
            long vNit;
            long vFecha;
            long vMonto;

            long vNumeroAutorizacion = NumeroAutorizacion;
            string vCadInvoiceNumber = NroFactura.ToString();
            string vCadNit = Nit.ToString();
            string vCadDate = Fecha.ToString();
            string vCadAmount = Monto.ToString();

            vCadInvoiceNumber = vCadInvoiceNumber + ObtieneVerhoeff(vCadInvoiceNumber);
            vCadInvoiceNumber = vCadInvoiceNumber + ObtieneVerhoeff(vCadInvoiceNumber);

            vCadNit = vCadNit + ObtieneVerhoeff(vCadNit);
            vCadNit = vCadNit + ObtieneVerhoeff(vCadNit);

            vCadDate = vCadDate + ObtieneVerhoeff(vCadDate);
            vCadDate = vCadDate + ObtieneVerhoeff(vCadDate);

            vCadAmount = vCadAmount + ObtieneVerhoeff(vCadAmount);
            vCadAmount = vCadAmount + ObtieneVerhoeff(vCadAmount);

            vNroFactura = Convert.ToInt64(vCadInvoiceNumber);
            vNit = Convert.ToInt64(vCadNit);
            vFecha = Convert.ToInt64(vCadDate);
            vMonto = Convert.ToInt64(vCadAmount);
            long vSum = vNroFactura + vNit + vFecha + vMonto;

            string vSumPartial = vSum.ToString();
            int[] vDigitsVerhoeff = new int[5];

            vDigitsVerhoeff[0] = (int)ObtieneVerhoeff(vSumPartial);
            vSumPartial = vSumPartial + vDigitsVerhoeff[0];

            vDigitsVerhoeff[1] = (int)ObtieneVerhoeff(vSumPartial);
            vSumPartial = vSumPartial + vDigitsVerhoeff[1];

            vDigitsVerhoeff[2] = (int)ObtieneVerhoeff(vSumPartial);
            vSumPartial = vSumPartial + vDigitsVerhoeff[2];

            vDigitsVerhoeff[3] = (int)ObtieneVerhoeff(vSumPartial);
            vSumPartial = vSumPartial + vDigitsVerhoeff[3];

            vDigitsVerhoeff[4] = (int)ObtieneVerhoeff(vSumPartial);
            vSumPartial = vSumPartial + vDigitsVerhoeff[4];

            string vCadDigitsVerhoeff = "";
            for (int i = 0; i < 5; i++)
            {
                vCadDigitsVerhoeff += vDigitsVerhoeff[i];
                vDigitsVerhoeff[i]++;
            }

            string vCad0 = "", vCad1 = "", vCad2 = "", vCad3 = "", vCad4 = "";

            int vSumLength = 0;
            if (LlaveDosificacion.Length > (vSumLength + vDigitsVerhoeff[0]))
            {
                vCad0 = LlaveDosificacion.Substring(0, vDigitsVerhoeff[0]);
                vSumLength += vDigitsVerhoeff[0];
                if (LlaveDosificacion.Length > (vSumLength + vDigitsVerhoeff[1]))
                {
                    vCad1 = LlaveDosificacion.Substring(vSumLength, vDigitsVerhoeff[1]);
                    vSumLength += vDigitsVerhoeff[1];
                    if (LlaveDosificacion.Length > (vSumLength + vDigitsVerhoeff[2]))
                    {
                        vCad2 = LlaveDosificacion.Substring(vSumLength, vDigitsVerhoeff[2]);
                        vSumLength += vDigitsVerhoeff[2];
                        if (LlaveDosificacion.Length > (vSumLength + vDigitsVerhoeff[3]))
                        {
                            vCad3 = LlaveDosificacion.Substring(vSumLength, vDigitsVerhoeff[3]);
                            vSumLength += vDigitsVerhoeff[3];
                            if (LlaveDosificacion.Length > (vSumLength + vDigitsVerhoeff[4]))
                            {
                                vCad4 = LlaveDosificacion.Substring(vSumLength, vDigitsVerhoeff[4]);
                            }
                            else
                            {
                                vCad4 = LlaveDosificacion.Substring(vSumLength);
                            }
                        }
                        else
                        {
                            vCad3 = LlaveDosificacion.Substring(vSumLength);
                        }
                    }
                    else
                    {
                        vCad2 = LlaveDosificacion.Substring(vSumLength);
                    }
                }
                else
                {
                    vCad1 = LlaveDosificacion.Substring(vSumLength);
                }
            }
            else
            {
                vCad0 = LlaveDosificacion.Substring(vSumLength);
            }

            string vCadRes0, vCadRes1, vCadRes2, vCadRes3, vCadRes4;

            vCadRes0 = vNumeroAutorizacion + vCad0;
            vCadRes1 = vCadInvoiceNumber + vCad1;
            vCadRes2 = vCadNit + vCad2;
            vCadRes3 = vCadDate + vCad3;
            vCadRes4 = vCadAmount + vCad4;

            string vResultAllegedRC4;
            vResultAllegedRC4 = ObtieneAllegedRC4(vCadRes0 + vCadRes1 + vCadRes2 + vCadRes3 + vCadRes4, LlaveDosificacion + vCadDigitsVerhoeff);

            long vSumTotal, vSumPartial1, vSumPartial2, vSumPartial3, vSumPartial4, vSumPartial5;

            vSumTotal = SumASCII(0, vResultAllegedRC4, 1);
            vSumPartial1 = SumASCII(0, vResultAllegedRC4, 5);
            vSumPartial2 = SumASCII(1, vResultAllegedRC4, 5);
            vSumPartial3 = SumASCII(2, vResultAllegedRC4, 5);
            vSumPartial4 = SumASCII(3, vResultAllegedRC4, 5);
            vSumPartial5 = SumASCII(4, vResultAllegedRC4, 5);

            long vMulPartial1, vMulPartial2, vMulPartial3, vMulPartial4, vMulPartial5;

            vMulPartial1 = vSumTotal * vSumPartial1;
            vMulPartial2 = vSumTotal * vSumPartial2;
            vMulPartial3 = vSumTotal * vSumPartial3;
            vMulPartial4 = vSumTotal * vSumPartial4;
            vMulPartial5 = vSumTotal * vSumPartial5;

            long vDivPartial1, vDivPartial2, vDivPartial3, vDivPartial4, vDivPartial5;

            vDivPartial1 = vMulPartial1 / vDigitsVerhoeff[0];
            vDivPartial2 = vMulPartial2 / vDigitsVerhoeff[1];
            vDivPartial3 = vMulPartial3 / vDigitsVerhoeff[2];
            vDivPartial4 = vMulPartial4 / vDigitsVerhoeff[3];
            vDivPartial5 = vMulPartial5 / vDigitsVerhoeff[4];

            long vSumDiv;
            vSumDiv = vDivPartial1 + vDivPartial2 + vDivPartial3 + vDivPartial4 + vDivPartial5;

            string vBase64;

            vBase64 = ObtieneBase64(vSumDiv);

            string vCode;
            vCode = ObtieneAllegedRC4(vBase64, LlaveDosificacion + vCadDigitsVerhoeff);

            for (int i = 0; i < vCode.Length; i += 2)
            {
                vResult += vCode[i].ToString() + vCode[i + 1].ToString();
                if (i + 2 < vCode.Length)
                    vResult += "-";
            }
            //vResult = vCode;
            return vResult;
        }



        #endregion
    }
}
