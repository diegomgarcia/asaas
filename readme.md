# AsaaS Payment Gateway Lib

A dotnet core library to interact with AsaaS payment gateway.

Any help is appreciated! Comment, suggestions, issues, PR's! Give us a star to help!

## Goals

The goal of this project is to provide a complete set of workflows to work with AsaaS payment gateway.

## Currently supported features

- Add Customer
- Update Customer
- Delete Customer
- Select Customer By Id


- Add Subscription
- Update Subscription
- Delete Subscription
- Select Subscription By Id
- Select Subscription Payments


- Receive payment updates callbacks

## Support us by becoming a patron on Patreon

[![Patreon](https://c5.patreon.com/external/logo/become_a_patron_button.png)](https://www.patreon.com/dmgarcia)

Or making a single donation buying me a coffee:

[![Buy Me A Coffee](https://user-images.githubusercontent.com/835641/60540201-fcd7fa00-9ce4-11e9-87ec-1e98568e9f58.png)](https://www.buymeacoffee.com/dmgarcia)

You can also show support by showing on your repository that you use this lib on it with a direct link to it.

## How should I use ?

1- Access your AsaaS sandbox account at https://sandbox.asaas.com and get you api key.

2- Register your sandbox access token using the command: 
```
  dotnet user-secrets set "ACCESS_TOKEN" "<your-api-key>"
```

3- Add the follow code to your Startup class:  
````
    services.AddAsaaS(
        new Settings 
        {
            Sandbox = false,
            AccessToken = Configuration["ACCESS_TOKEN"]
        }
    );
````

4- Add in your class constructor the reference to the service that you want to use and the DI will do the rest:

```
  using AsaaS.Contracts;
  
  SomeClass class
  {
    private readonly ICustomerService _asaasCustomerService;
    
    SomeClass(ICustomerService asaasCustomerService){
        _asaasCustomerService = asaasCustomerService;
    }
    
    public void DoSomething(){
      _asaasCustomerService.Read("someID");
    }
  } 
```

5- Receive the callback from AsaaS in your method declaring as above:

```
public async Task<IActionResult> Notification([FromBody] PaymentEvent paymentEvent, [FromHeader(Name = "ASAAS-ACCESS-TOKEN")] string accessToken){
  if (accessToken != "<your custom app token>") {
    Console.WriteLine("Invalid request from other service!");
    return Forbid();
  }

  //Use paymentEvent to read the details of the transaction received.
  //To ensure that its not a fake transaction fromo someone else, we recomend to request the payment from asaas with the id comming from the paymentEvent. 
}
```