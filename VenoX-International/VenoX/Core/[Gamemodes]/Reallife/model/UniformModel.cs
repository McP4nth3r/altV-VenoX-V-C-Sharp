namespace VenoX.Core._Gamemodes_.Reallife.model
{
    public class UniformModel
    {
        public int Type { get; set; }
        public int FactionJob { get; set; }
        public int CharacterSex { get; set; }
        public int UniformSlot { get; set; }
        public int UniformDrawable { get; set; }
        public int UniformTexture { get; set; }

        public UniformModel(int type, int factionJob, int characterSex, int uniformSlot, int uniformDrawable, int uniformTexture)
        {
            this.Type = type;
            this.FactionJob = factionJob;
            this.CharacterSex = characterSex;
            this.UniformSlot = uniformSlot;
            this.UniformDrawable = uniformDrawable;
            this.UniformTexture = uniformTexture;
        }
    }
}
