using System;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Windows.Forms;

namespace assignment02
{
    public partial class Form1 : Form
    {
		SoundPlayer player = new SoundPlayer(Properties.Resources.wave);
		public static SpriteSprite Sprite = new SpriteSprite();
		public static Form form;
		public static Thread thread;
		public static Graphics norm;
		public static int fps = 30;
		public static double running_fps = 30.0;

		public Form1()
        {
            InitializeComponent();
			DoubleBuffered = true;
			form = this;
			Sprite.Image = assignment02.Properties.Resources.sprite;
			Sprite.X = (Sprite.Image.Width / 2) + 50;
			Sprite.Y = (Sprite.Image.Height / 2) + 50;
			player.PlayLooping();
			thread = new Thread(new ThreadStart(Update));
			thread.Start();
        }

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);
			thread.Abort();
		}

		public static void Update()
		{
			DateTime last = DateTime.Now;
			DateTime now = last;
			TimeSpan frameTime = new TimeSpan(10000000 / fps);
			while (true)
			{
				DateTime temp = DateTime.Now;
				running_fps = .9 * running_fps + .1 * 1000.0 / (temp - now).TotalMilliseconds;
				Console.WriteLine(running_fps);
				now = temp;
				TimeSpan diff = now - last;
				if (diff.TotalMilliseconds < frameTime.TotalMilliseconds)
					Thread.Sleep((frameTime - diff).Milliseconds);
				last = DateTime.Now;
				form.Invoke(new MethodInvoker(form.Refresh));
			}
		}

		protected override void OnPaint(PaintEventArgs e)
        {
			Sprite.Act();
			Sprite.Render(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
