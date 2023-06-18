using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace printerApp
{
     class Program
    {
        static void Main(string[] args)
        {
            clsDocs.CreateProtocol();
            //Validar que nos pasen el parametro venta id
            if(args == null || args.Length == 0)
            {
                System.Environment.Exit(0); //Cerrar aplicacion
            }
            else
            {
                //Nombre de la impresora
                string pName = "";

                readPrinter(ref pName);

                //Recibimos el protocolo print://1000/
                string saleId = args[0].Replace("print://", string.Empty).Replace("/", string.Empty);
                clsDocs.Receipt(saleId, pName);
            }
        }

        private static void readPrinter(ref string printerName)
        {   
            //Directorio del .exe
            string rootFolder = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string textfile = rootFolder + @"\printer.txt";
            if(File.Exists(textfile))
            {
                printerName = File.ReadAllText(textfile);
            }
            else
            {
                printerName = "3nStar";
            }
        }
    }
}
