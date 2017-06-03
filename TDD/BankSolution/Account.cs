namespace BankSolution
{
    public class Account
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }

        public Account(string number, string name, decimal balance)
        {
            Number = number;
            Name = name;
            Balance = balance;
        }
    }
}