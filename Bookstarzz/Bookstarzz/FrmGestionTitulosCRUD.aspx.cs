﻿using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.clases;
using Backend.Modelos;

namespace Bookstarzz
{
    public partial class FrmGestionTitulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //TODO EL CODIGO DE ESTE METODO ES CUANDO NO SE EJECUTA AJAX

        //INSERTAR
        //Libros objlibros = new Libros();
        //objlibros.Nombre = txtNombre.Text;
        //objlibros.Autor = txtAutor.Text;
        //objlibros.NPaginas = int.Parse(txtNumPaginas.Text);
        //objlibros.Clasificacion = dropDownClasificacion.SelectedIndex+1;
        //objlibros.Editorial = txtEditorial.Text;
        //objlibros.ISBN = txtISBN.Text;
        //objlibros.FechaPublicacion = DateTime.Parse(txtCalendario.Text);
        //objlibros.Presio = decimal.Parse(txtPrecio.Text);
        //objlibros.Descripcion = txtDescripcion.Text;
        //DaoLibros daoLibros = new DaoLibros();
        //daoLibros.insertLibro(objlibros);

        //MODIFICAR
        //Libros objlibros = new Libros();
        //objlibros.IdLibro = int.Parse(txtidLibro.Text);
        //objlibros.Nombre = txtNombre.Text;
        //objlibros.Autor = txtAutor.Text;
        //objlibros.NPaginas = int.Parse(txtNumPaginas.Text);
        //objlibros.Clasificacion = dropDownClasificacion.SelectedIndex+1;
        //objlibros.Editorial = txtEditorial.Text;
        //objlibros.ISBN = txtISBN.Text;
        //objlibros.FechaPublicacion = DateTime.Parse(txtCalendario.Text);
        //objlibros.Presio = decimal.Parse(txtPrecio.Text);
        //objlibros.Descripcion = txtDescripcion.Text;
        //DaoLibros daoLibros = new DaoLibros();
        //daoLibros.updateLibro(objlibros);

        //ELIMINAR
        //DaoLibros daolibros = new DaoLibros();
        //daolibros.deleteLibro(int.Parse(txtidLibro.Text));

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            //Redireccion sin usar AJAX
            //Response.Redirect("FrmMenu.aspx");
        }
    }
}