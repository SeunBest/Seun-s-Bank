
namespace Seun_s_Bank.Lib
{
    public interface IDuty
    {
        public void Deposit(decimal amt, string note);

        public void Withdraw(decimal amt, string note);
    }
}
