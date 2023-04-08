using PRN211PE_SP23_MaVanMeo.Repository.Repository;

namespace PRN211PE_SP23_MaVanMeo;

public partial class frmLogin : Form
{
    private IUser userManager;
    public frmLogin()
    {
        InitializeComponent();
        userManager = new UserManager();
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Application.Exit(); 
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        if(txtUserName.Text == "")
        {
            MessageBox.Show("User name is empty..");
            txtUserName.Focus();
            return;
        }

        if (txtPass.Text == "")
        {
            MessageBox.Show("Password is empty..");
            txtPass.Focus();
            return;
        }
        //goi vao db de check username && pass
        var user = userManager.GetAllUsers()
                    .Where(u => txtUserName.Text.Equals(u.UserId)
                    && txtPass.Text.Equals(u.Password))
                    .FirstOrDefault();

        if (user != null)
        {
            if (user.UserRole == 1) //admin
            {
                //load form management account
                frmManagementAccounts frmManagementAccounts = new frmManagementAccounts();
                this.Hide();
                frmManagementAccounts.ShowDialog();
               

            }
            else
            {
                MessageBox.Show("You are not allowed to access this function!");
            }
        }
        else
        {
            MessageBox.Show("Invalid username or password!","Notification");
            txtUserName.Focus();
            return;
        }


       

    }
}