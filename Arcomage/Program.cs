using Arcomage.Entities;
using Arcomage.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Arcomage
{
    class Program
    {
        static void Main(string[] args)
        {

            var cards = CardSerializator.


            foreach (var c in cards)
            {
                Console.WriteLine("name: {0}, description: {1}, colour: {2}", c.Name, c.Description, c.Colour);
                Console.WriteLine("/n/n");
            }
            Console.ReadLine();
        }
    }
}
