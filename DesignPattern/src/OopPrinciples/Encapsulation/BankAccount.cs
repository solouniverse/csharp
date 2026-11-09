using System;

namespace DesignPattern.src.OopPrinciples.Encapsulation;

public class BankAccount
{
    private decimal balance;

    public BankAccount(decimal balance)
    {
        Deposit(balance);
    }

    public decimal GetBalance()
    {
        return this.balance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Deposit amount must be positive");
        }

        this.balance += amount;
    }

    public void withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Withdrawal amount must be positive");
        }
        if (amount > this.balance)
        {
            throw new InvalidOperationException("Insufficient funds");
        }
        this.balance -= amount;
    }
}
