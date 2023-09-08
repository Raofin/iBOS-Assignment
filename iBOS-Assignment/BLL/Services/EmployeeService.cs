using System;
using System.Collections.Generic;
using AutoMapper;
using iBOS_Assignment.BLL.Dtos;
using iBOS_Assignment.DAL;
using iBOS_Assignment.DAL.Models;
using iBOS_Assignment.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace iBOS_Assignment.BLL.Services
{
    public class EmployeeService
    {
        private readonly EmployeeRepo _employeeRepo;

        public EmployeeService(EmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        private static readonly IMapper _mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<EmployeeDto, Employee>();
            cfg.CreateMap<Employee, EmployeeDto>();
        }));

        public EmployeeDto GetThirdHighestSalaryEmployee()
        {
            var employee = _employeeRepo.GetEmployeeWithThirdHighestSalary();

            if (employee == null)
            {
                return null;
            }

            return _mapper.Map<EmployeeDto>(employee);
        }

        public List<EmployeeDto> GetEmployeesWithNoAbsentRecords()
        {
            var employees = _employeeRepo.GetEmployeesWithNoAbsentRecords();

            // Map the Employee entities to EmployeeDto objects if necessary
            return _mapper.Map<List<EmployeeDto>>(employees);
        }

        public List<EmployeeDto> GetHierarchyByEmployeeId(long employeeId)
        {
            var hierarchy = _employeeRepo.GetHierarchyByEmployeeId(employeeId);

            // Map the Employee entities to EmployeeDto objects if necessary
            return _mapper.Map<List<EmployeeDto>>(hierarchy);
        }

        public List<EmployeeDto> Get()
        {
            var data = _employeeRepo.Get();
            return _mapper.Map<List<EmployeeDto>>(data);
        }

        public EmployeeDto Get(long id)
        {
            var data = _employeeRepo.Get(id);
            return _mapper.Map<EmployeeDto>(data);
        }

        public bool Update(EmployeeDto employee)
        {
            var existingEmployee = _employeeRepo.Get(employee.EmployeeId);

            if (existingEmployee == null)
            {
                throw new Exception("Employee not found");
            }

            // Check if the new EmployeeCode is different from the existing one
            if (existingEmployee.EmployeeCode != employee.EmployeeCode)
            {
                // If different, check if the new EmployeeCode is unique
                if (_employeeRepo.EmployeeCodeExists(employee.EmployeeCode))
                {
                    throw new Exception("EmployeeCode must be unique");
                }
            }

            // Update other properties
            _mapper.Map(employee, existingEmployee);

            return _employeeRepo.Update(existingEmployee);
        }

        public bool Delete(long id)
        {
            var existingEmployee = _employeeRepo.Get(id);

            if (existingEmployee == null)
            {
                throw new Exception("Employee not found");
            }

            return _employeeRepo.Delete(id);
        }

        public bool Create(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);

            if (string.IsNullOrEmpty(employee.EmployeeName) || string.IsNullOrEmpty(employee.EmployeeCode))
            {
                throw new Exception("EmployeeName and EmployeeCode are required");
            }

            // Check if the EmployeeCode is unique
            if (_employeeRepo.EmployeeCodeExists(employee.EmployeeCode))
            {
                throw new Exception("EmployeeCode must be unique");
            }

            var createdEmployee = _employeeRepo.Add(employee);

            return createdEmployee;
        }

        public bool Exists(long id)
        {
            return _employeeRepo.Get(id) != null;
        }
    }
}
