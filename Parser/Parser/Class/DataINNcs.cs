using System;

namespace Parser.Class
{
    [Serializable]
    public class DataINN
    {


        public string Company { get; set; }
        public string INN { get; set; }
        public string Manager { get; set; }
        public string Address { get; set; }
        public DataINN() { }
        public DataINN(string INN)
        {
            Company = "";
            this.INN = INN;
            Manager = "";
            Address = "";
        }
        public DataINN(string Company, string INN, string Manager, string Address)
        {
            this.Company = Company;
            this.INN = INN;
            this.Manager = Manager;
            this.Address = Address;
        }

    }
}
