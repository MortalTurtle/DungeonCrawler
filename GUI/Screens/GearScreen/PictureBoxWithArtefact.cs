using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class PictureBoxWithArtefact : PictureBox
    {
        private IArtefact artefact;
        public IArtefact Artefact
        {
            get => artefact;
            set
            {
                if (value == null)
                    return;
                this.ImageLocation = value.PicturePath;
                artefact = value;
            }
        }

        public PictureBoxWithArtefact(IArtefact artefact)
        {
            Artefact = artefact;
        }
    }
}
