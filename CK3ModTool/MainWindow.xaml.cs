using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using CK3ModTool.Parser;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace CK3ModTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // set game path if not already set
            /*
            if (string.IsNullOrEmpty(Properties.Settings.Default.GamePath))
            {
                MessageBoxResult result = MessageBox.Show("User-defined path not found. Would you like to set one now?", "Path not found", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.InitialDirectory = Properties.Settings.Default.GamePath;
                    //openFileDialog.Filter = "Text Documents (*.txt)|*.txt|All files (*.*)|*.*";
                    openFileDialog.CheckFileExists = false;

                    if (openFileDialog.ShowDialog() == true)
                    {
                        Properties.Settings.Default.GamePath = openFileDialog.FileName;
                    }
                }
            }
            */
        }

        private void MenuItemOpen_Click(object sender, RoutedEventArgs e)
        {
            // let the user select a file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Properties.Settings.Default.GamePath;
            openFileDialog.Filter = "Text Documents (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == false)
            {
                return;
            }

            // parse file
            List<Pair> file = null;
            try
            {
                ICharStream stream = CharStreams.fromPath(openFileDialog.FileName);
                ParadoxLexer lexer = new ParadoxLexer(stream);
                ITokenStream tokens = new CommonTokenStream(lexer);
                ParadoxParser parser = new ParadoxParser(tokens);
                parser.BuildParseTree = true;
                ParadoxParser.FileContext tree = parser.file();
                ParadoxFileVisitor visitor = new ParadoxFileVisitor();
                file = visitor.VisitFile(tree);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not open the file:\n" + ex.Message, "Error", MessageBoxButton.OK);
            }

            try
            {
                AddFileToTreeView(file, FileTreeView);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not display file contents:\n" + ex.Message, "Error", MessageBoxButton.OK);
            }
        }

        private void AddFileToTreeView(List<Pair> pairs, TreeView treeView)
        {
            foreach (Pair pair in pairs)
            {
                treeView.Items.Add(pair);
            }
        }
    }
}
