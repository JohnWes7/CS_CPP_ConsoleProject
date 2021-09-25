using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;

//=================================================
//        created by JohnWes7
//        https://github.com/JohnWes7
//=================================================

namespace txt_reader
{
    class PrintTool
    {
        /// <summary>
        /// 打印时存放全部打印行的变量
        /// </summary>
        private string[] printLines;
        /// <summary>
        /// 打印时计算
        /// </summary>
        private int count;

        public PrintTool(string[] printLines)
        {
            //复制一份 避免更改
            string[] temp = new string[printLines.Length];
            for (int i = 0; i < printLines.Length; i++)
            {
                temp[i] = printLines[i];
            }

            this.printLines = temp;

            count = 0;
        }

        // The PrintPage event is raised for each page to be printed.
        public void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            Font printFont = new Font("Arial", 10);
            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;

            // Calculate the number of lines per page.
            linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);

            // Print each line of the file.
            //&& ((line = streamToPrint.ReadLine()) != null)
            // 这里判断有没有打印完或者打印不下了
            while (count < linesPerPage && count < printLines.Length)
            {
                yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
                ev.Graphics.DrawString(printLines[count], printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
                count++;
            }

            // If more lines exist, print another page.
            // 如果还没打印完就下一张纸
            if (count < printLines.Length)
                ev.HasMorePages = true;
            else
                ev.HasMorePages = false;
        }


    }
}
