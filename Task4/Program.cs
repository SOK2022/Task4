string path1 = "C:\\Users\\ПК\\Desktop";
string path2 = path1 + "/Students";
Directory.CreateDirectory(path2);

using (BinaryReader br = new BinaryReader(File.Open(path1 + "/students.dat", FileMode.Open)))
{
    while (br.PeekChar() > -1)
    {
        string Name = br.ReadString();
        string Group = br.ReadString();
        DateTime DateOfBirth = DateTime.FromBinary(br.ReadInt64());
        decimal MiddleGrade = br.ReadDecimal();

        string path3 = path2 + "/" + Group + ".txt";
        FileInfo fileInfo = new FileInfo(path3);

        if (!File.Exists(path3))
        {
            using (StreamWriter sw = fileInfo.CreateText())
            {
                sw.WriteLine(Name + " " + DateOfBirth + " " + MiddleGrade);
            }
        }
        else
        {
            using (StreamWriter sw = fileInfo.AppendText())
            {
                sw.Write(Name + " " + DateOfBirth + " " + MiddleGrade);
            }
        }
    }

}