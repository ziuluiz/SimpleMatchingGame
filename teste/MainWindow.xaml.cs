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
using System.Windows.Threading;

namespace MatchGame
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		DispatcherTimer timer = new DispatcherTimer();
		int tenthsOfSecondsElapsed;
		int matchesFound;

		public MainWindow()
		{
			InitializeComponent();
			timer.Interval = TimeSpan.FromSeconds(.1);
			timer.Tick += Timer_Tick;
			SetUpGame();

		}

		private void Timer_Tick(object? sender, EventArgs e)
		{
			tenthsOfSecondsElapsed++;
			timeTextBlock.Text = (tenthsOfSecondsElapsed / 10f).ToString("0.0s");
			if(matchesFound == 8) 
			{
				timer.Stop();
				timeTextBlock.Text = timeTextBlock.Text + " - Play again?";
			}
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
				if(textBlock.Name != "timeTextBlock")
				{ 
					int index = random.Next(emoji.Count);
					string nextEmoji = emoji[index];
					textBlock.Text = nextEmoji;
					emoji.RemoveAt(index);
				}
			}
			timer.Start();
			tenthsOfSecondsElapsed = 0;
			matchesFound = 0;
		}

		TextBlock lastTextBlockClicked;
		bool findingMatch = false;

		private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
		{
			TextBlock textBlock = sender as TextBlock;
			if (findingMatch == false) 
			{
				textBlock.Visibility = Visibility.Hidden;
				lastTextBlockClicked = textBlock;
				findingMatch = true;
			}
			else if(lastTextBlockClicked.Text == textBlock.Text) 
			{
				matchesFound++;
				textBlock.Visibility = Visibility.Hidden;
				findingMatch = false;
			}
			else
			{
				lastTextBlockClicked.Visibility = Visibility.Visible;
				findingMatch = false;
			}
			
		}

		private void timeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if(matchesFound == 8)
			{
				//Todo popup winner
				SetUpGame();
			}
		}
	}
}
