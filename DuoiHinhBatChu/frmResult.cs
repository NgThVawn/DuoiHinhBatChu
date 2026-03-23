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
using DuoiHinhBatChu.BLL;
using DuoiHinhBatChu.DAL;

namespace DuoiHinhBatChu
{
    public partial class frmResult : Form
    {
        private readonly QuestionService questionService = new QuestionService();
        frmGamePlay frmGamePlay;
        int questionID;
        public frmResult(frmGamePlay frmGamePlay, int questionID)
        {
            InitializeComponent();
            this.frmGamePlay = frmGamePlay;
            this.questionID = questionID;

        }
        protected override void WndProc(ref Message m)
        {
            const int WM_NCLBUTTONDOWN = 0xA1;
            const int HTCAPTION = 0x2;

            if (m.Msg == WM_NCLBUTTONDOWN && m.WParam.ToInt32() == HTCAPTION)
            {
                return;
            }

            base.WndProc(ref m);
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            frmGamePlay.LoadQuestion(0);
            frmGamePlay.Close();
            Close();
        }

        private void frmResult_Load(object sender, EventArgs e)
        {
            var question = questionService.GetQuestionByID(questionID);
            using (var ms = new MemoryStream(question.Image))
            {
                ptbQuestionImage.Image = Image.FromStream(ms);
            }
            ptbQuestionImage.SizeMode = PictureBoxSizeMode.StretchImage;
            flpAnswer.Controls.Clear(); // Xóa các phần tử cũ trong FlowLayoutPanel

            foreach (char c in question.Answer)
            {
                if (char.IsWhiteSpace(c))
                {
                    // Thêm khoảng cách giữa các từ
                    Label spacer = new Label
                    {
                        Width = 20, // Chiều rộng khoảng cách
                        Height = 40 // Để đồng nhất với chiều cao của các Button
                    };
                    flpAnswer.Controls.Add(spacer);
                }
                else
                {
                    // Thêm Button cho ký tự
                    Button btn = new Button
                    {
                        Text = c.ToString(),            // Ban đầu không hiển thị ký tự
                        Tag = c,              // Lưu ký tự gốc vào Tag để kiểm tra đáp án
                        Width = 40,
                        Height = 40,
                        Margin = new Padding(3), // Khoảng cách giữa các Button
                        BackColor = Color.FromArgb(102, 204, 153),
                        Font = new Font("Arial", 12, FontStyle.Bold),
                        ForeColor = Color.White
                    };
                    flpAnswer.Controls.Add(btn);
                    CenterFlowPanelContent(flpAnswer);
                }
            }
            int minutes = frmGamePlay.elapsedTimeInSeconds / 60;
            int seconds = frmGamePlay.elapsedTimeInSeconds % 60;
            lblTime.Text = $"Thời gian: {minutes:D2} : {seconds:D2}";
        }
        private void CenterFlowPanelContent(FlowLayoutPanel flp)
        {
            int totalWidth = 0;
            foreach (Control ctrl in flp.Controls)
            {
                totalWidth += ctrl.Width + ctrl.Margin.Left + ctrl.Margin.Right;
            }
            int emptySpace = flp.ClientSize.Width - totalWidth;
            if (emptySpace > 0)
            {
                flp.Padding = new Padding(emptySpace / 2, 0, emptySpace / 2, 0);
            }
            else
            {
                flp.Padding = new Padding(0);
            }
        }
        private void btnContinue_Click(object sender, EventArgs e)
        {
            frmGamePlay.LoadQuestion(0);
            Close();
        }
    }
}
