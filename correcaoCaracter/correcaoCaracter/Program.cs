using System;
using System.Text.RegularExpressions;

namespace correcaoCaracter
{
    class Program
    {
        public static void Main()
        {
            Person person1 = new Person("Ma teus _", 6);
            Console.WriteLine("Nome de Entrada Name = {0}", person1.Name);
            RemoverCaracteresTodasPropriedadesStringObjeto<Object>(person1);
            Console.WriteLine("Nome tratado Name = {0}", person1.Name);
        }

        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }
            // Other properties, methods, events...
        }


        /// <summary>
        /// Metodo para remover caracteres indesejados no inicio e fim desse objeto e retirar espaçamento entre a string
        /// </summary>
        public static void RemoverCaracteresTodasPropriedadesStringObjeto<T>(T objetoTratar)
        {
            char[] charsToTrim = { ',', '.', '_', ' ' };

            foreach (var objeto in objetoTratar.GetType().GetProperties())
            {
                var valor = objetoTratar.GetType().GetProperty(objeto.Name).GetValue(objetoTratar, null);

                //Verifica se o objeto é uma string e se for faz a trativa de caracteres
                if (objetoTratar.GetType().GetProperty(objeto.Name).PropertyType == typeof(string))
                {
                    //A função Regex.Replace() retira os espaçamento entre a string
                    //A funcao Trim retira os caracteres antes e apos a string
                    objetoTratar.GetType().GetProperty(objeto.Name).SetValue(objetoTratar, Regex.Replace(valor.ToString().Trim(charsToTrim), @"\s", ""));
                }
            }
        }
    }
}
