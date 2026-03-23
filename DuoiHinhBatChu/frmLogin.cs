using System;
using System.Linq;
using System.Windows.Forms;
using DuoiHinhBatChu.BLL;
using DuoiHinhBatChu.DAL.Entites;

namespace DuoiHinhBatChu
{
    public partial class frmLogin : Form
    {

        private readonly PlayerService playerService = new PlayerService();
        private readonly QuestionService questionService = new QuestionService();
        private frmHome homeForm;
        public frmLogin(frmHome home)
        {
            InitializeComponent();
            homeForm = home;
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
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtPlayerName.Text))
                {
                    MessageBox.Show("Hãy điền tên người chơi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var playerList = playerService.GetAll();
                Player player = new Player();
                if (playerList.Any(p => p.PlayerName == txtPlayerName.Text))
                {
                    var result = MessageBox.Show("Tên người chơi đã tồn tại, bạn có muốn tiếp tục chuyến hành trình dang dở?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        return;
                    }
                    player = playerList.First(p => p.PlayerName == txtPlayerName.Text);
                }
                else
                {
                    player.PlayerName = txtPlayerName.Text;
                    player.HintCount = 1;
                    playerService.AddOrUpdate(player);
                }
                if (questionService.CheckCompleted(player.PlayerID))
                {
                    MessageBox.Show("Bạn đã hoàn thành tất cả câu hỏi!", "Chúc mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    return;
                }
                homeForm.playerID = playerService.GetByName(txtPlayerName.Text).PlayerID;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
