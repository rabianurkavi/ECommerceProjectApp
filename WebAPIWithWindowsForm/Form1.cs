using Entities.Dtos.UserDtos;
using System.Net.Http.Json;

namespace WebAPIWithWindowsForm
{
    public partial class frmKullanici : Form
    {
        string url = "http://localhost:5065/api/User/GetList";
        public frmKullanici()
        {
            InitializeComponent();
        }

        private async void frmKullanici_Load(object sender, EventArgs e)
        {
            using (HttpClient httpClient= new HttpClient() )
            {
                var users= await httpClient.GetFromJsonAsync<List<UserDetailDto>>(new Uri(url));
                dataGridView1.DataSource = users;
            }

        }
    }
}
