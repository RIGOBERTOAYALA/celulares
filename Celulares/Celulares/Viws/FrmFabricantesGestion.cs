using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tienda_Electronics.Models;

namespace Tienda_Electronics.Views
{
    public partial class FrmFabricantesGestion : Form
    {
        fabricante oGabricante = null;
        private int idFabricante;
        public FrmFabricantesGestion(int idFabricante)
        {
            InitializeComponent();
        }

        public void listarPaises()
        {
            using (tiendaEntities db = new tiendaEntities())
            {
                var firstItem = new List<dynamic>()
                {
                     new{ id_Dominio = "T", valor_Dominio = "Todos" }
                };

                //consulta usando LINQ
                var lisPaises = (from p1 in firstItem select p1).Union(from p in db.dominios
                                                                       where p.tipo_dominio.Equals("Paises")
                                                                       orderby p.valor_dominio
                                                                       select new
                                                                       {
                                                                           id_Dominio = p.id_dominio,
                                                                           valor_Dominio = p.valor_dominio
                                                                       });
                this.cboPais.DataSource = lisPaises.ToList();
                this.cboPais.DisplayMember = "valor_Dominio";
                this.cboPais.ValueMember = "id_Dominio";
            }
        }
        private void FrmFabricantesGestion_Load(object sender, EventArgs e)
        {
            listarPaises();
        }

        private void CboPais_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtNombre.text)
                this.cboPais.SelectedValue.ToString() == "T"
            {
                MessageBox.Show("Los campos marcados con (*) son obliugatorios");

                
        }
            else
            {
                using (tiendaEntities db = new tiendaEntities())
                {
                    //si es modo insercion, inicializamos el objeto de fabricantes 
                    if (this.idFabricante == null)
                    {
                        oFabricantes = new fabricantes();
                        // Armar el objeto con los datos registrados en el formulario
                        oFABRICANTES.NOM_FABRICANTE = this.txtNombre.Text;
                        oFabricante.PAIS_FABRICANTE = this.cboPais.SelectedText;

                        if(this.idFabricante == null)
                        {
                            //INSERT nuevo fabricante
                            db.Fabricantes.Add(oFabricantes);

                        }
                         else
                        {
                            // Modificar fabricante existente
                            db.Entry(oFabricante).State = System.Data.Entity.EntityState.Modified;

                        }
                        //confirmar cambios en la BD
                        db.savechanges();
                        //cerrar formulario de gestion de fabricantes
                        this.Close();

                        {
                            {

                            }
                        }
                    }


