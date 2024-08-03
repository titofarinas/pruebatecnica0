using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test.CustomerService;

namespace Test
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
        }

        enum validaciones
        {
            Nom1,            
            Nom2,
            Ape1,
            Ape2,
            ident,
            ident_tpo,
            dir,            
            valido,
        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            

            CustomerServiceClient customerServiceClient = new CustomerServiceClient();           

            var inputIdent = txtIdent.Text;
            var inputTpoIdent = txtIdentTpo.Text;
            var inputNom1 = txtNom1.Text;
            var inputNom2 = txtNom2.Text;
            var inputApe1 = txtApe1.Text;
            var inputApe2 = txtApe2.Text;
            var inputDir = txtDir.Text;

            customerServiceClient.InsertCliente(inputIdent, inputTpoIdent, inputNom1, inputNom2, inputApe1, inputApe2, inputDir, true);

            Response.Redirect("~/");
            
        }

      
    }
}