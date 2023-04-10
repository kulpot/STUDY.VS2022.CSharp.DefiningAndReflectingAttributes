using NUnit.Framework;
using System;

namespace DefiningAndReflectingAttributes
{
    [Author("Kulpot Wahu", Age = 999)]
    class Program
    {
        static void Main(string[] args)
        {
            Type info = Type.GetType("DefiningAndReflectingAttributes.Program");

            foreach(var attrib in info.CustomAttributes)
            {
                if(attrib.AttributeType == typeof(AuthorAttribute))
                {
                    Console.WriteLine(attrib.ConstructorArguments[0].Value.ToString());
                    
                    if(attrib.NamedArguments.Count > 0)
                    {
                        int age = (int)attrib.NamedArguments[0].TypedValue.Value;
                        Console.WriteLine(age.ToString());
                    }
                }
            }
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    class AuthorAttribute : Attribute
    {
        public int Age;

        public AuthorAttribute(string authorName) 
        {
        }
    }
}
