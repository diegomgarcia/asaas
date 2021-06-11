using System;
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
    public class SubscriptionTest
    {
        private ISettingsService _settingsService;
        private ICustomerService _customerService;
        private ISubscriptionService _subscriptionService;

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
            _subscriptionService = SubscriptionFactory.CreateService(_settingsService);
        }


        private Customer AddNewCustomer()
        {
            var customer = new Customer()
            {
                Name = "John Doe",
                CpfCnpj = "40620456990"
            }; 
                
            return _customerService.CreateAsync(customer).Result;
        }
        
        
        [TestMethod]
        public void TestCreate()
        {
            var customer = AddNewCustomer();
            
            Assert.IsNotNull(customer);
            Assert.IsTrue(customer.Id != "","Customer Id should not be empty.");

            var subscription = new Subscription()
            {
                Customer = customer.Id,
                BillingType = BillingType.UNDEFINED,
                Cycle = CycleType.MONTHLY,
                Value = 99.89,
                NextDueDate = DateTime.Today.ToString("yyyy-MM-dd"),
                Description = "Plano Professional",
                ExternalReference = "ABC-01234"
            };

            var newSubscription = _subscriptionService.CreateAsync(subscription).Result;
            
            Assert.IsNotNull(newSubscription);
            Assert.IsTrue(newSubscription.Id != "", "Subscription Id should not be empty");
            Assert.AreEqual(newSubscription.Description, subscription.Description);

            _subscriptionService.DeleteAsync(newSubscription.Id);
            _customerService.DeleteAsync(customer.Id);
        }


        [TestMethod]
        public void TestUpdate()
        {
            var customer = AddNewCustomer();
            
            Assert.IsNotNull(customer);
            Assert.IsTrue(customer.Id != "","Customer Id should not be empty.");

            var subscription = new Subscription()
            {
                Customer = customer.Id,
                BillingType = BillingType.UNDEFINED,
                Cycle = CycleType.MONTHLY,
                Value = 99.89,
                NextDueDate = DateTime.Today.ToString("yyyy-MM-dd"),
                Description = "Plano Professional",
                ExternalReference = "ABC-01234"
            };

            var newSubscription = _subscriptionService.CreateAsync(subscription).Result;

            Assert.IsNotNull(newSubscription);
            Assert.IsTrue(newSubscription.Id != "", "Subscription Id should not be empty");
            Assert.AreEqual(newSubscription.Description, subscription.Description);

            subscription.Value = 79.99;

            newSubscription = _subscriptionService.UpdateAsync(subscription).Result;
            
            Assert.IsNotNull(newSubscription);
            Assert.AreEqual(newSubscription.Value, subscription.Value);

            _subscriptionService.DeleteAsync(newSubscription.Id);
            _customerService.DeleteAsync(customer.Id);
        }
        
        
        [TestMethod]
        public void TestDelete()
        {
            var customer = AddNewCustomer();
            
            Assert.IsNotNull(customer);
            Assert.IsTrue(customer.Id != "","Customer Id should not be empty.");

            var subscription = new Subscription()
            {
                Customer = customer.Id,
                BillingType = BillingType.UNDEFINED,
                Cycle = CycleType.MONTHLY,
                Value = 99.89,
                NextDueDate = DateTime.Today.ToString("yyyy-MM-dd"),
                Description = "Plano Professional",
                ExternalReference = "ABC-01234"
            };

            var newSubscription = _subscriptionService.CreateAsync(subscription).Result;
            
            Assert.IsNotNull(newSubscription);
            Assert.IsTrue(newSubscription.Id != "", "Subscription Id should not be empty");
            Assert.AreEqual(newSubscription.Description, subscription.Description);

            var deleted = _subscriptionService.DeleteAsync(newSubscription.Id).Result;
            Assert.IsTrue(deleted);

            newSubscription = _subscriptionService.ReadAsync(newSubscription.Id).Result;
            
            Assert.IsTrue(newSubscription.Deleted);
            
            _customerService.DeleteAsync(customer.Id);
        }


        [TestMethod]
        public void TestListPayments()
        {
            var customer = AddNewCustomer();
            
            Assert.IsNotNull(customer);
            Assert.IsTrue(customer.Id != "","Customer Id should not be empty.");

            var subscription = new Subscription()
            {
                Customer = customer.Id,
                BillingType = BillingType.UNDEFINED,
                Cycle = CycleType.MONTHLY,
                Value = 99.89,
                NextDueDate = DateTime.Today.ToString("yyyy-MM-dd"),
                Description = "Plano Professional",
                ExternalReference = "ABC-01234"
            };

            var newSubscription = _subscriptionService.CreateAsync(subscription).Result;
            
            Assert.IsNotNull(newSubscription);
            Assert.IsTrue(newSubscription.Id != "", "Subscription Id should not be empty");


            var payments = _subscriptionService.ReadPayments(newSubscription.Id).Result;
            
            Assert.IsNotNull(payments);
            Assert.IsTrue(payments.Data.Count == 1);

            _subscriptionService.DeleteAsync(newSubscription.Id);
            _customerService.DeleteAsync(customer.Id);
        }
        
    }
}