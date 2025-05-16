using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Storage
{
    internal class Pallet : StorageObject
    {
        public List<Box> Boxes = new List<Box>();
        public double Volume { get; set; }

        public double PalletGetVolune()
        {
            double palletVolume = Width * Height * Depth;
            for (int j = 0; j < Boxes.Count; j++)
            {
                palletVolume+=Boxes[j].Width * Boxes[j].Height * Boxes[j].Depth;
            }
            Volume = palletVolume;
            return palletVolume; 
        }
        public DateOnly GetMaxDateInBox()
        {
            DateOnly dateOnly = DateOnly.FromDateTime(DateTime.MinValue);
            for (int j = 0; j < Boxes.Count; j++)
            {
                if (Boxes[j].BestBeforeDate> dateOnly)
                dateOnly=Boxes[j].BestBeforeDate;
            }

            return dateOnly;       
        }
        public override string ToString()
        {
            string str = $"PalletID: {ID}  Width: {Width} Height: {Height} Depth: {Depth} Weight: {Weight}  BestBeforeDate: {BestBeforeDate}  Volume: {Volume}";
            for (int j = 0; j < Boxes.Count; j++)
            {
                str += Environment.NewLine + '\t' + $"BoxID: {Boxes[j].ID} Width: {Boxes[j].Width} Height: {Boxes[j].Height} Depth: {Boxes[j].Depth} Weight: {Boxes[j].Weight}  BestBeforeDate: {Boxes[j].BestBeforeDate}";
            }
            return str;
        }
    }
}
