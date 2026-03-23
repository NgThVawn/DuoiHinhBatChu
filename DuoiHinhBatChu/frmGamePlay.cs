using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DuoiHinhBatChu.BLL;
using DuoiHinhBatChu.DAL.Entites;

namespace DuoiHinhBatChu
{
    public partial class frmGamePlay : Form
    {
        int playerID;
        public int CurrentQuestionID, elapsedTimeInSeconds = 0;
        string answer;
        bool isHintUsed = false;
        frmHome frmHome;
        private readonly PlayerService playerService = new PlayerService();
        private readonly QuestionService questionService = new QuestionService();
        private readonly AnsweredQuestionService answeredQuestionService = new AnsweredQuestionService();
        public frmGamePlay(int playerID, frmHome home, int volume)
        {
            InitializeComponent();
            this.playerID = playerID;
            this.frmHome = home;
            wmpAnswerSound.settings.volume = volume;
        }
        public void SetVolume(int volume)
        {
            frmHome.SetVolume(volume);
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
        private void CreateLetterButton()
        {
            flpLetter.Controls.Clear();
            char[] alphabet = new char[]
            {
                'A', 'B', 'C', 'D', 'E', 'G', 'H', 'I', 'K', 'L', 'M', 'N', 'O',
                'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'X', 'Y'
            };
            flpLetter.FlowDirection = FlowDirection.LeftToRight;
            flpLetter.WrapContents = true;
            flpLetter.Padding = new Padding(10);
            foreach (char c in alphabet)
            {
                Button btn = new Button
                {
                    Text = c.ToString(),
                    Width = 40,
                    Height = 40,
                    Margin = new Padding(5)

                };
                btn.BackColor = Color.FromArgb(102, 204, 153);
                btn.Font = new Font("Arial", 12, FontStyle.Bold);
                btn.ForeColor = Color.White;
                btn.Click += btnLetter_Click;
                flpLetter.Controls.Add(btn);
                CenterFlowPanelContent(flpLetter);
            }
        }
        private void btnLetter_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                foreach (Button answerButton in flpAnswer.Controls)
                {
                    if (string.IsNullOrEmpty(answerButton.Text))
                    {
                        answerButton.Text = btn.Text;
                        break;
                    }
                }
            }

            if (IsAnswerComplete())
            {
                CheckAnswer();
            }
        }
        public string RemoveDiacritics(string input)
        {
            string[] vietnameseCharacters = new string[]
            {
                "Á", "À", "Ả", "Ã", "Ạ", "Â", "Ấ", "Ầ", "Ẩ", "Ẫ", "Ậ", "Ă", "Ắ", "Ằ", "Ẳ", "Ẵ", "Ặ",
                "É", "È", "Ẻ", "Ẽ", "Ẹ", "Ê", "Ế", "Ề", "Ể", "Ễ", "Ệ",
                "Í", "Ì", "Ỉ", "Ĩ", "Ị",
                "Ó", "Ò", "Ỏ", "Õ", "Ọ", "Ô", "Ố", "Ồ", "Ổ", "Ỗ", "Ộ", "Ơ", "Ớ", "Ờ", "Ở", "Ỡ", "Ợ",
                "Ú", "Ù", "Ủ", "Ũ", "Ụ", "Ư", "Ứ", "Ừ", "Ử", "Ữ", "Ự",
                "Ý", "Ỳ", "Ỷ", "Ỹ", "Ỵ",
                "Đ"
            };

            string[] correspondingCharacters = new string[]
            {
                "A", "A", "A", "A", "A", "A", "A", "A", "A", "A", "A", "A", "A", "A", "A", "A", "A",
                "E", "E", "E", "E", "E", "E", "E", "E", "E", "E", "E",
                "I", "I", "I", "I", "I",
                "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O",
                "U", "U", "U", "U", "U", "U", "U", "U", "U", "U", "U",
                "Y", "Y", "Y", "Y", "Y",
                "D"
            };

            for (int i = 0; i < vietnameseCharacters.Length; i++)
            {
                input = input.Replace(vietnameseCharacters[i], correspondingCharacters[i]);
            }
            return input.Replace(" ", string.Empty);

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
        private void DisplayQuestion(Question question)
        {
            flpAnswer.Controls.Clear();
            using (var ms = new MemoryStream(question.Image))
            {
                ptbQuestionImage.Image = Image.FromStream(ms);
            }
            ptbQuestionImage.SizeMode = PictureBoxSizeMode.StretchImage;

            CurrentQuestionID = question.QuestionID;
            isHintUsed = false;
            elapsedTimeInSeconds = 0;
            UpdateTimerLabel();
            questionTimer.Start();

            answer = RemoveDiacritics(question.Answer);
            foreach (char c in answer)
            {
                flpAnswer.FlowDirection = FlowDirection.LeftToRight;
                flpAnswer.WrapContents = true;
                flpAnswer.Padding = new Padding(5);
                Button btn = new Button
                {
                    Text = "",
                    Width = 40,
                    Height = 40,
                    Margin = new Padding(5)
                };
                btn.BackColor = Color.FromArgb(102, 204, 153);
                btn.Font = new Font("Arial", 12, FontStyle.Bold);
                btn.ForeColor = Color.White;
                btn.Click += AnswerButton_Click;
                flpAnswer.Controls.Add(btn);
                CenterFlowPanelContent(flpAnswer);
            }
        }
        public void LoadQuestion(int questionID)
        {
            try
            {
                if (questionService.CheckCompleted(playerID))
                {
                    MessageBox.Show("Chúc mừng bạn đã hoàn thành tất cả câu hỏi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SaveBeforeExit();
                    Close();
                    return;
                }
                Question question;
                if (questionID == 0)
                {
                    question = questionService.GetRandomQuestion(playerID);
                }
                else question = questionService.GetQuestionByID(questionID);
                if (question != null)
                {
                    DisplayQuestion(question);
                }
                else throw new Exception("Không tìm thấy câu hỏi!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmGamePlay_Load(object sender, EventArgs e)
        {
            try
            {
                CreateLetterButton();
                Player player = playerService.GetAll().First(p => p.PlayerID == playerID);
                if (player.LastQuestion != null)
                {
                    LoadQuestion((int)player.LastQuestion);
                }
                else
                {
                    LoadQuestion(0);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AnswerButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && !string.IsNullOrEmpty(btn.Text))
            {
                btn.Text = "";
            }
        }
        private bool IsAnswerComplete()
        {
            foreach (Button answerBtn in flpAnswer.Controls)
            {
                if (string.IsNullOrEmpty(answerBtn.Text))
                {
                    return false;
                }
            }
            return true;
        }
        private void CheckAnswer()
        {
            string userAnswer = "";
            foreach (Button btn in flpAnswer.Controls)
            {
                userAnswer += btn.Text;
            }
            if(userAnswer != answer)
            {
                wmpAnswerSound.URL = "Sound/Wrong.wav";
                wmpAnswerSound.Ctlcontrols.play();
                MessageBox.Show("Đáp án chưa đúng rồi, thử lại với đáp án khác nhé!", "Kết quả", MessageBoxButtons.OK);
                return;
            }
            questionTimer.Stop();
            wmpAnswerSound.URL = "Sound/Correct.wav";
            wmpAnswerSound.Ctlcontrols.play();
            SaveAnsweredQuestion();
            answer = "";
            using (frmResult result = new frmResult(this, CurrentQuestionID))
            {
                result.ShowDialog();
            }
        }
        public void SaveBeforeExit()
        {
            var player = playerService.GetAll().FirstOrDefault(p => p.PlayerID == playerID);
            player.LastQuestion = CurrentQuestionID == 0 ? (int?)null : CurrentQuestionID;
            playerService.AddOrUpdate(player);
        }
        private int ScoreCalculator(int time, bool hint)
        {
            if (hint) return 15;
            if (time <= 30) return 100;
            if (time <= 60) return 90;
            if (time <= 90) return 75;
            if (time <= 120) return 50;
            if (time <= 180) return 30;
            return 20;
        }
        public void SaveAnsweredQuestion()
        {
            var answeredQuestion = new AnsweredQuestion()
            {
                PlayerID = playerID,
                QuestionID = CurrentQuestionID,
                AnswerTime = elapsedTimeInSeconds,
                UseHint = isHintUsed,
                Score = ScoreCalculator(elapsedTimeInSeconds, isHintUsed)
            };
            answeredQuestionService.Add(answeredQuestion);
        }
        private void btnMenu_Click(object sender, EventArgs e)
        {
            using (frmSetting setting = new frmSetting(this, frmHome.GetVolume(), wmpAnswerSound.settings.volume))
            {
                setting.ShowDialog();
            }
        }

        private void timeAnswer_Tick(object sender, EventArgs e)
        {
            elapsedTimeInSeconds++;
            UpdateTimerLabel();
        }

        private void frmGamePlay_FormClosing(object sender, FormClosingEventArgs e)
        {
            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn trở về màn hình chính?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                SaveBeforeExit();
            }
        }
        private void UpdateTimerLabel()
        {
            int minutes = elapsedTimeInSeconds / 60;
            int seconds = elapsedTimeInSeconds % 60;
            lblTime.Text = $"{minutes:D2} : {seconds:D2}";
        }

        private void btnHint_Click(object sender, EventArgs e)
        {
            Player player = playerService.GetAll().First(p => p.PlayerID == playerID);
            if (player.HintCount == 0)
            {
                MessageBox.Show("Bạn đã hết lượt gợi ý!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (isHintUsed)
            {
                MessageBox.Show(questionService.GetHint(CurrentQuestionID), "Hint", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn sử dụng gợi ý?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    isHintUsed = true;
                    MessageBox.Show(questionService.GetHint(CurrentQuestionID), "Hint", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        public void SetSoundVolume(int volume)
        {
            wmpAnswerSound.settings.volume = volume;
        }
    }
}
