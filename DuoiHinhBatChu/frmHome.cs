using System;
using System.Windows.Forms;

namespace DuoiHinhBatChu
{
    public partial class frmHome : Form
    {
        public int playerID = 0, soundVolume = 50;
        public frmHome()
        {
            InitializeComponent();
            CenterForm();
            string soundFilePath = "Sound/BackgroundMusic.wav";
            wmpBackgroundMusic.URL = soundFilePath;
            wmpBackgroundMusic.settings.setMode("loop", true);
            wmpBackgroundMusic.Ctlcontrols.play();
        }
        private void CenterForm()
        {
            // Lấy kích thước màn hình
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            // Tính toán vị trí cho form để căn giữa màn hình
            int formWidth = this.Width;
            int formHeight = this.Height;

            this.Left = (screenWidth - formWidth) / 2;
            this.Top = (screenHeight - formHeight) / 2;
        }
        public void SetVolume(int volume)
        {
            wmpBackgroundMusic.settings.volume = volume;
        }
        public int GetVolume()
        {
            return wmpBackgroundMusic.settings.volume;
        }
        private void btnOption_Click(object sender, EventArgs e)
        {
            using(frmSetting Setting = new frmSetting(this, GetVolume(), soundVolume))
            {
                Setting.ShowDialog();
            }
        }
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            using (frmLogin playerName = new frmLogin(this))
            {
                playerName.ShowDialog();
            }
            if (playerID != 0)
            {
                Hide();
                using (frmGamePlay gamePlay = new frmGamePlay(playerID,this, soundVolume))
                {
                    gamePlay.ShowDialog();
                }
                if(playerID != 0) btnContinue.Visible = true;
                Show();
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
                Hide();
                using (frmGamePlay gamePlay = new frmGamePlay(playerID,this, soundVolume))
                {
                    gamePlay.ShowDialog();
                }
                Show();
        }

        private void btnRanking_Click(object sender, EventArgs e)
        {
            Hide();
            using (frmRanking ranking = new frmRanking())
            {
                ranking.ShowDialog();
            }
            Show();
        }

        private void btnGuide_Click(object sender, EventArgs e)
        {
            string gameInstructions =
            "\t\tCÁCH CHƠI:\n" +
            "1. Một hình ảnh câu hỏi sẽ xuất hiện ở giữa giao diện.\n" +
            "2. Nhấn vào các chữ cái bên dưới để điền đáp án vào các\n ô trống.\n" +
            "3. Nếu cần, nhấn vào nút bóng đèn để xem gợi ý \n(giảm điểm khi sử dụng).\n" +
            "4. Sau khi điền đủ đáp án, hệ thống sẽ tự động\n kiểm tra đúng/sai.\n" +
            "5. Nếu sai, bạn có thể sửa hoặc trả lời lại. \nNếu đúng, sẽ chuyển sang câu hỏi tiếp theo.\n\n" +

            "\t\tQUY CÁCH TÍNH ĐIỂM:\n" +
            "- Thời gian trả lời ảnh hưởng đến số điểm đạt được:\n" +
            "  + 30 giây đầu tiên: 100 điểm.\n" +
            "  + 30 giây tiếp theo: 90 điểm.\n" +
            "  + 30 giây tiếp theo: 75 điểm.\n" +
            "  + 30 giây tiếp theo: 50 điểm.\n" +
            "  + 60 giây tiếp theo: 35 điểm.\n" +
            "  + Thời gian còn lại: 20 điểm.\n" +
            "- Sử dụng gợi ý sẽ chỉ được 15 điểm.\n\n" +

            "\tNGUYÊN LÝ HOẠT ĐỘNG BẢNG XẾP HẠNG:\n" +
            "- Bảng xếp hạng hiển thị danh sách người chơi theo thứ tự \nđiểm số cao nhất.\n" +
            "- Trường hợp người chơi có cùng điểm:\n" +
            "  + Xếp hạng dựa vào tổng thời gian trả lời ít hơn.\n" +
            "- Thông tin hiển thị:\n" +
            "  + Thứ hạng, tên người chơi, tổng điểm và tổng thời gian.\n";

            MessageBox.Show(gameInstructions, "Hướng dẫn chơi", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void frmHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn thoát khỏi game?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
