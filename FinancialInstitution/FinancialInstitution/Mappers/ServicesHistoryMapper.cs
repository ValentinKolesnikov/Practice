using FinancialInstitution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayerCommon;
using DataAccessLayerEF.Repositories;

namespace FinancialInstitution.Mappers
{
    public class ServicesHistoryMapper
    {
        public EmployeeRepository employeeRepository;

        public ServicesHistoryMapper()
        {
            employeeRepository = new EmployeeRepository();
        }
        
        public ServicesHistoryEdit MapFromEntityEdit(DataAccessLayerCommon.ServicesHistory servicesHistory)
        {
            Models.ServicesHistoryEdit SHModel = new Models.ServicesHistoryEdit
            {
                ServicesDirectoryId = servicesHistory.ServicesDirectoryId,
                ClientId = servicesHistory.ClientId,
                EmployeeId = servicesHistory.EmployeeId,
                //Date = servicesHistory.Date,
                BranchId = employeeRepository.GetItemWithBranchAndPosition(servicesHistory.EmployeeId).BranchId


            };
            return SHModel;

        }
        
        public DataAccessLayerCommon.ServicesHistory MapFromModelEdit(Models.ServicesHistoryEdit servicesHistory)
        {
            DataAccessLayerCommon.ServicesHistory sh = new DataAccessLayerCommon.ServicesHistory
            {
                ServicesDirectoryId = servicesHistory.ServicesDirectoryId,
                ClientId = servicesHistory.ClientId,
                EmployeeId = servicesHistory.EmployeeId,

               // Employee = employeeRepository.GetItemWithBranchAndPosition(servicesHistory.EmployeeId),
               // Client = clientRepository.GetItem(servicesHistory.ClientId),
                //ServicesDirectory = servicesDirectoryRepository.GetItem(servicesHistory.ServicesDirectoryId)

            };
            return sh;

        }
        public Models.ServicesHistoryShow MapFromEntityShow(DataAccessLayerCommon.ServicesHistory servicesHistory)
        {
            Models.ServicesHistoryShow SHModel = new Models.ServicesHistoryShow
            {
                Id = servicesHistory.Id,
                Employee = new Models.Employee
                {
                    FirstName = servicesHistory.Employee.FirstName,
                    SecondName = servicesHistory.Employee.SecondName,
                    MiddleName = servicesHistory.Employee.MiddleName,
                    Branch = servicesHistory.Employee.Branch.Name,
                    Id = servicesHistory.Id,
                    Position = servicesHistory.Employee.Position.Name
                },
                Date = servicesHistory.Date,
                ServicesDirectoryName = servicesHistory.ServicesDirectory.Name,
                
            };
            return SHModel;

        }

    }
}