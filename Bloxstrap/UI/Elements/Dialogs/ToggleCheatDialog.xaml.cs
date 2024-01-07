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
using System.Windows.Shapes;

namespace Bloxstrap.UI.Elements.Dialogs
{
    /// <summary>
    /// Interaction logic for AddFlagDialog.xaml
    /// </summary>
    public partial class ToggleCheatDialog
    {
        public MessageBoxResult Result = MessageBoxResult.Cancel;
        public FastFlag FFlagObject = new FastFlag();

        public ToggleCheatDialog()
        {
            InitializeComponent();
        }

        void FFlag(string fflag, object? value)
        {
            FFlagObject.Name = fflag;
            FFlagObject.Value = (string)value;
            if (App.FastFlags.GetValue(fflag) is null)
            {
                App.FastFlags.SetValue(fflag, value);
            } else
            {
                App.FastFlags.SetValue(fflag, null);
            }
            Result = MessageBoxResult.OK;
            Close();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxResult.OK;
            Close();
        }

        private void Speedhack_Click(object sender, RoutedEventArgs e)
        {
            FFlag(FastFlagManager.PresetFlags["Cheats.Speedhack"], "true");
        }

        private void Wallglide_Click(object sender, RoutedEventArgs e)
        {
            FFlag(FastFlagManager.PresetFlags["Cheats.Wallglide"], "-1");
        }
    }
}
