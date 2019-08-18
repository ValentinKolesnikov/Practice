using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerCommon;
using DataAccessLayerEF.Repositories;
using DataAccessLayerCommon.Interfaces;
using Unity;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.GetEncoding(1251);

            var container = UnityConfig.RegisterComponents();
            IEmployeeRepository employeeRepository = container.Resolve<IEmployeeRepository>();

            IClientRepository clientRepository = container.Resolve<IClientRepository>();

            var list = clientRepository.GetAll();
            //var list = employeeRepository.GetList();

            /*
            Client client = new Client();
            ClientRepository clientRepo = new ClientRepository();
            EmployeeRepository er = new EmployeeRepository();
            Client clientForInsert = new Client
            {
                FirstName = "Валик",
                SecondName = "Виталик",
                MiddleName = "Артемович",
                BirthDay = new DateTime(2000, 3, 8),
                Address = "РБ, Могилев, ул. Габровская 24-123",
                PassportSeriesAndNumber = "КВ441678",
                CardNumber = ""

            };
            IEnumerable<Client> clientsList = clientRepo.GetList();
            IEnumerable<Employee> el = er.GetList();
            //Client someClient =  clientRepo.GetItem(1);
            //clientRepo.Insert(clientForInsert);*/

            Console.ReadKey();
        }
    }
}
