using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
