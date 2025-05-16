// See https://aka.ms/new-console-template for more information
using Storage;
using static System.Runtime.InteropServices.JavaScript.JSType;

Pallet[] palletArray = new Pallet[10];
PalletGeneration(ref palletArray, 10);

Array.Sort(palletArray, new PalletComparerBestBeforeDate());
Console.WriteLine("First group:" + Environment.NewLine);
DisplayFirst();
Console.WriteLine(Environment.NewLine + "////////////////////////////" + Environment.NewLine);
Console.WriteLine("Second group:" + Environment.NewLine);
Array.Sort(palletArray, new PalletComparerBestBeforeDateMaxInBox());
int numPalletsDisplay = 3;
int numBestBeforeDateMaxInBox = NumBestBeforeDateMaxInBox();
Array.Sort(palletArray, palletArray.Length - numBestBeforeDateMaxInBox, numBestBeforeDateMaxInBox, new PalletComparerVolume());
DisplaySecond(Math.Min(palletArray.Length, numPalletsDisplay));


void PalletGeneration(ref Pallet[] palletArray, int maxNumBoxes)
{
    Random rnd = new();
    int boxID = 1;
    for (int i = 0; i < palletArray.Length; i++)
    {
        palletArray[i] = new Pallet();
        palletArray[i].ID = i + 1;
        palletArray[i].Width = rnd.Next(1, 10);
        palletArray[i].Height = rnd.Next(1, 10);
        palletArray[i].Depth = rnd.Next(1, 10);
        palletArray[i].Weight = 30;
        palletArray[i].BestBeforeDate = DateOnly.FromDateTime(DateTime.MaxValue);

        if (maxNumBoxes < 0) { maxNumBoxes = 0; }
        int boxNum = rnd.Next(0, maxNumBoxes + 1);
        for (int j = 0; j < boxNum; j++)
        {
            palletArray[i].Boxes.Add(BoxGeneration(boxID, palletArray[i].Width, palletArray[i].Depth));
            if (palletArray[i].Boxes[j].BestBeforeDate < palletArray[i].BestBeforeDate)
                palletArray[i].BestBeforeDate = palletArray[i].Boxes[j].BestBeforeDate;
            palletArray[i].Weight += palletArray[i].Boxes[j].Weight;
            boxID++;
        }
    }
}
Box BoxGeneration(int boxID, double palletWidth, double palletDepth)
{
    Random rnd = new();
    Box box = new Box();
    box.ID = boxID;
    box.Width = rnd.Next(1, (int)palletWidth + 1);
    box.Height = rnd.Next(1, 10);
    box.Depth = rnd.Next(1, (int)palletDepth + 1);
    box.Weight = rnd.Next(1, 10);
    box.BestBeforeDate = DateOnly.FromDateTime(DateTime.Now.AddDays(rnd.Next(0, 5)));
    box.BestBeforeDateReally = Convert.ToBoolean(rnd.Next(0, 2));
    return box;
}

void DisplayFirst()
{
    for (int i = 0; i < palletArray.Length; i++)
    {
        if (i != 0 && palletArray[i].BestBeforeDate != palletArray[i - 1].BestBeforeDate) Console.WriteLine();
        Console.WriteLine(palletArray[i].ToString());
    }
}
void DisplaySecond(int numStartDisplay)
{
    for (int i = palletArray.Length - numStartDisplay; i < palletArray.Length; i++)
    {
        Console.WriteLine(palletArray[i].ToString());
    }
}

int NumBestBeforeDateMaxInBox()
{
    int numBestBeforeDateMaxInBox = numPalletsDisplay;
    if (numBestBeforeDateMaxInBox >= palletArray.Length) return palletArray.Length;
    else
    {
        for (int i = palletArray.Length - numBestBeforeDateMaxInBox - 1; i >= 0; i--)
        {
            if (palletArray[i].GetMaxDateInBox() == palletArray[i + 1].GetMaxDateInBox())
            {
                numBestBeforeDateMaxInBox++;
            }
            else break;
        }
        return numBestBeforeDateMaxInBox;
    }
}