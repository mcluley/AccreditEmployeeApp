using Moq;
using Microsoft.AspNetCore.Mvc;
using EmployeeMVC.Controllers;
using EmployeeShared.Models;
using EmployeeMVC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList.Extensions;
using EmployeeMVC.Models;

namespace Employee.UnitTests
{
    public class EmployeeControllerTests
    {
        private readonly Mock<EmployeeService> _employeeMockService;
        private readonly Mock<GlobalSettingsService> _globalMockService;
        private readonly EmployeeController _controller;

        public EmployeeControllerTests()
        {
            _employeeMockService = new Mock<EmployeeService>();
            _globalMockService = new Mock<GlobalSettingsService>();
            _controller = new EmployeeController(_employeeMockService.Object, _globalMockService.Object);
        }

        [Fact]
        public async Task Index_ReturnsViewResult_WithListOfEmployees()
        {

            // Need to set this up to mock TempData used in the Index Controller
            ITempDataProvider tempDataProvider = Mock.Of<ITempDataProvider>();
            TempDataDictionaryFactory tempDataDictionaryFactory = new TempDataDictionaryFactory(tempDataProvider);
            ITempDataDictionary tempData = tempDataDictionaryFactory.GetTempData(new DefaultHttpContext());
            _controller.TempData = tempData;



            var employees = new List<EmployeeShared.Models.Employee>
            {
                new EmployeeShared.Models.Employee { EmployeeId = 1, Firstname = "EmployeeFNOne", Lastname ="EmployeeLNOne", StatusID = 1, DepartmentID = 1, DateOfBirth = DateTime.Parse("01/01/1970"), Email="employee1@gmail,com", IsActive=true, EmployeeNumber= "123450"},
                new EmployeeShared.Models.Employee { EmployeeId = 2, Firstname = "EmployeeFNTwo", Lastname ="EmployeeLNTwo", StatusID = 2, DepartmentID = 2, DateOfBirth = DateTime.Parse("02/01/1970"), Email="employee2@gmail,com", IsActive=true, EmployeeNumber= "123451"},
                new EmployeeShared.Models.Employee { EmployeeId = 3, Firstname = "EmployeeFNThree", Lastname ="EmployeeLNThree", StatusID = 3, DepartmentID = 3, DateOfBirth = DateTime.Parse("03/01/1970"), Email="employee3@gmail,com", IsActive=true, EmployeeNumber= "123452"},
                new EmployeeShared.Models.Employee { EmployeeId = 4, Firstname = "EmployeeFNFour", Lastname ="EmployeeLNFour", StatusID = 1, DepartmentID = 4, DateOfBirth = DateTime.Parse("04/01/1970"), Email="employee4@gmail,com", IsActive=true, EmployeeNumber= "123453"},
                new EmployeeShared.Models.Employee { EmployeeId = 5, Firstname = "EmployeeFNFive", Lastname ="EmployeeLNFive", StatusID = 2, DepartmentID = 51, DateOfBirth = DateTime.Parse("05/01/1970"), Email="employee5@gmail,com", IsActive=true, EmployeeNumber= "123454"},
                new EmployeeShared.Models.Employee { EmployeeId = 6, Firstname = "EmployeeFNSix", Lastname ="EmployeeLNSix", StatusID = 2, DepartmentID = 51, DateOfBirth = DateTime.Parse("05/01/1970"), Email="employee6@gmail,com", IsActive=true, EmployeeNumber= "123455"}
            };

            _employeeMockService.Setup(s => s.GetAllEmployeesAsync("EmployeeId","asc",0,0)).ReturnsAsync(employees);

            var result = await _controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            
            var model = Assert.IsAssignableFrom<EmployeeMVC.Models.EmployeeListViewModel>(viewResult.Model);
            
            Assert.Equal(6, model.Employees.Count());
        }

        [Fact]
        public void Create_Post_ValidModel_RedirectToIndex()
        {
            // Arrange
            var viewModel = new CreateEditEmployeeViewModel 
                {
                departments = new List<SelectListItem>(),
                statuses = new List<SelectListItem>(),
                employee = new EmployeeShared.Models.Employee { EmployeeId = 1, Firstname = "EmployeeFNOne", Lastname = "EmployeeLNOne", StatusID = 1, DepartmentID = 1, DateOfBirth = DateTime.Parse("01/01/1970"), Email = "employee1@gmail,com", IsActive = true, EmployeeNumber = "123450", Department = new Department(), Status = new Status() }
            };

            _employeeMockService.Setup(s => s.AddEmployeeAsync(It.IsAny<EmployeeShared.Models.Employee>()));

            // Act
            var result = _controller.Create(viewModel);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectResult.ActionName);
        }

    }
}