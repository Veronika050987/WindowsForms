using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Text;

namespace WindowsForms_2
{
	public partial class ChooseFont : Form
	{
		public Font Font { get; set; }
		public ChooseFont()
		{
			InitializeComponent();

			//fonts in alphabetic order
			List<string> fontList = new List<string>();

			fontList.AddRange(GetFontListFromCurrentDirectoryByExtension("*.ttf"));
			fontList.AddRange(GetFontListFromCurrentDirectoryByExtension("*.otf"));

			fontList.Sort();

			comboBoxChooseFont.Items.AddRange(fontList.ToArray());

			if (comboBoxChooseFont.Items.Count > 0)
				comboBoxChooseFont.SelectedIndex = 0;
			//comboBoxChooseFont.Items.AddRange(GetFontListFromCurrentDirectoryByExtension("*.ttf"));
			//comboBoxChooseFont.Items.AddRange(GetFontListFromCurrentDirectoryByExtension("*.otf"));
			//comboBoxChooseFont.SelectedIndex = 0;//if no font is chosen, index is -1
		}
		string[] GetFontListFromCurrentDirectoryByExtension(string extension)
		{
			Console.Write(Application.ExecutablePath);
			string execution_path = Path.GetDirectoryName(Application.ExecutablePath);
			Console.WriteLine(execution_path);
			Directory.SetCurrentDirectory($"{execution_path}\\..\\..\\Fonts");
			Console.WriteLine(Directory.GetCurrentDirectory());
			string[] fonts = Directory.GetFiles(Directory.GetCurrentDirectory(), extension);
			for (int i = 0; i < fonts.Length; i++)
			{
				fonts[i] = fonts[i].Split('\\').Last();
			}
			return fonts;
		}
		void SetFont(string filename, float size = 32)
		{
			PrivateFontCollection pfc = new PrivateFontCollection();
			pfc.AddFontFile(filename);
			lblExample.Font = new Font(pfc.Families[0], size);
		}

		private void comboBoxChooseFont_SelectedIndexChanged(object sender, EventArgs e)
		{
			SetFont((sender as ComboBox).SelectedItem.ToString());
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			Font = lblExample.Font;
		}

		private void nudFontSize_ValueChanged(object sender, EventArgs e)
		{
			//lblExample.Font.Size = (float)(sender as NumericUpDown).Value;
			SetFont(comboBoxChooseFont.SelectedItem.ToString(), (float)nudFontSize.Value);
		}
	}
}
