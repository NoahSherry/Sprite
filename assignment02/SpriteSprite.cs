using System.Drawing;

namespace assignment02
{
    public class SpriteSprite : Sprite
    {

        private Bitmap image;
        public Bitmap Image
        {
            get { return image; }
            set { image = value;}
        }

        public override void Act()
        {
            base.Act();
			Rotation++;
        }

        public override void Paint(Graphics g)
        {
            g.DrawImage(image, 0, 0);
        }
    }
}
