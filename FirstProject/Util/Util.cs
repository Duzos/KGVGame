using Games;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            ICollection keys = GameRegister.Instance().lookup.Keys;
            Console.WriteLine("Choose a Game:");
            Write(keys);

            Game chosen = GameRegister.Instance().Get(ReadString(keys, true));

            return chosen;
        }

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        // https://stackoverflow.com/questions/642542/how-to-get-next-or-previous-enum-value-in-c-sharp#:~:text=Implemented%20as%20generic%20extension%20method%2C%20you%20can%20call,it%20on%20any%20enum%20this%20way%3A%20return%20eRat.B.Next%28%29%3B
        public static T Next<T>(this T src) where T : struct
        {
            if (!typeof(T).IsEnum) throw new ArgumentException(String.Format("Argument {0} is not an Enum", typeof(T).FullName));

            T[] Arr = (T[])Enum.GetValues(src.GetType());
            int j = Array.IndexOf<T>(Arr, src) + 1;
            return (Arr.Length == j) ? Arr[0] : Arr[j];
        }
    }
}
