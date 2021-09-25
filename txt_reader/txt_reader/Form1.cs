using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Printing;

//=================================================
//        created by JohnWes7
//        https://github.com/JohnWes7
//=================================================
namespace txt_reader
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 当前文件的路径
        /// </summary>
        private string current_file_path = null;
        /// <summary>
        /// 获取或设置当前文件名筛选器字符串，该字符串决定对话框的“另存为文件类型”或“文件类型”框中出现的选择内容。
        /// </summary>
        private readonly string file_filter = "json files (*.json)|*.json|txt files (*.txt)|*.txt|All files (*.*)|*.*";
        private Encoding encoding = Encoding.UTF8;
        private string name = "text_reader";
        private bool isChanged { get; set; } = false;



        public Form1()
        {
            InitializeComponent();

            //更改初始化窗口名字
            UpdateFormName();
            isChanged = false;
        }


        private void CreatNewFile(string title)
        {
            using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
            {
                Stream myStream;
                saveFileDialog1.Title = title;
                saveFileDialog1.Filter = this.file_filter;
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;    //获取或设置一个值，该值指示该对话框在关闭前是否将目录还原为之前选定的目录。

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    current_file_path = saveFileDialog1.FileName;    //储存新文件的路径

                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        //获取到写入流 写入(自选编码格式)
                        //byte[] temp = System.Text.Encoding.UTF8.GetBytes(richTextBox1.Text);
                        //myStream.Write(temp, 0, temp.Length);

                        Tool.write(myStream, richTextBox1.Text, this.encoding);

                        myStream.Close();
                    }
                }
            }
            isChanged = false;
        }
        private void removeSelectionText(RichTextBox richTextBox)
        {
            string str = richTextBox.Text;
            int start = richTextBox.SelectionStart;
            int lenght = richTextBox.SelectionLength;

            str = str.Remove(start, lenght);
            richTextBox.Text = str;
            richTextBox.SelectionStart = start; //回复选定位置
        }
        private void insertText(RichTextBox richTextBox, string str)
        {
            int start = richTextBox.SelectionStart;

            richTextBox.Text = richTextBox.Text.Insert(start, str);
            richTextBox.SelectionStart = start;
        }
        private void touchFish()
        {
            MessageBox.Show("没做", "摸了");
        }
        private void UpdateFormName()
        {
            if (current_file_path == null)
            {
                this.Text = this.name;
                return;
            }


            string filename = "text_reader";
            try
            {
                filename = Path.GetFileName(current_file_path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (File.Exists(current_file_path))
            {
                this.Text = filename;
            }
            else
            {
                this.Text = filename + "(已被删除)";
            }
            
        }
        private void UpdateFormNameWithChanged()
        {
            if (current_file_path == null)
            {
                this.Text = this.name + "*";
                return;
            }


            string filename = "text_reader";
            try
            {
                filename = Path.GetFileName(current_file_path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (File.Exists(current_file_path))
            {
                this.Text = filename + "*";
            }
            else
            {
                this.Text = filename + "(已被删除)*";
            }
        }
        private void save()
        {
            if (this.current_file_path != null && File.Exists(current_file_path))
            {
                Tool.write(this.current_file_path, richTextBox1.Text, Encoding.UTF8);
                isChanged = false;
            }
            else
            {
                CreatNewFile("另存为");
            }
            UpdateFormName();
        }
        private void closing()
        {
            if (isChanged)
            {
                switch (MessageBox.Show("是否保存对文件的更改？", this.name, MessageBoxButtons.YesNoCancel))
                {
                    case DialogResult.Yes:
                        save();
                        System.Environment.Exit(0);
                        break;
                    case DialogResult.No:
                        System.Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }
        private void closing(FormClosingEventArgs e)
        {
            if (isChanged)
            {
                switch (MessageBox.Show("是否保存对文件的更改？", this.name, MessageBoxButtons.YesNoCancel))
                {
                    case DialogResult.Yes:
                        save();
                        break;
                    case DialogResult.No:
                        break;
                    default:
                        e.Cancel = true;
                        break;
                }
            }
        }


        /// <summary>
        /// 新起文件的回调函数 就是另存为
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            CreatNewFile("新建");
            UpdateFormName();
        }
        /// <summary>
        /// 打开文件按钮的回调函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"e:\";   //初始路径
                openFileDialog.Multiselect = false;         //获取或设置一个值，该值指示对话框是否允许选择多个文件。
                openFileDialog.FilterIndex = 2;             //获取或设置文件对话框中当前选定筛选器的索引。(继承自 FileDialog)
                openFileDialog.Title = "请选择文件";
                openFileDialog.Filter = this.file_filter;  //设置要选择的文件的类型

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    current_file_path = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    Stream fileStream = openFileDialog.OpenFile();

                    string str;
                    Tool.reader(fileStream, out str, this.encoding);

                    richTextBox1.Text = str;
                }
            }
            isChanged = false;
            UpdateFormName();
        }
        /// <summary>
        /// 当文本框更改的回调函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateFormNameWithChanged();
            isChanged = true;
        }
        /// <summary>
        /// 保存按钮回调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            save();
        }
        /// <summary>
        /// 复制按钮回调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            string str = richTextBox1.SelectedText;
            if (str != "")
            {
                Clipboard.SetDataObject(str);
            }
        }
        /// <summary>
        /// 粘贴按钮回调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < richTextBox1.Lines.Length; i++)
            {
                Trace.WriteLine(richTextBox1.Lines[i]);
            }
            
            IDataObject dataObject = Clipboard.GetDataObject();
            if (dataObject.GetDataPresent(DataFormats.Text))
            {
                //移除掉选择部分
                removeSelectionText(richTextBox1);
                //插入需要粘贴部分
                insertText(richTextBox1, (string)dataObject.GetData(DataFormats.Text));
            }
            else
            {
                MessageBox.Show("目前剪贴板中数据不可转换为文本", "错误");
            }
        }
        /// <summary>
        /// 剪切按钮回调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            string str = richTextBox1.SelectedText;
            if (str != "")
            {
                Clipboard.SetDataObject(str);
                
                removeSelectionText(richTextBox1);
            }
        }
        /// <summary>
        /// 打印按钮回调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            PrintTool pt = new PrintTool(richTextBox1.Lines);

            pd.PrintPage += pt.pd_PrintPage;
            pd.Print();
        }
        /// <summary>
        /// 帮助按钮回调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("这种事情我见的多了，我只想说懂得都懂，不懂的我也不多说了，自己好好想想吧，你也别来问我怎么回事，这里面利益牵扯太大了，说了对你我都没有好处，你就当不知道就行了，其余的我只能说这里水很深，牵扯到很多东西，详细情况你们很难找到的，网上大部分都删干净了，所以我说懂得都懂。然后，其实你懂的我也懂，谁让我们都懂呢，不懂的话也没必要装懂，毕竟里面牵扯到很多懂不了的事。这种事懂的人也没必要说出来，不懂的人看见又来问七问八，最后跟他说了他也不一定能懂，就算懂了以后也对他不好，毕竟懂的太多了不是好事。所以大家最好是不懂就不要去了解，懂太多不好。"
                , "懂的读懂这个程序怎么用");
        }
        /// <summary>
        /// 退出回调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closing();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreatNewFile("另存为");
            UpdateFormName();
        }
        /// <summary>
        /// 撤销
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanUndo)
            {
                richTextBox1.Undo();
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanRedo)
            {
                richTextBox1.Redo();
            }
        }

        private void editToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            undoToolStripMenuItem.Enabled = richTextBox1.CanUndo;
            redoToolStripMenuItem.Enabled = richTextBox1.CanRedo;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            closing(e);
        }
        /// <summary>
        /// 全选回调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }
    }
}
