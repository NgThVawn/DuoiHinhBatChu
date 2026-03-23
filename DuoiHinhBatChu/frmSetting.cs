using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuoiHinhBatChu
{
    public partial class frmSetting : Form
    {

        private frmHome homeForm;
        private frmGamePlay frmGamePlay;
        public frmSetting(frmHome form, int volume, int soundVolume)
        {
            InitializeComponent();
            homeForm = form;
            tbVolume.Value = volume;
            tbSoundVolume.Value = soundVolume;
        }
        public frmSetting(frmGamePlay form,int volume, int soundVolume)
        {
            InitializeComponent();
            frmGamePlay = form;
            btnContinue.Visible = true;
            tbVolume.Value = volume;
            tbSoundVolume.Value = soundVolume;
        }
        private void tbVolume_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                homeForm?.SetVolume(tbVolume.Value);
                frmGamePlay?.SetVolume(tbVolume.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        public void btnExit_Click(object sender, EventArgs e)
        {
            if (frmGamePlay != null && !frmGamePlay.IsDisposed)
            {
                frmGamePlay.SaveBeforeExit();
                frmGamePlay.Close();
                Close();
            }
            else
            {
                homeForm.Close();
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbSoundVolume_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {

                frmGamePlay?.SetSoundVolume(tbSoundVolume.Value);
                if (homeForm != null)
                {
                    homeForm.soundVolume = tbSoundVolume.Value;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
