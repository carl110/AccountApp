using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApp
{
    class FileHandler
    {
        static string fileLocation = "C:\\Users\\cwainwright\\Desktop\\AccountInfo.txt";
        public FileHandler()
        {
        }
        public static void saveFile(List<CustomerAccount> accountList)
        {
            using (TextWriter tw = new StreamWriter(fileLocation))
            {
                foreach (var account in accountList)
                {
                    tw.WriteLine(account.getName() + "," + account.getbal());
                }
            }
        }
        public static void readTxtFile(List<CustomerAccount> accountList)
        {
            string[] myArray = { "Surname", "Account Balance" };
            foreach (var line in File.ReadAllLines(fileLocation))
            {
                myArray = line.Trim().Split(',');
                CustomerAccount newCustAccount = new CustomerAccount();
                newCustAccount.setName(myArray[0]);
                newCustAccount.setbal(Convert.ToInt32(myArray[1]));
                accountList.Add(newCustAccount);

            }
        }
    }
}
