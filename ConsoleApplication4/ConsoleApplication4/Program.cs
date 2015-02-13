using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseCl BaseInst = new BaseCl("basepublic","baseprivate","baseprotected","baseinternal");
            Console.WriteLine("BaseCl: basepublic: {0}; baseprivate {1}; baseprotected {2}; baseinternal {3};", BaseInst.publicField, BaseInst.PrivateField, BaseInst.ProtectedField, BaseInst.internalField);
            Console.ReadKey();
            Derived DerivedInst = new Derived("derivedbasepublic", "derivedbaseprivate", "derivedbaseprotected", "derivedbaseinternal", "derivedpublic", "baseprivate", "baseprotected", "baseinternal");

            Console.WriteLine("BaseCl:\nbasepublic: {0};\nbaseprivate {1};\nbaseprotected {2};\nbaseinternal {3};", BaseInst.publicField, BaseInst.PrivateField, BaseInst.ProtectedField, BaseInst.internalField);
            Console.WriteLine("Derived:\nbasepublic: {0};\nbaseprivate {1};\nbaseprotected {2};\nbaseinternal {3};\nderivedpublic: {4};\nderivedprivate {5};\nderivedprotected {6};\nderivedinternal {7};", DerivedInst.publicField, DerivedInst.PrivateField, DerivedInst.ProtectedField, DerivedInst.internalField, DerivedInst.derivedpublicField, DerivedInst.DerivedprivateField, DerivedInst.DerivedprotectedField, DerivedInst.derivedinternalField);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
