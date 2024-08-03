using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test.CustomerService;
using Test.DTOs;

namespace Test
{
    public partial class _Default : Page
    {

        private readonly CustomerServiceClient _customerService = new CustomerServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Init();
                LoadCustomerList();
            }
        }

        private void LoadCustomerList()
        {
            try
            {
                var listado = _customerService.GetClientesActivos();
                gvCustomer.DataSource = listado;
                gvCustomer.DataBind();
            }
            catch (Exception ex)
            {                
                Console.WriteLine($"Error cargando listado de clientes: {ex.Message}");
            }
        }

        private void Init()
        {
            ToggleCustomerFormVisibility(true);
            ResetFormFields();
            SetFormLabels("Guardar", "Nuevo Cliente");
        }

        private void ToggleCustomerFormVisibility(bool showCustomerList)
        {
            divCustomersList.Visible = showCustomerList;
            divNewCustomer.Visible = !showCustomerList;
        }

        private void ResetFormFields()
        {
            btnGuardar.Text = "Guardar";
            lblFormCustomer.Text = "Nuevo Cliente";
            hf_cliente_id.Value = string.Empty;
            hf_direccion_id.Value = string.Empty;
            hf_direccion.Value = string.Empty;
            txtNom1.Text = string.Empty;
            txtNom2.Text = string.Empty;
            txtApe1.Text = string.Empty;
            txtApe2.Text = string.Empty;
            txtIdent.Text = string.Empty;
            txtIdentTpo.Text = string.Empty;
            txtDir.Text = string.Empty;
        }

        private void SetFormLabels(string buttonText, string formLabelText)
        {
            btnGuardar.Text = buttonText;
            lblFormCustomer.Text = formLabelText;
        }

        enum Validaciones
        {
            Nom1,
            Nom2,
            Ape1,
            Ape2,
            Ident,
            IdentTpo,
            Dir,
            Valido
        }

        private Validaciones IsValidForm()
        {
            if (string.IsNullOrEmpty(txtNom1.Text)) return Validaciones.Nom1;
            if (string.IsNullOrEmpty(txtNom2.Text)) return Validaciones.Nom2;
            if (string.IsNullOrEmpty(txtApe1.Text)) return Validaciones.Ape1;
            if (string.IsNullOrEmpty(txtApe2.Text)) return Validaciones.Ape2;
            if (string.IsNullOrEmpty(txtIdent.Text)) return Validaciones.Ident;
            if (string.IsNullOrEmpty(txtIdentTpo.Text)) return Validaciones.IdentTpo;
            if (string.IsNullOrEmpty(txtDir.Text)) return Validaciones.Dir;

            return Validaciones.Valido;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (IsValidForm() != Validaciones.Valido) return;

            var cliente = new
            {
                Ident = txtIdent.Text,
                IdentTpo = txtIdentTpo.Text,
                Nom1 = txtNom1.Text,
                Nom2 = txtNom2.Text,
                Ape1 = txtApe1.Text,
                Ape2 = txtApe2.Text,
                Dir = txtDir.Text
            };

            try
            {
                if (btnGuardar.Text == "Guardar")
                {
                    _customerService.InsertCliente(cliente.Ident, cliente.IdentTpo, cliente.Nom1, cliente.Nom2, cliente.Ape1, cliente.Ape2, cliente.Dir, true);
                }
                else
                {
                    int clientId = Convert.ToInt32(hf_cliente_id.Value);
                    int direccionId = Convert.ToInt32(hf_direccion_id.Value);
                    bool direccionChanged = hf_direccion.Value != cliente.Dir;

                    _customerService.UpdateCliente(clientId, cliente.Ident, cliente.IdentTpo, cliente.Nom1, cliente.Nom2, cliente.Ape1, cliente.Ape2, direccionId, cliente.Dir, direccionChanged);
                }

                Response.Redirect("~/");
            }
            catch (Exception ex)
            {                
                Console.WriteLine($"Error al tratar de guardar al cliente: {ex.Message}");
            }
        }

        protected void lnkUpdate_Click(object sender, EventArgs e)
        {
            ToggleCustomerFormVisibility(false);
            SetFormLabels("Actualizar", "Actualizar Cliente");

            try
            {
                string clienteId = ((LinkButton)sender).CommandArgument;
                hf_cliente_id.Value = clienteId;

                var oCliente = _customerService.GetCliente(Convert.ToInt32(clienteId));

                hf_direccion.Value = oCliente.direccion;
                hf_direccion_id.Value = oCliente.direccion_id.ToString();
                txtIdent.Text = oCliente.numero_identificacion;
                txtIdentTpo.Text = oCliente.tipo_identificacion;
                txtNom1.Text = oCliente.primer_nombre;
                txtNom2.Text = oCliente.segundo_nombre;
                txtApe1.Text = oCliente.primer_apellido;
                txtApe2.Text = oCliente.segundo_apellido;
                txtDir.Text = oCliente.direccion;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, loguear el error
                Console.WriteLine($"Error cargando detalle del cliente: {ex.Message}");
            }
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string clienteId = ((LinkButton)sender).CommandArgument;
                _customerService.DeleteCliente(Convert.ToInt32(clienteId));
                Response.Redirect("~/");
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, loguear el error
                Console.WriteLine($"Error al tratar de eliminar al cliente: {ex.Message}");
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            ToggleCustomerFormVisibility(false);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ToggleCustomerFormVisibility(true);
        }
    }
}