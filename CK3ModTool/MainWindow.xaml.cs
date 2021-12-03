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
            openFileDialog.InitialDirectory = Properties.Settings.Default.GamePath;
            openFileDialog.Filter = "Text Documents (*.txt)|*.txt|Images (*.png)|*.png|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == false)
            {
                return;
            }

            // open an image
            string ext = System.IO.Path.GetExtension(openFileDialog.FileName);
            if (ext == ".png")
            {
                /*
                Image image = new Image();
                BitmapImage bitmap = new BitmapImage(new Uri(openFileDialog.FileName));
                image.Source = bitmap;
                ScrollViewer scrollViewer = new ScrollViewer();
                scrollViewer.Content = image;
                scrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
                scrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
                //scrollViewer.scroll
                DockPanel.SetDock(scrollViewer, Dock.Bottom);
                MainDockPanel.Children.Add(scrollViewer);
                */

                // open image and set to bottom of DockPanel
                Image image = new Image();
                //BitmapImage bitmap = new BitmapImage(new Uri(openFileDialog.FileName));
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(openFileDialog.FileName);
                bitmap.CreateOptions = BitmapCreateOptions.IgnoreColorProfile;
                bitmap.EndInit();
                image.Source = bitmap;
                image.SnapsToDevicePixels = true;
                RenderOptions.SetBitmapScalingMode(image, BitmapScalingMode.NearestNeighbor);
                ZoomBorder zoomBorder = new ZoomBorder();
                zoomBorder.Child = image;
                DockPanel.SetDock(zoomBorder, Dock.Bottom);
                MainDockPanel.Children.Add(zoomBorder);


            }

            // parse file
            /*
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

            // display contents of file to screen
            try
            {
                AddFileToTreeView(file, FileTreeView);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not display file contents:\n" + ex.Message, "Error", MessageBoxButton.OK);
            }
            */
        }

        private void AddFileToTreeView(List<Pair> pairs, TreeView treeView)
        {
            foreach (Pair pair in pairs)
            {
                treeView.Items.Add(GetTreeViewItem(pair));
            }
        }

        private TreeViewItem GetTreeViewItem(Pair pair)
        {
            TreeViewItem item = new TreeViewItem();
            item.Header = pair.Identifier;
            if (pair.Val.Identifier is not null)
            {
                item.Header += $" = {pair.Val.Identifier}";
            }
            else if (pair.Val.Object.InnerContents.Pairs is not null && pair.Val.Object.InnerContents.Pairs.Count > 0)
            {
                // inner pairs
                foreach (Pair p in pair.Val.Object.InnerContents.Pairs)
                {
                    item.Items.Add(GetTreeViewItem(p));
                }
            }
            else
            {
                // list
                foreach (string s in pair.Val.Object.InnerContents.List)
                {
                    item.Items.Add(s);
                }
            }

            return item;
        }

        private void EyeDropper_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            ColorTextBlock.Text = string.Format("R: {0} G: {1} B: {2}", e.NewValue?.R, e.NewValue?.G, e.NewValue?.B);
        }
    }
}
