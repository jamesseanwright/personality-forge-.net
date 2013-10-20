using System;
using System.Collections.Generic;
using System.Linq;
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
using JamesWright.PersonalityForge;
using JamesWright.PersonalityForge.Interfaces;
using JamesWright.PersonalityForge.Models;

namespace JamesWright.PersonalityForge.WpfExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IPersonalityForge _personalityForge;
        private const string username = "james",
                             messageFormat = "{0}: {1}\n";

        public MainWindow()
        {
            InitializeComponent();
            _personalityForge = new PersonalityForge("GP1R7xO2FIpRyzpQpgAR70B0iCAr3Nbf", "eqTSixwhSC3GJ5QZ", 93127);
        }

        private void SendMessage(object sender, RoutedEventArgs e)
        {
            SendMessageAsync();
        }

        private async void SendMessageAsync()
        {
            Send.IsEnabled = false;
            string message = Input.Text;
            Output.Text += string.Format(messageFormat, username, message);
            Input.Clear();

            Response response = await _personalityForge.SendAsync(username, message);

            Output.Text += string.Format(messageFormat, response.Message.ChatBotName, response.Message.Text);
            Send.IsEnabled = true;
        }
    }
}
