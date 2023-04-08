using PRN211PE_SP23_MaVanMeo.Repository.Repository;
using System.Linq;

namespace PRN211PE_SP23_MaVanMeo;

public partial class frmManagementAccounts : Form
{
    private IAccountRepository accountRepository 
        = new AccountRepository();
    private ICustomerRepo customerRepository = new CustomerRepo();
    private string[] arrCustomerName;

    public BindingSource BindingSource; 
    public frmManagementAccounts()
    {
        arrCustomerName = customerRepository.GetAllCustomer()
            .Select(c => c.CustomerName).ToArray();

    
        InitializeComponent();
    }

    private void frmManagementAccounts_Load(object sender, EventArgs e)
    {
        //1. load data to datagridviews
        _loadAccountToGrid();

        //2. load to combobox
        cboCustomerName.Items.AddRange(arrCustomerName);
       cboCustomerName.SelectedIndex = 0;
    }


    private void _loadAccountToGrid()
    {
        
        var accounts = accountRepository.GetAllAccounts().Select(
            c => new
        {
            AccountId= c.AccountId,
            AccountName=c.AccountName,
            OpenDate=c.OpenDate,
            RegionName=c.RegionName,
            CustomerName= c.Customer.CustomerName
      });         
         
         
        

        BindingSource = new BindingSource();
        BindingSource.DataSource= accounts;
         
         
        //binding
        txtAccountId.DataBindings.Clear();
        txtAccountName.DataBindings.Clear();    
        txtRegion.DataBindings.Clear();
        dtpOpenDate.DataBindings.Clear();
        cboCustomerName.DataBindings.Clear();

        txtAccountId.DataBindings.Add("Text", BindingSource, "AccountId");
        txtAccountName.DataBindings.Add("Text",BindingSource, "AccountName");
        dtpOpenDate.DataBindings.Add("Text",BindingSource, "OpenDate");
        txtRegion.DataBindings.Add("Text", BindingSource, "RegionName");
        cboCustomerName.DataBindings.Add("Text", BindingSource, "CustomerName");
        //dua len gridview
        dgvAccounts.DataSource = null;
        dgvAccounts.DataSource = BindingSource;


    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        this.Close();
    }
    private void btnSearch_Click(object sender, EventArgs e)
    {
        string region = txtSearch.Text;
        var accounts = accountRepository.GetAccountByReligon(region).Select(
             c => new
             {
                 AccountId = c.AccountId,
                 AccountName = c.AccountName,
                 OpenDate = c.OpenDate,
                 RegionName = c.RegionName,
                 CustomerName = c.Customer.CustomerName
             });




        BindingSource = new BindingSource();
        BindingSource.DataSource = accounts;


        //binding
        txtAccountId.DataBindings.Clear();
        txtAccountName.DataBindings.Clear();
        txtRegion.DataBindings.Clear();
        dtpOpenDate.DataBindings.Clear();
        cboCustomerName.DataBindings.Clear();

        txtAccountId.DataBindings.Add("Text", BindingSource, "AccountId");
        txtAccountName.DataBindings.Add("Text", BindingSource, "AccountName");
        dtpOpenDate.DataBindings.Add("Text", BindingSource, "OpenDate");
        txtRegion.DataBindings.Add("Text", BindingSource, "RegionName");
        cboCustomerName.DataBindings.Add("Text", BindingSource, "CustomerName");
        //dua len gridview
        dgvAccounts.DataSource = null;
        dgvAccounts.DataSource = BindingSource;
        txtSearch.Focus();
    }
    private void btnDelete_Click(object sender, EventArgs e)
    {
        DialogResult dg= MessageBox.Show("Are you sure ?","Delete", MessageBoxButtons.YesNo);
        if (dg == DialogResult.Yes)
        {
            accountRepository.Delete((txtAccountId.Text));
            //1. load data to datagridviews
            _loadAccountToGrid();

        }
    }
}
