// See https://aka.ms/new-console-template for more information
using IO.Swagger.Api;
using IO.Swagger.Client;
using Pandora.Input;


//var test = new ReadJsonFile();
//test.ReadAllData();


Console.WriteLine("Hello, World!");

//var account = new TheAbcBankAccountApi(TheAbcBankAccountApi"");
var account2 = new TheAbcBankApi("https://hackaton2022.azurewebsites.net");
var ret = account2.TheAbcBankApiVisitPost(new IO.Swagger.Model.ApiVisitBody { Passport = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJQYW5kb3JhbkhvbWVPZmZpY2UiLCJzdWIiOiIwODgxNjE5ODIwOSIsImlhdCI6MTY3MDgwMzIwMCwiZXhwIjoxNzMzOTYxNjAwLCJ0eXAiOiJKV1QiLCJkb2N1bWVudF90eXBlIjoiUEFORE9SQU5fUEFTU1BPUlQiLCJwYW5kb3Jhbl9zc24iOiIwODgxNjE5ODIwOSIsImZpcnN0X25hbWUiOiJcdTAwZDh5dmluZCIsImxhc3RfbmFtZSI6Ikx1ZHZpZ3NlbiIsImRhdGVPZkJpcnRoIjoiMjAwMC0wMS0wMSJ9.AIJBpknYawwIeLAjNfs1adpwgJbLUt4CJezfQn6Isq8" });
account2.Configuration.AddDefaultHeader("x-access-token", ret.AccessToken);
var ret2 = account2.TheAbcBankApiCustomerOpenAccountPost(new IO.Swagger.Model.CustomerOpenAccountBody("UPRESIS", "HYPOTESE", "19826498504"));

var y = "";