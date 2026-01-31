using System;
using System.Media;
using System.Drawing;
using System.Windows.Forms;

internal class Form1 : Form
{
    public SoundPlayer player = new SoundPlayer(HeyImMagnusCarlsen.Properties.Resources.magnus_carlsen_chess_com_coach);
    public Form1() => InitializeComponent();

    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.BackgroundImage = global::HeyImMagnusCarlsen.Properties.Resources.hqdefault__2_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(504, 292);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Hey im Magnus Carlsen, i wanna coach u through your chess journey";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

    }
    

    private void Form1_Load(object sender, EventArgs e)
    {
        Random r = new Random();
        player.Play();
        this.Location = new Point(r.Next(0, Screen.PrimaryScreen.Bounds.Width - this.Width), r.Next(0, Screen.PrimaryScreen.Bounds.Height - this.Height));
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        this.Show();
    }
}
