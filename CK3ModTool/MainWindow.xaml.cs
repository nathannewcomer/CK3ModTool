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
        }

        private void MenuItemOpen_Click(object sender, RoutedEventArgs e)
        {
            // let the user select a file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"; ;

            if (openFileDialog.ShowDialog() == false)
            {
                return;
            }

            // parse file
            ICharStream stream = CharStreams.fromPath(openFileDialog.FileName);
            ParadoxLexer lexer = new ParadoxLexer(stream);
            ITokenStream tokens = new CommonTokenStream(lexer);
            ParadoxParser parser = new ParadoxParser(tokens);
            parser.BuildParseTree = true;
            ParadoxParser.FileContext tree = parser.file();
            ParadoxFileListener listener = new ParadoxFileListener();

            ParseTreeWalker.Default.Walk(listener, tree);
        }
    }
}
