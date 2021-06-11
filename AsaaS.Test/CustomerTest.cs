using AsaaS.Common;
using AsaaS.Contracts;
using AsaaS.Entities;
using AsaaS.Factory;
using AsaaS.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace AsaaS.Test
{
    [TestClass]
    public class CustomerTest
    {
        private ISettingsService _settingsService;
        private ICustomerService _customerService;
        
        IConfiguration Configuration { get; set; }

        [TestInitialize]
        public void Init()
        {
            var builder = new ConfigurationBuilder().AddUserSecrets<CustomerTest>();
            Configuration = builder.Build();    
            
            _settingsService = new SettingsService(new Settings
            {
                Sandbox = true,
                AccessToken = Configuration["ACCESS_TOKEN"]
            });

            _customerService = CustomerFactory.CreateService(_settingsService);
        }
        
        [TestMethod]
        public void TestRead()
        {
            var customer = new Customer()
            {
                Name = "John Doe",
                CpfCnpj = ""
            }; 
                
            var newCustomer = _customerService.CreateAsync(customer).Result;

            Assert.IsFalse(newCustomer.Id == "", "Customer Id cannot be empty");
            
            customer = _customerService.ReadAsync(newCustomer.Id).Result;
            
            Assert.IsNotNull(customer);
            Assert.AreEqual(customer.Id, newCustomer.Id);
            Assert.AreEqual(customer.Name, newCustomer.Name);
            
            _customerService.DeleteAsync(customer.Id);
        }

        [TestMethod]
        public void TestCreate()
        {
            var customer = new Customer()
            {
                Name = "John Doe",
                CpfCnpj = ""
            }; 
                
            var newCustomer = _customerService.CreateAsync(customer).Result;
            
            Assert.IsNotNull(newCustomer);
            Assert.IsTrue(newCustomer.Id != "","Id should not be empty.");
            Assert.AreEqual(newCustomer.Name, customer.Name);

            _customerService.DeleteAsync(newCustomer.Id);
        }
        
        [TestMethod]
        public void TestUpdate()
        {
            var customer = new Customer()
            {
                Name = "John Doe",
                CpfCnpj = ""
            }; 
                
            var newCustomer = _customerService.CreateAsync(customer).Result;

            Assert.IsFalse(newCustomer.Id == "", "Customer Id cannot be empty");

            newCustomer.Name = "Johnnie Doe";
            
            customer = _customerService.UpdateAsync(newCustomer).Result;
            
            Assert.IsNotNull(customer);
            Assert.AreEqual(newCustomer.Name, customer.Name);

            _customerService.DeleteAsync(newCustomer.Id);
        }
        
        [TestMethod]
        public void TestDelete()
        {
            var customer = new Customer()
            {
                Name = "John Doe",
                CpfCnpj = ""
            }; 
                
            var newCustomer = _customerService.CreateAsync(customer).Result;

            Assert.IsFalse(newCustomer.Id == "", "Customer Id cannot be empty");

            var deleted = _customerService.DeleteAsync(newCustomer.Id).Result;
            
            Assert.IsTrue(deleted);
        }
    }
}