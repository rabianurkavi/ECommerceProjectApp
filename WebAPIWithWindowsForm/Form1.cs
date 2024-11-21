using Entities.Dtos.UserDtos;
using System.Net.Http.Json;

namespace WebAPIWithWindowsForm
{
    public partial class frmKullanici : Form
    {
        #region Defines
        string url = "http://localhost:5065/api/";
        private int selectedID = 0;
        #endregion
        #region frmKullanici
        public frmKullanici()
        {
            InitializeComponent();
        }
        private async void frmKullanici_Load(object sender, EventArgs e)
        {
            btnEkle.Enabled = true;
            btnD�zenle.Enabled = false;
            btnSil.Enabled = false;
            await DataGridViewFill();
        }
        #endregion
        #region Crud
        private async void btnEkle_Click(object sender, EventArgs e)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                UserAddDto userAddDto = new UserAddDto()
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    UserName = txtUserName.Text,
                    Email = txtEmail.Text,
                    Adress = txtAdress.Text,
                    Gender = comboBox1.Text == "Kad�n" ? true : false,
                    Password = txtPassword.Text,
                    DateOfBirth = dtpDateOfBirth.Value,

                };
                HttpResponseMessage response = await httpClient.PostAsJsonAsync(url + "User/Add", userAddDto);
                if (response.IsSuccessStatusCode)
                {

                    MessageBox.Show("Ba�ar�l� bir �ekilde eklendi.");
                    await DataGridViewFill();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Bir hata olu�tu.");
                }
            }
        }
        private async void btnD�zenle_Click(object sender, EventArgs e)
        {
            selectedID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            using (HttpClient httpClient = new HttpClient())
            {
                var user = await httpClient.GetFromJsonAsync<UserUpdateDto>(url + "User/GetById/" + selectedID);

                UserUpdateDto userUpdateDto = new UserUpdateDto()
                {
                    ID = selectedID,
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    UserName = txtUserName.Text,
                    Email = txtEmail.Text,
                    Adress = txtAdress.Text,
                    Gender = comboBox1.Text == "Kad�n" ? true : false,
                    Password = txtPassword.Text,
                    DateOfBirth = dtpDateOfBirth.Value,

                };
                HttpResponseMessage response = await httpClient.PutAsJsonAsync(url + "User/Update", userUpdateDto);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("D�zenleme i�lemi ba�ar�l�.");
                    await DataGridViewFill();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("D�zenleme i�lemi ba�ar�s�z.");
                }
            }

        }

        private async void btnSil_Click(object sender, EventArgs e)
        {
            selectedID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            using (HttpClient httpClient = new HttpClient())
            {
                var user = await httpClient.GetFromJsonAsync<UserUpdateDto>(url + "User/GetById/" + selectedID);

                HttpResponseMessage response = await httpClient.DeleteAsync($"{url}User/Delete/{selectedID}");
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Silme i�lemi ba�ar�l�.");
                    await DataGridViewFill();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Silme i�lemi ba�ar�s�z.");
                }
            }
        }
        #endregion
        #region Methods
        private async Task DataGridViewFill()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var users = await httpClient.GetFromJsonAsync<List<UserDetailDto>>(url + "User/GetList");
                dataGridView1.DataSource = users;
            }
        }
        void ClearForm()
        {
            txtAdress.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtUserName.Text = string.Empty;
            dtpDateOfBirth.Value = DateTime.Now;
            comboBox1.Text = "";


        }
        void UpdateForm(int id)
        {
            txtAdress.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtUserName.Text = string.Empty;
            dtpDateOfBirth.Value = DateTime.Now;
            comboBox1.Text = "";
            btnEkle.Enabled = true;
            btnD�zenle.Enabled = false;
            btnSil.Enabled = false;
        }
        private async void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

            selectedID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            using (HttpClient httpClient = new HttpClient())
            {
                var user = await httpClient.GetFromJsonAsync<UserDto>(url + "User/GetById/" + selectedID);

                txtAdress.Text = user.Adress;
                txtEmail.Text = user.Email;
                txtFirstName.Text = user.FirstName;
                txtLastName.Text = user.LastName;
                txtPassword.Text = user.Password;
                txtUserName.Text = user.UserName;
                dtpDateOfBirth.Value = user.DateOfBirth == DateTime.MinValue ? DateTime.Now : user.DateOfBirth;
                var userGender = user.Gender;
                if (userGender == true)
                {
                    comboBox1.Text = "Kad�n";
                    comboBox1.SelectedValue = 1;
                }
                else
                {
                    comboBox1.Text = "Erkek";
                    comboBox1.SelectedValue = 0;
                }
            }
            btnEkle.Enabled = false;
            btnD�zenle.Enabled = true;
            btnSil.Enabled = true;
        }
        #endregion Methods


    }
}
