using Dumplings.Api;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dumplings.Core.Sprites
{
    public class DumplingSprite
    {
        private Dumpling _dumpling;

        private Texture2D _texture;

        public DumplingSprite(DumplingType d) {
            _dumpling = new Dumpling(d);
            _texture = DumplingsGame.GetInstance().Content.Load<Texture2D>($"dumplings\\dumpling-{d.ToString()}");
        }

        public Dumpling Dumpling => _dumpling;

        public Texture2D Texture => _texture;
    }
}
