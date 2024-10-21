﻿namespace GalacticTitans.Models.Titans
{
    public class TitanImageViewModel
    {
        public Guid ImageID { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public string Image { get; set; }
        public Guid? TitanID { get; set; }
    }
}
