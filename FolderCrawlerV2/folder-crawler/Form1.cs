using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace folder_crawler
{
    public partial class Form1 : Form
    {
        Microsoft.Msagl.Drawing.Graph graphres;
        string textboxplaceholder = "e.g. shenhebuild_2022.pdf";
        string startingpathGL = "";
        bool foundFirst = false;
        bool interruptit = false;
        public Form1()
        {
            InitializeComponent();
            tbox_filename.Text = textboxplaceholder;
            btn_interrupt.Enabled = false;
        }
        private void gViewer1_Load(object sender, EventArgs e)
        {
            graphres = new Microsoft.Msagl.Drawing.Graph("graph");

        }

        private void btn_choosefolder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    lbl_selecteddetail.Text = fbd.SelectedPath;
                }
            }
        }
        private void tbox_filename_clicked(object sender, EventArgs e)
        {
            if (tbox_filename.Text == textboxplaceholder)
            {
                tbox_filename.Text = "";
            } else if (tbox_filename.Text == "")
            {
                tbox_filename.Text = textboxplaceholder;
            }
        }
        RadioButton GetCheckedRadio(Control container)
        {
            foreach (var control in container.Controls)
            {
                RadioButton radio = control as RadioButton;

                if (radio != null && radio.Checked)
                {
                    return radio;
                }
            }

            return null;
        }
        private void do_dfs(string startingpath, string filename, bool findall, BackgroundWorker worker, DoWorkEventArgs e)
        {
           
            if (e.Cancel || interruptit || (!findall && foundFirst))
            {
                Console.WriteLine("get here bro");
                return;
            }
            else if (worker.CancellationPending)
            {
                e.Cancel = true;
                interruptit = true;
                Console.WriteLine("also get here lmao");
                return;
            }
            else
            {
                var allfolder = Directory.GetDirectories(startingpath).Select(f => new DirectoryInfo(f).Name);
                var files = Directory.GetFiles(startingpath).Select(Path.GetFileName);
                string toparse = startingpath.Replace(startingpathGL, "");
                string[] indifolder = toparse.Trim().Split(new [] { Path.DirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries);
                bool foundThisContext = false;
                Console.WriteLine(startingpathGL);
                foreach (string fldr in indifolder) Console.WriteLine(fldr);
                foreach (string file in allfolder)
                {
                    if (startingpath == startingpathGL)
                    {
                        graphres.AddEdge(startingpath, file);
                    }
                    else
                    {
                        graphres.AddEdge(new DirectoryInfo(startingpath).Name, file);
                    }
                    gViewer1.Graph = graphres;
                    do_dfs(Path.Combine(startingpath, file), filename, findall, worker, e);
                }
                if (files.Count() <= 0)
                {

                }
                else
                {
                    foreach (string file in files)
                    {
                        string parentNode = "";
                        if (startingpath == startingpathGL) parentNode = startingpath;
                        else parentNode = new DirectoryInfo(startingpath).Name;

                        if (file == filename)
                        {
                            foundFirst = true;
                            foundThisContext = true;
                            graphres.AddEdge(parentNode, file).Attr.Color = Microsoft.Msagl.Drawing.Color.Blue;
                            graphres.FindNode(file).Attr.Color = Microsoft.Msagl.Drawing.Color.Blue;
                            if (!findall) break;
                        } else
                        {
                            graphres.AddEdge(parentNode, file).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                            graphres.FindNode(file).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                        }
                        gViewer1.Graph = graphres;
                    }
                    if (foundThisContext)
                    {
                        int i = 0;
                        graphres.FindNode(startingpathGL).Attr.Color = Microsoft.Msagl.Drawing.Color.Blue;
                        while (indifolder.Length > 0 && i < indifolder.Length)
                        {
                            foreach (Microsoft.Msagl.Drawing.Edge edge in graphres.Edges)
                            {
                                string src;
                                string tgt = indifolder[i];
                                if (i == 0) src = startingpathGL;
                                else src = indifolder[i - 1];
                                if (edge.Source == src && edge.Target == tgt)
                                {
                                    graphres.RemoveEdge(edge);
                                    graphres.FindNode(tgt).Attr.Color = Microsoft.Msagl.Drawing.Color.Blue;
                                    graphres.AddEdge(src, tgt).Attr.Color = Microsoft.Msagl.Drawing.Color.Blue;
                                    i++;
                                    gViewer1.Graph = graphres;
                                    break;
                                }

                            }
                        }
                    } else
                    {
                        int i = 0;
                        if (graphres.FindNode(startingpathGL).Attr.Color != Microsoft.Msagl.Drawing.Color.Blue)
                            graphres.FindNode(startingpathGL).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                        while (indifolder.Length > 0 && i < indifolder.Length)
                        {
                            foreach (Microsoft.Msagl.Drawing.Edge edge in graphres.Edges)
                            {
                                string src;
                                string tgt = indifolder[i];
                                if (i == 0) src = startingpathGL;
                                else src = indifolder[i - 1];
                                if (edge.Source == src && edge.Target == tgt)
                                {
                                    if (edge.Attr.Color != Microsoft.Msagl.Drawing.Color.Blue)
                                    {
                                        graphres.RemoveEdge(edge);
                                        graphres.FindNode(tgt).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                                        graphres.AddEdge(src, tgt).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                                        gViewer1.Graph = graphres;
                                    }
                                    i++;
                                    break;
                                }

                            }
                        }
                    }
                }
            }
        }
        // BACKGROUND WORKER STUFF (INCLUDE START / CANCEL BTN)
        private void btn_search_Click(object sender, EventArgs e)
        {
            // PREREQUISITES
            interruptit = false;
            startingpathGL = lbl_selecteddetail.Text.Trim();
            string filename = tbox_filename.Text.Trim();
            bool findalloccurences = cbox_alloccurence.Checked;
            RadioButton method = GetCheckedRadio(method_panel_group);
            if (method == null)
            {
                MessageBox.Show("Method Not Selected", "Error");
            }
            else
            if (filename.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                MessageBox.Show("Invalid Filename", "Error");
            }
            else
            if (startingpathGL == "None") MessageBox.Show("Starting Path Not Selected", "Error");
            else
            if (startingpathGL.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
            {
                MessageBox.Show("Invalid Starting Path", "Error");
            }
            else
            {
                foundFirst = false;
                btn_search.Enabled = false;
                btn_interrupt.Enabled = true;
                graphres = new Microsoft.Msagl.Drawing.Graph("graph");
                gViewer1.Graph = graphres;
                Console.WriteLine(startingpathGL);
                Console.WriteLine(filename);
                Console.WriteLine(findalloccurences);
                if (method == radio_bfs) { Console.WriteLine("BFS"); }
                else if (method == radio_dfs)
                {
                    Console.WriteLine("DFS");
                }
                List<object> workerargs = new List<object>();
                workerargs.Add(method);
                workerargs.Add(startingpathGL);
                workerargs.Add(filename);
                workerargs.Add(findalloccurences);
                bg_searching.RunWorkerAsync(workerargs);
            }
        }

        private void btn_interrupt_Click(object sender, EventArgs e)
        {
            bg_searching.CancelAsync();
            interruptit = true;
        }

        private void bg_searching_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            List<object> workerArgs = e.Argument as List<object>;
            RadioButton r_method = workerArgs[0] as RadioButton;
            if (r_method == radio_dfs)
            {
                do_dfs((string)workerArgs[1], (string)workerArgs[2], (bool)workerArgs[3], worker, e);
            }
        }

        private void bg_searching_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message, "Error");
            } else if (e.Cancelled || interruptit)
            {
                Console.WriteLine("Cancelled a Process");
            } else
            {
                Console.WriteLine("Executed Sucessfully");
            }
            btn_search.Enabled = true;
            btn_interrupt.Enabled=false;
        }

        private void bg_searching_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }
    }
}
