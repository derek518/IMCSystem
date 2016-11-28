using IMCSystem.Console.IMCSystem.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMCSystem.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string serviceUri = "http://localhost:9999/odata/";
            var container = new Default.Container(new Uri(serviceUri));

            //AddDrugs(container);
            ListAllDrugs(container);
            

            System.Console.ReadLine();
        }

        static void ListAllDrugs(Default.Container container)
        {
            foreach (var p in container.Drug)
            {
                System.Console.WriteLine("{0} {1} {2}", p.Name, p.Code, p.BarCode);
            }
        }

        static void AddDrugs(Default.Container container)
        {
            Drug drug = new Drug()
            {
                Name = "多吉美",
                Code = "123456",
                BarCode = "123456",
                SuperCode = "123456"
            };
            
            container.AddToDrug(drug);
            var serviceResponse = container.SaveChanges();
            foreach (var operationResponse in serviceResponse)
            {
                System.Console.WriteLine("Response: {0}", operationResponse.StatusCode);
            }
        }
    }
}
