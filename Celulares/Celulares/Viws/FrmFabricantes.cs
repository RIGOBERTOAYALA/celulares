using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Celulares.Models;

namespace Celulares.Viws
{
    public partial class FrmFabricantes : Form
    {
        public FrmFabricantes()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        /*public void refrescarTabla(){
            using (TIENDASEntities db = new TIENDASEntities())
            {
                var IstFabricantes = from f in db.FABRICANTES select f;

                grdDatos.DataSource = IstFabricantes.ToList();
            }
        }*/

        public void refrescarTabla()
        {
            using (TIENDASEntities db = new TIENDASEntities())
            {
                var listFabricantes = from f in db.FABRICANTES
                                      select new
                                      {
                                          id_fabricante = f.ID_FABRICANTE,
                                          nombre_fabricante = f.NOM_FABRICANTE,
                                          pais_fabricantes = f.PAIS_FABRICANTE
                                      };

                grdDatos.DataSource = listFabricantes.ToList();
            }
        }

        public void listarPaises()
        {
            using (TIENDASEntities db = new TIENDASEntities())
            {
                var firstItem = new List<dynamic>()
                {
                     new{ id_Dominio = "T", valor_Dominio = "Todos" }
                };

                //consulta usando LINQ
                var lisPaises = (from p1 in firstItem select p1).Union(from p in db.DOMINIOS
                                                                       where p.TIPO_DOMINIO.Equals("Paises")
                                                                       orderby p.VLR_DOMINIO
                                                                    
                                                                               select new
                                                                       {
                                                                           id_Dominio = p.ID_DOMINIO,
                                                                           valor_Dominio = p.VLR_DOMINIO
                                                                       });
                this.cboPais.DataSource = lisPaises.ToList();
                this.cboPais.DisplayMember = "valor_Dominio";
                this.cboPais.ValueMember = "id_Dominio";
            }

        }
        private FABRICANTE getselectedItem ()


            FABRICANTE f = new FABRICANTE();
            try
            {
                f.ID_FABRICANTE = grdDatos.Rows [grdDatos.CurrentRow.Index].Cells[0].Value.ToString());
                return;

                    }
            catch
            {


                private void FrmFabricantes_Load(object sender, EventArgs e)
        {
            refrescarTabla();
            listarPaises();
            this.txtNombre.Focus();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            using (TIENDASEntities db = new TIENDASEntities())
            {
                //consultar fabricantes
                var lisFabricantes = from f in db.FABRICANTES
                                     select new
                                     {
                                         id_fabricante = f.ID_FABRICANTE,
                                         nombre_fabricante = f.NOM_FABRICANTE,
                                         pais_fabricantes = f.PAIS_FABRICANTE
                                     };

                //aplicar filtro dependiendo de lo que haya escrito o selleccionado el usuario
                if (!string.IsNullOrEmpty(this.txtNombre.Text))
                {
                    //consulta por nombre de fabricante a traves de Entity Framework.
                    lisFabricantes = lisFabricantes.Where(f = f.NOM_FABRICANTE.Contains(this.txtNombre.Text));
                }

                if (!this.cboPais.SelectedValue.ToString().Equals("T"))
                {
                    //filtar por pais de fabricante a traves de Entity Framework.
                    lisFabricantes = lisFabricantes.Where(f =
                            f.PAIS_FABRICANTE.Equals(this.cboPais.SelectedValue.ToString()));
                }

                grdDatos.DataSource = lisFabricantes.ToList();
            }
        }
                {

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtNombre.Text = "";
            this.cboPais.SelectedValue = "T";
            refrescarTabla();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
             frmFabricantesGestion = new FrmFabricantesGestion(null);
            frmFabricantesGestion.ShowDialog();
            refrescarTabla();

        }

        private void tbnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)

            {
                    // Retornar valir seleccionado  en la tabla 
                    FABRICANTE f = getselectedItem();
                    if(f l =null)
        }

                // llamar formulario en modo edicion 
                fmrFabricanteGestion fmrFabricanteGestion = new fmrFabricanteGestion(f.ID_FABRICANTE);
                    fmrFabricanteGestion.showDialog()
                        resfrescartabla();


                }

    }
            
