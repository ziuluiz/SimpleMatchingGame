using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MatchGame
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			SetUpGame();

		}

		private void SetUpGame()
		{
			List<string> emoji = new List<string>()
			{
			"ᓚᘏᗢ","ᓚᘏᗢ",
			"(╯°□°）╯︵ ┻━┻","(╯°□°）╯︵ ┻━┻",
			"(⌐■_■)","(⌐■_■)",
			"(❁´◡`❁)","(❁´◡`❁)",
			"ಠ_ಠ","ಠ_ಠ",
			"ಥ_ಥ","ಥ_ಥ", //forgive me.
			"(^///^)","(^///^)",
			"(•_•)","(•_•)",
			};
			Random random = new Random();

			foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
			{
				int index = random.Next(emoji.Count);
				string nextEmoji = emoji[index];
				textBlock.Text = nextEmoji;
				emoji.RemoveAt(index);
			}

		}

		private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
		{

		}
	}
}
