using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApp
{
    class CustomerAccount
    {
        private int customerAccountBalance;
        private string customerSurname;

        public void add(int amt)
        {
            customerAccountBalance += amt;
        }

        public void subtract(int amt)
        {
            customerAccountBalance -= amt;
        }

        public int getbal()
        {
            return customerAccountBalance;
        }

        public void setbal(int in_bal)
        {
            customerAccountBalance = in_bal;
        }

        public void setName(string in_name)
        {
            customerSurname = in_name;
        }

        public string getName()
        {
            return customerSurname;
        }

    }
}
