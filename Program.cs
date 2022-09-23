using System;
using System.Collections.Generic;
using System.Linq;

namespace linq
{
    // Build a collection of customers who are millionaires
    public class ReportItem
    {
        public string CustomerName { get; set; }
        public string BankName { get; set; }
    }
    public class Customer
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Bank { get; set; }
    }
    public class Bank
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
    }

    public class Program
    {
        public static void Main()
        {
            List<Bank> banks = new List<Bank>() {
            new Bank(){ Name="First Tennessee", Symbol="FTB"},
            new Bank(){ Name="Wells Fargo", Symbol="WF"},
            new Bank(){ Name="Bank of America", Symbol="BOA"},
            new Bank(){ Name="Citibank", Symbol="CITI"},
        };
            List<Customer> customers = new List<Customer>() {
            new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
            new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
            new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
            new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
            new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
            new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
            new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
            new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
            new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
            new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
        };









            // IEnumerable<Customer> millionairesInList = customers.Where(x => x.Balance >= 1000000);

            // Console.WriteLine(millionairesInList.Count());

            var millionaires = 
            from customer in customers
            where customer.Balance >= 1000000 //find the millionaires
            group customer by customer.Bank into customerBank //customerBank is an IGrouping
            select new { name = customerBank.Key, count = customerBank.Count() };

            // foreach(var bank in millionaires)
            // {
            //     Console.WriteLine($" {bank.name}: {bank.count}");
            // }
            // JS ==== const millionairesByBank = customers.filter(x=> customer.Balance >= 1000000).map( x => {customer.bank: customerBank.length})
            /*
                TASK:
                As in the previous exercise, you're going to output the millionaires,
                but you will also display the full name of the bank. You also need
                to sort the millionaires' names, ascending by their LAST name.

                Example output:
                    Tina Fey at Citibank
                    Joe Landy at Wells Fargo
                    Sarah Ng at First Tennessee
                    Les Paul at Wells Fargo
                    Peg Vale at Bank of America
            */


            List<ReportItem> millionairessss = (
                   from customer in customers
                   where customer.Balance >= 1000000 //find the millionaires
                   orderby customer.Name.Split(' ')[1] // order ascending by last name 
                   join singleBank in banks on customer.Bank equals singleBank.Symbol // joins the two list
                   select new ReportItem() { CustomerName = customer.Name, BankName = singleBank.Name }).ToList();


                millionairessss.ForEach( item => Console.WriteLine($"{item.CustomerName} at {item.BankName}"));


            /*
                      You will need to use the `Where()`
                      and `Select()` methods to generate
                      instances of the following class.

                      public class ReportItem
                      {
                          public string CustomerName { get; set; }
                          public string BankName { get; set; }
                      }
                  */




        }
    }
}


/*
    Given the same customer set, display how many millionaires per bank.
    Ref: https://stackoverflow.com/questions/7325278/group-by-in-linq

    Example Output:
    WF 2
    BOA 1
    FTB 1
    CITI 1
*/