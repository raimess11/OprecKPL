namespace OprecKPL
{
    public class Mahasiswa
    {
        string nama { set; get; }
        string nim { set; get; }
        int tahun { set; get; }
        public Mahasiswa()
        {
            this.nama = "";
            this.nim = "0";
            this.tahun = 2000;
        }
        public Mahasiswa(string nama, string nim, int tahun)
        {
            this.nama = nama;
            this.nim = nim;
            this.tahun = tahun;
        }
    }
}
