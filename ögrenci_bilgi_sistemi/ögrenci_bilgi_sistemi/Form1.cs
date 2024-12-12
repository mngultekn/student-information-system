using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ögrenci_bilgi_sistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ogrenciDersYonetimiDataSet.OgrenciDers' table. You can move, or remove it, as needed.
            this.ogrenciDersTableAdapter.Connection.Open();

            // TODO: This line of code loads data into the 'ogrenciDersYonetimiDataSet.Ogrenci' table. You can move, or remove it, as needed.
            this.ogrenciTableAdapter.Fill(this.ogrenciDersYonetimiDataSet.Ogrenci);
            // TODO: This line of code loads data into the 'ogrenciDersYonetimiDataSet.Ders' table. You can move, or remove it, as needed.
            this.dersTableAdapter.Fill(this.ogrenciDersYonetimiDataSet.Ders);

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

            // Veritabanı bağlantı dizesini güncelle
            string connectionString = "Data Source=DESKTOP-7EPCTQ4;Initial Catalog=OgrenciDersYonetimi;Integrated Security=True;Trust Server Certificate=True;";

            // Öğrenci eklemek için SQL sorgusu
            string query = "INSERT INTO Ogrenci (Ad, Soyad, GANO) VALUES (@Ad, @Soyad, @GANO)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SQL komutunu oluştur
                SqlCommand command = new SqlCommand(query, connection);

                // Parametreleri ekle
                command.Parameters.AddWithValue("@Ad", textBoxName.Text);  // Öğrenci adı TextBox'ı
                command.Parameters.AddWithValue("@Soyad", textBoxLastName.Text);    // Soyadı TextBox'ı
                command.Parameters.AddWithValue("@GANO", string.IsNullOrEmpty(textBoxBirthGano.Text) ? (object)DBNull.Value : Convert.ToDouble(textBoxBirthGano.Text)); // GANO TextBox'ı

                try
                {
                    // Bağlantıyı aç ve komutu çalıştır
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Öğrenci başarıyla eklendi.");
                }
                catch (Exception ex)
                {
                    // Hata mesajı göster
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            
            
                // Veritabanı bağlantı dizesini güncelle
                string connectionString = "Data Source=DESKTOP-7EPCTQ4;Initial Catalog=OgrenciDersYonetimi;Integrated Security=True;Trust Server Certificate=True;";

                // Öğrenci güncellemek için SQL sorgusu
                string query = "UPDATE Ogrenci SET Ad = @Ad, Soyad = @Soyad, GANO = @GANO WHERE OgrenciID = @OgrenciID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // SQL komutunu oluştur
                    SqlCommand command = new SqlCommand(query, connection);

                    // Parametreleri ekle
                    command.Parameters.AddWithValue("@Ad", textBoxName.Text);  // Öğrenci adı TextBox'ı
                    command.Parameters.AddWithValue("@Soyad", textBoxLastName.Text);    // Soyadı TextBox'ı
                    command.Parameters.AddWithValue("@GANO", string.IsNullOrEmpty(textBoxBirthGano.Text) ? (object)DBNull.Value : Convert.ToDouble(textBoxBirthGano.Text)); // GANO TextBox'ı
                    command.Parameters.AddWithValue("@OgrenciID", textBoxOgrenciId.Text); // Öğrenci ID'si

                    try
                    {
                        // Bağlantıyı aç ve komutu çalıştır
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Öğrenci başarıyla güncellendi.");
                    }
                    catch (Exception ex)
                    {
                        // Hata mesajı göster
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                }
            

        }

        private void buttonOgrenciSil_Click(object sender, EventArgs e)
        {
           
                // Veritabanı bağlantı dizesini güncelle
                string connectionString = "Data Source=DESKTOP-7EPCTQ4;Initial Catalog=OgrenciDersYonetimi;Integrated Security=True;Trust Server Certificate=True;";

                // Öğrenciyi silmek için SQL sorgusu
                string query = "DELETE FROM Ogrenci WHERE OgrenciID = @OgrenciID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // SQL komutunu oluştur
                    SqlCommand command = new SqlCommand(query, connection);

                    // Parametreyi ekle
                    command.Parameters.AddWithValue("@OgrenciID", textBoxOgrenciId.Text); // Öğrenci ID'si

                    try
                    {
                        // Bağlantıyı aç ve komutu çalıştır
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Öğrenci başarıyla silindi.");
                    }
                    catch (Exception ex)
                    {
                        // Hata mesajı göster
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
         
                // Veritabanı bağlantı dizesini güncelle
                string connectionString = "Data Source=DESKTOP-7EPCTQ4;Initial Catalog=OgrenciDersYonetimi;Integrated Security=True;Trust Server Certificate=True;";

                // Ders eklemek için SQL sorgusu
                string query = "INSERT INTO Ders (DersAd, DersKod, DersKredi, Kontenjan) VALUES (@DersAd, @DersKod, @DersKredi, @Kontenjan)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // SQL komutunu oluştur
                    SqlCommand command = new SqlCommand(query, connection);

                    // Parametreleri ekle
                    command.Parameters.AddWithValue("@DersAd", textBoxDersAdı.Text);  // Ders adı TextBox'ı
                    command.Parameters.AddWithValue("@DersKod", textBoxDersAdı.Text);  // Ders kodu TextBox'ı
                    command.Parameters.AddWithValue("@DersKredi", Convert.ToInt32(textBoxKredi.Text));  // Ders kredi TextBox'ı
                    command.Parameters.AddWithValue("@Kontenjan", Convert.ToInt32(textBoxKontenjan.Text));  // Kontenjan TextBox'ı

                    try
                    {
                        // Bağlantıyı aç ve komutu çalıştır
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Ders başarıyla eklendi.");
                    }
                    catch (Exception ex)
                    {
                        // Hata mesajı göster
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {


            // Veritabanı bağlantı dizesi
            string connectionString = "Data Source=DESKTOP-7EPCTQ4;Initial Catalog=OgrenciDersYonetimi;Integrated Security=True;Trust Server Certificate=True;";

            // Ders güncellemek için SQL sorgusu (ÖğretmenID dahil edildi)
            string query = "UPDATE Ders SET DersAd = @DersAd, DersKod = @DersKod, DersKredi = @DersKredi, Kontenjan = @Kontenjan, OgretmenID = @OgretmenID WHERE DersID = @DersID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SQL komutunu oluştur
                SqlCommand command = new SqlCommand(query, connection);

                // Parametreleri ekle
                command.Parameters.AddWithValue("@DersAd", textBoxDersAdı.Text);  // Ders adı
                command.Parameters.AddWithValue("@DersKod", textBoxDersKodu.Text);  // Ders kodu
                command.Parameters.AddWithValue("@DersKredi", Convert.ToInt32(textBoxKredi.Text));  // Ders kredi
                command.Parameters.AddWithValue("@Kontenjan", Convert.ToInt32(textBoxKontenjan.Text));  // Kontenjan
                command.Parameters.AddWithValue("@OgretmenID", Convert.ToInt32(textBoxOgretmenId.Text)); // Öğretmen ID
                command.Parameters.AddWithValue("@DersID", Convert.ToInt32(textBoxDersId.Text)); // Ders ID

                try
                {
                    // Bağlantıyı aç ve komutu çalıştır
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Ders başarıyla güncellendi.");
                }
                catch (Exception ex)
                {
                    // Hata mesajı göster
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Veritabanı bağlantı dizesi
            string connectionString = "Data Source=DESKTOP-7EPCTQ4;Initial Catalog=OgrenciDersYonetimi;Integrated Security=True;Trust Server Certificate=True;";

            // Ders silmek için SQL sorgusu (ÖğretmenID kontrolü eklenirse)
            string query = "DELETE FROM Ders WHERE DersID = @DersID AND OgretmenID = @OgretmenID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SQL komutunu oluştur
                SqlCommand command = new SqlCommand(query, connection);

                // Parametreleri ekle
                command.Parameters.AddWithValue("@DersID", Convert.ToInt32(textBoxDersId.Text)); // Ders ID
                command.Parameters.AddWithValue("@OgretmenID", Convert.ToInt32(textBoxOgretmenId.Text)); // Öğretmen ID

                try
                {
                    // Bağlantıyı aç ve komutu çalıştır
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Ders başarıyla silindi.");
                }
                catch (Exception ex)
                {
                    // Hata mesajı göster
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {

            // Veritabanı bağlantı dizesi
            string connectionString = "Data Source=DESKTOP-7EPCTQ4;Initial Catalog=OgrenciDersYonetimi;Integrated Security=True;Trust Server Certificate=True;";

            // ÖğretmenID'ye göre dersleri seçmek için SQL sorgusu
            string query = "SELECT OgrenciID, Ad, Soyad, GANO FROM Ogrenci WHERE OgretmenID = @OgretmenID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SQL komutunu oluştur
                SqlCommand command = new SqlCommand(query, connection);

                // Parametreyi ekle
                command.Parameters.AddWithValue("@OgretmenID", Convert.ToInt32(textBoxOgretmenId.Text)); // Öğretmen ID

                try
                {
                    // Bağlantıyı aç ve komutu çalıştır
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);

                    // Veriyi DataGridView'a yükle
                    dataGridView2.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    // Hata mesajı göster
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }


        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
           
                // Veritabanı bağlantı dizesi
                string connectionString = "Data Source=DESKTOP-7EPCTQ4;Initial Catalog=OgrenciDersYonetimi;Integrated Security=True;Trust Server Certificate=True;";

                // Öğrencileri listelemek için SQL sorgusu
                string query = "SELECT OgrenciID, OgrenciAd, OgrenciSoyad, DersAd, Durum FROM OgrenciDersTablosu WHERE OgretmenID = @OgretmenID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // SQL komutunu oluştur
                    SqlCommand command = new SqlCommand(query, connection);

                    // Parametreyi ekle
                    command.Parameters.AddWithValue("@OgretmenID", Convert.ToInt32(textBoxOgretmenId.Text)); // Öğretmen ID

                    try
                    {
                        // Bağlantıyı aç ve komutu çalıştır
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);

                        // Veriyi DataGridView'a yükle
                        dataGridView1.DataSource = dataTable;
                    }
                    catch (Exception ex)
                    {
                        // Hata mesajı göster
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                }
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
                // Seçilen öğrenci bilgilerini al
                int ogrenciId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["OgrenciID"].Value);
                string dersAd = dataGridView1.SelectedRows[0].Cells["DersAd"].Value.ToString();

                // Veritabanı bağlantı dizesi
                string connectionString = "Data Source=DESKTOP-7EPCTQ4;Initial Catalog=OgrenciDersYonetimi;Integrated Security=True;Trust Server Certificate=True;";

                // Öğrenci durumu onaylamak için SQL sorgusu
                string query = "UPDATE OgrenciDersTablosu SET Durum = 'Onay' WHERE OgrenciID = @OgrenciID AND DersAd = @DersAd AND OgretmenID = @OgretmenID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // SQL komutunu oluştur
                    SqlCommand command = new SqlCommand(query, connection);

                    // Parametreleri ekle
                    command.Parameters.AddWithValue("@OgrenciID", ogrenciId);
                    command.Parameters.AddWithValue("@DersAd", dersAd);
                    command.Parameters.AddWithValue("@OgretmenID", Convert.ToInt32(textBoxOgretmenId.Text)); // Öğretmen ID

                    try
                    {
                        // Bağlantıyı aç ve komutu çalıştır
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Öğrenci dersi başarıyla onaylandı.");
                    }
                    catch (Exception ex)
                    {
                        // Hata mesajı göster
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                }
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
                // Seçilen öğrenci bilgilerini al
                int ogrenciId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["OgrenciID"].Value);
                string dersAd = dataGridView1.SelectedRows[0].Cells["DersAd"].Value.ToString();

                // Veritabanı bağlantı dizesi
                string connectionString = "Data Source=DESKTOP-7EPCTQ4;Initial Catalog=OgrenciDersYonetimi;Integrated Security=True;Trust Server Certificate=True;";

                // Öğrenci durumu reddetmek için SQL sorgusu
                string query = "UPDATE OgrenciDersTablosu SET Durum = 'Red' WHERE OgrenciID = @OgrenciID AND DersAd = @DersAd AND OgretmenID = @OgretmenID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // SQL komutunu oluştur
                    SqlCommand command = new SqlCommand(query, connection);

                    // Parametreleri ekle
                    command.Parameters.AddWithValue("@OgrenciID", ogrenciId);
                    command.Parameters.AddWithValue("@DersAd", dersAd);
                    command.Parameters.AddWithValue("@OgretmenID", Convert.ToInt32(textBoxOgretmenId.Text)); // Öğretmen ID

                    try
                    {
                        // Bağlantıyı aç ve komutu çalıştır
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Öğrenci dersi başarıyla reddedildi.");
                    }
                    catch (Exception ex)
                    {
                        // Hata mesajı göster
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                }
            

        }
    }
    }

