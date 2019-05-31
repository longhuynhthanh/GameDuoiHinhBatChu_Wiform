using System;
using System.Drawing;
using System.Windows.Forms;

namespace Version1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] ListHinhAnh;
        int index;
        string[] DapAn = {
                             "BAOLA",
                             "KINHDO",
                             "HUNGTHU",
                             "TINHTRUONG",
                             "BAOQUAT",
                             "CAUMAY",
                             "NHACCU",
                             "TRANHTHU",
                             "NOITHAT",
                             "DAUTHU",
                             "NOIDAN",
                             "NEMDADAUTAY",
                             "GAUNGUA",
                             "LANGTHANG",
                             "CHIDIEM",
                             "CONGTRAI",
                             "BADONG",
                             "THANKHOC",
                             "AIMO",
                             "THONGTAN",
                             "BAOTU",
                             "MUINHON",
                             "LUCLAC",
                             "THOO",
                             "NHAHAT",
                             "AOMUA",
                             "BAOTHUC",
                             "XEMTUONG",
                             "COLOA",
                             "BONGDA",
                             "HONGTAM",
                             "DAITUONG",
                             "BACTINH",
                             "HAILONG",
                             "BIOI",
                             "BADAUSAUTAY",
                             "XICHLO",
                             "NGANGU",
                             "BINHHOADIDONG",
                             "DONGCAMCONGKHO"
                         };
        int[] ListIndexDaXem;
        int IndexDaXem;
        TextBox[] ListDapAn;
        Button[] ListGoiYDapAn;
        char[] DanhSachCacKyTuDapAn;
        Random rd = new Random();

        private void Form1_Load(object sender, EventArgs e)
        {
            ListHinhAnh = new string[40];
            ListIndexDaXem = new int[ListHinhAnh.Length];
            for (int i = 1; i <= ListHinhAnh.Length; i++)
            {
                ListHinhAnh[i - 1] = "Anh/" + i + ".jpg";
            }
            index = rd.Next(0, ListHinhAnh.Length);
            ptrAnh.Image = Image.FromFile(ListHinhAnh[index]);
            ptrAnh.SizeMode = PictureBoxSizeMode.StretchImage;
            IndexDaXem = 0;
            ListIndexDaXem[IndexDaXem] = index;

            // Hiển thị các ô TexBox theo Đáp án.
            HienThiTexBox();


            // HIển thị các nút nhận Button theo gợi ý đáp án
            HienThiButton();

            // Hiện các chữ cái lên danh sách các button theo quy tắc trộn lẫn.
            HienThiCacKyTuDapAn();
            btnCauTiepTheo.Visible = false;
        }
        private void HienThiCacKyTuDapAn()
        {
            DanhSachCacKyTuDapAn = new char[ListGoiYDapAn.Length];

            // 50% là các ký tự của đáp án
            for (int i = 0; i < ListGoiYDapAn.Length / 2; ++i)
            {
                DanhSachCacKyTuDapAn[i] = DapAn[index][i];
            }

            // 50% còn lại thì random các ký tự ngẫu nhiên
            for (int i = ListGoiYDapAn.Length / 2; i < ListGoiYDapAn.Length; ++i)
            {
                DanhSachCacKyTuDapAn[i] = (char)rd.Next(65, 91);
            }

            // Hiển thị ngẫu nhiên các ký tự trong ListDanhSachKyTuDapAn lên Buttton.
            int NgauNhien;
            int[] indexbitrung = new int[ListGoiYDapAn.Length];
            int soluong = 0;
            bool check;
            for (int i = 0; i < ListGoiYDapAn.Length; ++i)
            {
            LongHandSome:
                check = true;
                NgauNhien = rd.Next(0, ListGoiYDapAn.Length);
                for (int j = 0; j < soluong; ++j)
                {
                    if (NgauNhien == indexbitrung[j])
                    {
                        check = false;
                        break;
                    }
                }
                if (check == true)
                {
                    ListGoiYDapAn[i].Text = DanhSachCacKyTuDapAn[NgauNhien].ToString();
                    indexbitrung[soluong++] = NgauNhien;
                }
                else
                {
                    goto LongHandSome;
                }
            }
        }
        private void HienThiButton()
        {
            int SoLuongGoiY = DapAn[index].Length * 2;
            ListGoiYDapAn = new Button[SoLuongGoiY];
            ListGoiYDapAn[0] = new Button();
            ListGoiYDapAn[0].Click += Form1_Click;
            ListGoiYDapAn[1] = new Button();
            ListGoiYDapAn[1].Click += Form1_Click;
            ListGoiYDapAn[0].Location = new Point(ptrAnh.Location.X + ptrAnh.Size.Width + 30, ptrAnh.Location.Y);
            ListGoiYDapAn[0].Size = new Size(30, 30);
            ListGoiYDapAn[0].Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ListGoiYDapAn[0].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            ListGoiYDapAn[0].ForeColor = System.Drawing.Color.Red;
            this.Controls.Add(ListGoiYDapAn[0]);
            ListGoiYDapAn[1].Location = new Point(ListGoiYDapAn[0].Location.X + ListGoiYDapAn[0].Size.Width + 10, ptrAnh.Location.Y);
            ListGoiYDapAn[1].Size = new Size(30, 30);
            ListGoiYDapAn[1].Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ListGoiYDapAn[1].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            ListGoiYDapAn[1].ForeColor = System.Drawing.Color.Red;
            this.Controls.Add(ListGoiYDapAn[1]);

            for (int i = 2; i < SoLuongGoiY; ++i)
            {
                ListGoiYDapAn[i] = new Button();
                ListGoiYDapAn[i].Click += Form1_Click;
                ListGoiYDapAn[i].Location = new Point(ListGoiYDapAn[i - 2].Location.X, ListGoiYDapAn[i - 2].Location.Y + ListGoiYDapAn[i - 2].Size.Height + 20);
                ListGoiYDapAn[i].Size = new Size(30, 30);
                ListGoiYDapAn[i].Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                ListGoiYDapAn[i].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
                ListGoiYDapAn[i].ForeColor = System.Drawing.Color.Red;
                this.Controls.Add(ListGoiYDapAn[i]);
            }
        }
        private void Form1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(((Button)sender).Text);
            if (sender is Button)
            {
                for (int i = 0; i < ListDapAn.Length; ++i)
                {
                    if (ListDapAn[i].Text == "")
                    { 
                        ListDapAn[i].Text = ((Button)sender).Text;
                        ((Button)sender).Visible = false;
                        break;
                    }
                }
                //Kiểm tra xem các ô texbox đã được lấp đầy hay chưa rồi kiểm tra đúng hay sai đáp án
                bool check = false;
                foreach (TextBox txt in ListDapAn)
                {
                    if (txt.Text == "")
                    {
                        check = true;
                        break;
                    }
                }
                if (check == false)
                {
                    // Tất cả các ô textbox đã được điền đầy đủ
                    string s = "";
                    for (int i = 0; i < ListDapAn.Length; ++i)
                    {
                        s += ListDapAn[i].Text;
                    }
                    if (s == DapAn[index])
                    {
                        MessageBox.Show("Bạn trả lời đúng rồi");
                        btnCauTiepTheo.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("sai cmmr rồi");
                    }
                }
                else
                {
                    btnCauTiepTheo.Visible = false;
                }
            }
            else if (sender is TextBox)
            {
                for (int i = 0; i < ListGoiYDapAn.Length; ++i)
                {
                    if (ListGoiYDapAn[i].Visible == false && ((TextBox)sender).Text == ListGoiYDapAn[i].Text)
                    {
                        ((TextBox)sender).Text = "";
                        ListGoiYDapAn[i].Visible = true;
                    }
                }
            }
        }

        private void HienThiTexBox()
        {
            int SoLuongTexBox = DapAn[index].Length;
            ListDapAn = new TextBox[SoLuongTexBox];
            ListDapAn[0] = new TextBox();
            ListDapAn[0].Click += Form1_Click;
            ListDapAn[0].Location = new Point(ptrAnh.Location.X, ptrAnh.Location.Y + ptrAnh.Size.Height + 30);
            ListDapAn[0].Size = new Size(30, 30);
            ListDapAn[0].Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ListDapAn[0].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            ListDapAn[0].ForeColor = System.Drawing.Color.Red;
            this.Controls.Add(ListDapAn[0]);

            for (int i = 1; i < SoLuongTexBox; i++)
            {
                ListDapAn[i] = new TextBox();
                ListDapAn[i].Click += Form1_Click;
                ListDapAn[i].Location = new Point(ListDapAn[i - 1].Location.X + ListDapAn[i - 1].Size.Width + 10, ListDapAn[0].Location.Y);
                this.Controls.Add(ListDapAn[i]);
                ListDapAn[i].Size = new Size(30, 30);
                ListDapAn[i].Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                ListDapAn[i].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
                ListDapAn[i].ForeColor = System.Drawing.Color.Red;
            }
        }

        bool check;
        private void btnCauTiepTheo_Click(object sender, EventArgs e)
        {
            btnCauTiepTheo.Visible = false;
        LongDepTrai:
            if (IndexDaXem == ListIndexDaXem.Length - 1)
            {
                MessageBox.Show("Đã hết câu hỏi, bạn có thể biến đi rồi");
                this.Close();
                return;
            }
            check = true;
            Random rd = new Random();
            index = rd.Next(0, ListHinhAnh.Length);
            for (int i = 0; i < ListIndexDaXem.Length; i++)
            {
                if (ListIndexDaXem[i] == index)
                {
                    check = false;
                    break;
                }
            }
            if (check == true)
            {
                ptrAnh.Image = Image.FromFile(ListHinhAnh[index]);
                ptrAnh.SizeMode = PictureBoxSizeMode.StretchImage;
                ListIndexDaXem[IndexDaXem++] = index;


                // Hiển thị các TexBox theo đáp án.
                // Xóa các TexBox trước đó
                foreach (TextBox c in ListDapAn)
                {
                    this.Controls.Remove(c);
                }
                HienThiTexBox();

                // Hiển thị các Button theo gợi ý đáp án.
                // Xóa các button trước đó
                foreach (Button b in ListGoiYDapAn)
                {
                    this.Controls.Remove(b);
                }
                HienThiButton();

                HienThiCacKyTuDapAn();
            }
            else
            {
                goto LongDepTrai;
            }
        }
    }
}
