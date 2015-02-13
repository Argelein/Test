using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class BaseCl
    {
        public string publicField;
        private string privateField;
        protected string protectedField;
        internal string internalField;

        public BaseCl(string publicField, string privateField, string protectedField, string internalField)
        {
            this.publicField = publicField;
            this.privateField = privateField;
            this.protectedField = protectedField;
            this.internalField = internalField;
        }

        public string PublicField
        {
            get { return publicField; }
            set { publicField = value; }
        }

        public string PrivateField
        {
            get { return privateField; }
            set { privateField = value; }
        }

        public string ProtectedField
        {
            get { return protectedField; }
            set { protectedField = value; }
        }

        public string InternalField
        {
            get { return internalField; }
            set { internalField = value; }
        }
    }
    class Derived : BaseCl
    {
        public string derivedpublicField;
        private string derivedprivateField;
        protected string derivedprotectedField;
        internal string derivedinternalField;

        //public Derived(string publicField, string privateField, string protectedField, string internalField) : base(string publicField, string privateField, string protectedField, string internalField)
        //{
        //    Console.WriteLine("child");
        //}

        public Derived(string publicField, string privateField, string protectedField, string internalField, string derivedpublicField, string derivedprivateField, string derivedprotectedField, string derivedinternalField) : base(publicField, privateField, protectedField, internalField)
        {
            //this.publicField = publicField;
            //this.privateField = privateField;
            //this.protectedField = protectedField;
            //this.internalField = internalField;
            this.derivedpublicField = derivedpublicField;
            this.derivedprivateField =  derivedprivateField;
            this.derivedprotectedField = derivedprotectedField;
            this.derivedinternalField = derivedinternalField;
        }

        public string DerivedpublicField
        {
            get { return derivedpublicField; }
            set { derivedpublicField = value; }
        }

        public string DerivedprivateField
        {
            get { return derivedprivateField; }
            set { derivedprivateField = value; }
        }

        public string DerivedprotectedField
        {
            get { return derivedprotectedField; }
            set { derivedprotectedField = value; }
        }

        public string DerivedinternalField
        {
            get { return derivedinternalField; }
            set { derivedinternalField = value; }
        }
    }
}
