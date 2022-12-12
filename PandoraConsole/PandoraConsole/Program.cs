// See https://aka.ms/new-console-template for more information
using IO.Swagger.Api;
using Pandora.Input;


var test = new ReadJsonFile();
test.ReadAllData();


Console.WriteLine("Hello, World!");

//var account = new TheAbcBankAccountApi(TheAbcBankAccountApi"");
var account2 = new TheAbcBankApi("https://hackaton2022.azurewebsites.net");
account2.TheAbcBankApiVisitPost(new IO.Swagger.Model.ApiVisitBody { Passport = "" });
