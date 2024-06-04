using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NPOI.XWPF.UserModel;


namespace WindowsFormsApp2
{
    public class MyWord
    {
        public void ExportWord(string doc_text, string doc_path)
        {  //导出Word文件
            //创建一个Word文档对象
            XWPFDocument doc = new XWPFDocument();
            //在Word文档对象中创建一个段落对象
            XWPFParagraph paragraph = doc.CreateParagraph();
            paragraph.Alignment = ParagraphAlignment.LEFT;  //设置此段落对齐方式为左对齐
            paragraph.SpacingBetween = 1.5;    //设置段落的行距，如果Rule设置成EXACT，将此值乘12得到固定的磅值，否则为多倍行距
            paragraph.SpacingLineRule = LineSpacingRule.EXACT;    //设置行距的值类型为固定值，不设置的话默认为多倍行距，一定要在定义SpacingBetween值后设置此属性
            //在此段落对象中创建一个文本对象，并设置文本的字体、大小及颜色
            XWPFRun run = paragraph.CreateRun();
            run.FontFamily = "黑体"; run.FontSize = 12;
            run.SetText(doc_text);    //写入文本内容
            //创建Word文件并写入内容
            FileStream fs = new FileStream(doc_path, FileMode.Create);
            doc.Write(fs);
            fs.Close();
        }
        public string ImportWord(string word_path)
        {  //读取Word文件，并在此基础上操作
            FileStream fs = new FileStream(word_path, FileMode.Open);
            //根据提供的文件，创建一个Word文档对象
            XWPFDocument doc = new XWPFDocument(fs);
            //获取Word文档的所有段落对象
            StringBuilder sb = new StringBuilder();
            IList<XWPFParagraph> paragraphs = doc.Paragraphs;
            foreach (var para in paragraphs)
            {
                string text = para.ParagraphText; //获得文本
                var runs = para.Runs;
                // string styleid = para.Style;
                for (int i = 0; i < runs.Count; i++)
                {
                    var run = runs[i];
                    text = run.ToString(); //获得run的文本
                    sb.Append(text + "\n");
                }
            }
            return sb.ToString();
        }
    }
}