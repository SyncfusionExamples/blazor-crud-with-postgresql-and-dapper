using BlazorCRUD.Models;
using BlazorCRUD.Services;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;

namespace BlazorCRUD.Adapters
{
    public class EmployeeAdaptor : DataAdaptor
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeAdaptor(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string key = null)
        {
            List<Employee> employees = await _employeeService.GetEmployeeList();

            int count = employees.Count;

            return dataManagerRequest.RequiresCounts ? new DataResult() { Result = employees, Count = count } : count;

        }

        public override async Task<object> InsertAsync(DataManager dataManager, object data, string key)
        {
            await _employeeService.CreateEmployee(data as Employee);
            return data;
        }

        public override async Task<object> RemoveAsync(DataManager dataManager, object data, string keyField, string key)
        {
            await _employeeService.DeleteEmployee(Convert.ToInt32(data));
            return keyField;
        }

        public override async Task<object> UpdateAsync(DataManager dataManager, object data, string keyField, string key)
        {
            await _employeeService.UpdateEmployee(data as Employee);
            return data;
        }
    }
}



