﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bookstarzz
{
    public partial class Maestra : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["session"] != null)
            {
                string tipo = Session["session"].ToString();
                txtTipo.Text = tipo; //Se asigna al control oculto el tipo de sesion en el que esta
            }
        }
    }
}