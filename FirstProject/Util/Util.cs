using Games;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    public static class Util
    {
        public static bool ReadBoolean(Func<string, bool?> converter)
        {
            bool? result;

            while (true) // this is bad :(
            {
                string input = Console.ReadLine().ToLower();
                result = converter.Invoke(input);

                if (!result.HasValue) continue;
                return result.GetValueOrDefault();
            }
        }
        public static bool ReadBoolean()
        {
            Hashtable result = new Hashtable();

            result.Add("true", true);
            result.Add("false", false);

            result.Add("yes", true);
            result.Add("no", false);

            result.Add("y", true);
            result.Add("n", false);

            return ReadBoolean((input) =>
            {
                if (!(result.Contains(input))) return null;

                return (bool)result[input];
            });
        }


        public static int ReadInteger(Func<int, bool> check)
        {
            int input = int.MaxValue;

            while (input == int.MaxValue || !check.Invoke(input))
            {
                try
                {
                    input = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    // inform user
                    Console.WriteLine("Erroneous input.");
                }
            }

            return input;
        }
        public static int ReadInteger()
        {
            return ReadInteger((input) => true);
        }

        public static string ReadString(Func<string, bool> check)
        {
            string input = null;

            while (input == null || !check.Invoke(input))
            {
                input = Console.ReadLine();
            }

            return input;
        }
        public static string ReadString(ICollection valid, bool ignoreCase)
        {
            return ReadString((input) =>
            {
                return Contains(valid, (ignoreCase) ? input.ToLower() : input);
            });
        }

        public static bool Contains(ICollection list, object target)
        {
            // O(n) :(
            foreach(object o in list)
            {
                if (o.Equals(target)) return true;
            }

            return false;
        }

        public static void Write(ICollection list)
        {
            Console.Write("| ");

            foreach(object o in list)
            {
                Console.Write(o.ToString() + " | ");
            }

            Console.WriteLine();
        }

        public static Game QueryForGame()
        {
            ICollection keys = GameRegister.instance().lookup.Keys;
            Console.WriteLine("Choose a Game:");
            Write(keys);

            Game chosen = GameRegister.instance().Get(Util.ReadString(keys, true));

            return chosen;
        }
    }
}
