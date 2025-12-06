using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeverM
{
    using System;
    using System.Windows.Forms;

    namespace StokTakip
    {
        public static class Prompt
        {
            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new Form()
                {
                    Width = 300,
                    Height = 150,
                    Text = caption
                };

                Label lbl = new Label() { Left = 10, Top = 20, Text = text };
                TextBox box = new TextBox() { Left = 10, Top = 50, Width = 250 };
                Button ok = new Button() { Text = "OK", Left = 180, Top = 80, Width = 80 };

                ok.Click += (sender, e) => { prompt.Close(); };

                prompt.Controls.Add(lbl);
                prompt.Controls.Add(box);
                prompt.Controls.Add(ok);

                prompt.ShowDialog();
                return box.Text;
            }
        }
    }

}
