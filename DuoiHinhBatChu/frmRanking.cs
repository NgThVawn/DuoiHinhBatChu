using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DuoiHinhBatChu.BLL;
using DuoiHinhBatChu.DAL.Entites;

namespace DuoiHinhBatChu
{
    public partial class frmRanking : Form
    {
        private readonly PlayerService playerService = new PlayerService();
        private void BindGrid(List<Player> playerList)
        {
            dgvRanking.Rows.Clear();
            int i = 1;
            foreach (Player player in playerList)
            {
                int index = dgvRanking.Rows.Add();
                dgvRanking.Rows[index].Cells[0].Value = i++;
                dgvRanking.Rows[index].Cells[1].Value = player.PlayerName;
                dgvRanking.Rows[index].Cells[2].Value = player.TotalScore;
                dgvRanking.Rows[index].Cells[3].Value = player.TotalTime;
                if (index == 0) // Hàng đầu tiên
                {
                    dgvRanking.Rows[index].DefaultCellStyle.BackColor = Color.Gold; // Vàng
                }
                else if (index == 1) // Hàng thứ hai
                {
                    dgvRanking.Rows[index].DefaultCellStyle.BackColor = Color.Silver; // Bạc
                }
                else if (index == 2) // Hàng thứ ba
                {
                    dgvRanking.Rows[index].DefaultCellStyle.BackColor = Color.Peru; // Đồng
                }
            }
        }
        public frmRanking()
        {
            InitializeComponent();
        }

        private void frmRanking_Load(object sender, EventArgs e)
        {
            var playerList = playerService.GetAll();
            playerList = playerList.OrderByDescending(p => p.TotalScore).ThenBy(p => p.TotalTime).ToList();
            dgvRanking.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgvRanking.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            BindGrid(playerList);
            dgvRanking.ClearSelection();
        }

        private void dgvRanking_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int timeColumnIndex = 3;

            // Kiểm tra nếu cột đang được định dạng là cột TotalTime
            if (e.ColumnIndex == timeColumnIndex && e.Value != null)
            {
                // Lấy giá trị thời gian từ ô (số giây)
                if (int.TryParse(e.Value.ToString(), out int totalSeconds))
                {
                    // Chuyển đổi số giây thành MM:SS
                    TimeSpan timeSpan = TimeSpan.FromSeconds(totalSeconds);
                    e.Value = $"{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";

                    // Ngăn không cho DataGridView ghi đè định dạng
                    e.FormattingApplied = true;
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
