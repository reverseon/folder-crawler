using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        int leftLatest = 0;
        int topLatest = -30;
        Stopwatch sw;
        System.Timers.Timer timer;
        List<string> pathFound = new List<string>();
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
        private void do_bfs(string startingpath, string filename, bool findall, BackgroundWorker worker, DoWorkEventArgs e)
        {
            Console.WriteLine("executed BFS");
            if (e.Cancel || interruptit || (!findall && foundFirst))
            {
                Console.WriteLine("get here bro in BFS");
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
                string[] indifolder = toparse.Trim().Split(new[] { Path.DirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries);
                bool foundThisContext = false;
                Console.WriteLine(startingpathGL);
                foreach (string fldr in indifolder) Console.WriteLine(fldr);
                foreach (string file in files)
                {
                    string parentNode = "";
                    if (startingpath == startingpathGL) parentNode = startingpath;
                    else parentNode = new DirectoryInfo(startingpath).Name;

                    if (file == filename && !(!findall && foundFirst))
                    {
                        foundFirst = true;
                        foundThisContext = true;
                        graphres.AddEdge(parentNode, file).Attr.Color = Microsoft.Msagl.Drawing.Color.Blue;
                        graphres.FindNode(file).Attr.Color = Microsoft.Msagl.Drawing.Color.Blue;
                        // add label
                        if (pnl_folderloc.InvokeRequired)
                        {
                            pnl_folderloc.BeginInvoke((MethodInvoker)delegate ()
                            {
                                LinkLabel fileLinkLabel = new System.Windows.Forms.LinkLabel();
                                fileLinkLabel.Links.Clear();
                                fileLinkLabel.Location = new System.Drawing.Point(leftLatest, topLatest + 30);
                                topLatest = fileLinkLabel.Top;
                                fileLinkLabel.LinkVisited = false;
                                fileLinkLabel.Text = Path.Combine(startingpath, file);
                                fileLinkLabel.Links.Add(0, fileLinkLabel.Text.Length);
                                fileLinkLabel.AutoSize = true;
                                fileLinkLabel.LinkColor = System.Drawing.ColorTranslator.FromHtml("#00E396");
                                fileLinkLabel.VisitedLinkColor = System.Drawing.ColorTranslator.FromHtml("#008FFB");
                                fileLinkLabel.ActiveLinkColor = System.Drawing.ColorTranslator.FromHtml("#FEB019");
                                fileLinkLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(link_lbl_click_handler);
                                pnl_folderloc.Controls.Add(fileLinkLabel);
                            });
                        }
                        else
                        {
                            LinkLabel fileLinkLabel = new System.Windows.Forms.LinkLabel();
                            fileLinkLabel.Links.Clear();
                            fileLinkLabel.Location = new System.Drawing.Point(leftLatest, topLatest + 30);
                            topLatest = fileLinkLabel.Top;
                            fileLinkLabel.LinkVisited = false;
                            fileLinkLabel.Text = Path.Combine(startingpath, file);
                            fileLinkLabel.Links.Add(0, fileLinkLabel.Text.Length);
                            fileLinkLabel.AutoSize = true;
                            fileLinkLabel.LinkColor = System.Drawing.ColorTranslator.FromHtml("#00E396");
                            fileLinkLabel.VisitedLinkColor = System.Drawing.ColorTranslator.FromHtml("#008FFB");
                            fileLinkLabel.ActiveLinkColor = System.Drawing.ColorTranslator.FromHtml("#FEB019");
                            fileLinkLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(link_lbl_click_handler);
                            pnl_folderloc.Controls.Add(fileLinkLabel);
                        }
                        if (!findall) break;
                    }
                    else if (!(!findall && foundFirst))
                    {
                        graphres.AddEdge(parentNode, file).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                        graphres.FindNode(file).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                    }
                    else
                    {
                        graphres.AddEdge(parentNode, file);
                    }
                    /*gViewer1.Graph = graphres;*/
                }
                if (!(!findall && foundFirst))
                {
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
                        do_bfs(Path.Combine(startingpath, file), filename, findall, worker, e);
                    }
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
                                /*gViewer1.Graph = graphres;*/
                                break;
                            }

                        }
                    }
                }
                else
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
                                    /*gViewer1.Graph = graphres;*/
                                }
                                i++;
                                break;
                            }

                        }
                    }
                }
                if (gViewer1.InvokeRequired)
                {
                    gViewer1.BeginInvoke((MethodInvoker)delegate ()
                    {
                        gViewer1.Graph = graphres;
                    });
                }
                else
                {
                    gViewer1.Graph = graphres;
                }
                System.Threading.Thread.Sleep(100);
            }
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
                    do_dfs(Path.Combine(startingpath, file), filename, findall, worker, e);
                }
                foreach (string file in files)
                {
                    string parentNode = "";
                    if (startingpath == startingpathGL) parentNode = startingpath;
                    else parentNode = new DirectoryInfo(startingpath).Name;

                    if (file == filename && !(!findall && foundFirst))
                    {
                        foundFirst = true;
                        foundThisContext = true;
                        graphres.AddEdge(parentNode, file).Attr.Color = Microsoft.Msagl.Drawing.Color.Blue;
                        graphres.FindNode(file).Attr.Color = Microsoft.Msagl.Drawing.Color.Blue;
                        // add label
                        if (pnl_folderloc.InvokeRequired)
                        {
                            pnl_folderloc.BeginInvoke((MethodInvoker)delegate ()
                            {
                                LinkLabel fileLinkLabel = new System.Windows.Forms.LinkLabel();
                                fileLinkLabel.Links.Clear();
                                fileLinkLabel.Location = new System.Drawing.Point(leftLatest, topLatest + 30);
                                topLatest = fileLinkLabel.Top;
                                fileLinkLabel.LinkVisited = false;
                                fileLinkLabel.Text = Path.Combine(startingpath, file);
                                fileLinkLabel.Links.Add(0, fileLinkLabel.Text.Length);
                                fileLinkLabel.AutoSize = true;
                                fileLinkLabel.LinkColor = System.Drawing.ColorTranslator.FromHtml("#00E396");
                                fileLinkLabel.VisitedLinkColor = System.Drawing.ColorTranslator.FromHtml("#008FFB");
                                fileLinkLabel.ActiveLinkColor = System.Drawing.ColorTranslator.FromHtml("#FEB019");
                                fileLinkLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(link_lbl_click_handler);
                                pnl_folderloc.Controls.Add(fileLinkLabel);
                            });
                        }
                        else
                        {
                            LinkLabel fileLinkLabel = new System.Windows.Forms.LinkLabel();
                            fileLinkLabel.Links.Clear();
                            fileLinkLabel.Location = new System.Drawing.Point(leftLatest, topLatest + 30);
                            topLatest = fileLinkLabel.Top;
                            fileLinkLabel.LinkVisited = false;
                            fileLinkLabel.Text = Path.Combine(startingpath, file);
                            fileLinkLabel.Links.Add(0, fileLinkLabel.Text.Length);
                            fileLinkLabel.AutoSize = true;
                            fileLinkLabel.LinkColor = System.Drawing.ColorTranslator.FromHtml("#00E396");
                            fileLinkLabel.VisitedLinkColor = System.Drawing.ColorTranslator.FromHtml("#008FFB");
                            fileLinkLabel.ActiveLinkColor = System.Drawing.ColorTranslator.FromHtml("#FEB019");
                            fileLinkLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(link_lbl_click_handler);
                            pnl_folderloc.Controls.Add(fileLinkLabel);
                        }
                        if (!findall) break;
                    } else if (!(!findall && foundFirst))
                    {
                        graphres.AddEdge(parentNode, file).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                        graphres.FindNode(file).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                    } else
                    {
                        graphres.AddEdge(parentNode, file);
                    }
                    /*gViewer1.Graph = graphres;*/
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
                                /*gViewer1.Graph = graphres;*/
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
                                    /*gViewer1.Graph = graphres;*/
                                }
                                i++;
                                break;
                            }

                        }
                    }
                }
            }
            if (gViewer1.InvokeRequired)
            {
                gViewer1.BeginInvoke((MethodInvoker)delegate ()
                {
                    gViewer1.Graph = graphres;
                });
            } else
            {
                gViewer1.Graph = graphres;
            }
            System.Threading.Thread.Sleep(100);
        }
        // BACKGROUND WORKER STUFF (INCLUDE START / CANCEL BTN)
        private void btn_search_Click(object sender, EventArgs e)
        {
            // PREREQUISITES
            pnl_folderloc.Controls.Clear();
            topLatest = -30;
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
                sw = new Stopwatch();
                timer = new System.Timers.Timer(10);
                timer.Elapsed += timer_Tick;
                timer.AutoReset = true;
                timer.Enabled = true;
                timer.Start();
                sw.Start();
                if (lbl_time_elapsed_detail.InvokeRequired)
                {
                    lbl_time_elapsed_detail.BeginInvoke((MethodInvoker)delegate
                    {
                        lbl_time_elapsed_detail.Text = sw.Elapsed.Seconds.ToString() + "." + sw.Elapsed.Milliseconds.ToString() + "s";
                    });
                }
                else
                {
                    lbl_time_elapsed_detail.Text = sw.Elapsed.Seconds.ToString() + "." + sw.Elapsed.Milliseconds.ToString() + "s";
                }
                foundFirst = false;
                btn_search.Enabled = false;
                btn_interrupt.Enabled = true;
                graphres = new Microsoft.Msagl.Drawing.Graph("graph");
                if (gViewer1.InvokeRequired)
                {
                    gViewer1.BeginInvoke((MethodInvoker)delegate ()
                    {
                        gViewer1.Graph = graphres;
                    });
                }
                else
                {
                    gViewer1.Graph = graphres;
                }
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

/*                timer.Stop(); sw.Stop();
                lbl_time_elapsed_detail.Text = sw.Elapsed.Milliseconds.ToString() + "s";*/
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
            } else 
            if (r_method == radio_bfs)
            {
                do_bfs((string)workerArgs[1], (string)workerArgs[2], (bool)workerArgs[3], worker, e);
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
            sw.Stop();
            timer.Stop();
            if (lbl_time_elapsed_detail.InvokeRequired)
            {
                lbl_time_elapsed_detail.BeginInvoke((MethodInvoker)delegate
                {
                    lbl_time_elapsed_detail.Text = sw.Elapsed.Seconds.ToString() + "." + sw.Elapsed.Milliseconds.ToString() + "s";
                });
            }
            else
            {
                lbl_time_elapsed_detail.Text = sw.Elapsed.Seconds.ToString() + "." + sw.Elapsed.Milliseconds.ToString() + "s";
            }
            btn_search.Enabled = true;
            btn_interrupt.Enabled=false;
        }

        private void bg_searching_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }
        private void timer_Tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (lbl_time_elapsed_detail.InvokeRequired)
            {
                lbl_time_elapsed_detail.BeginInvoke((MethodInvoker)delegate
                {
                    lbl_time_elapsed_detail.Text = sw.Elapsed.Seconds.ToString() + "." + sw.Elapsed.Milliseconds.ToString() + "s";
                });
            } else
            {
                lbl_time_elapsed_detail.Text = sw.Elapsed.Seconds.ToString() + "." + sw.Elapsed.Milliseconds.ToString() + "s";
            }
        }

        private void link_lbl_click_handler(object sender, LinkLabelLinkClickedEventArgs e)
        {
            e.Link.Visited = true;
            LinkLabel tempo = (LinkLabel)sender;
            Console.WriteLine("Cliked it | {0}", tempo.Text);
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
            {
                FileName = Path.GetDirectoryName(tempo.Text),
                UseShellExecute = true,
                Verb = "open"
            });
        }
    }
}
