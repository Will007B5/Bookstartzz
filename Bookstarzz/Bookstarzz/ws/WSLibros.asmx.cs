﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;
using Backend.Modelos;
using Backend.clases;
using System.Security;
namespace Bookstarzz.ws
{
    /// <summary>
    /// Summary description for WSLibros
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WSLibros : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        public String getOne(int idLibro)
        {
            if (Session["session"] != null)
            {
                string tipo = Session["session"].ToString();
                if (tipo.Equals("usu") || tipo.Equals("admi"))
                {
                    try
                    {
                        JavaScriptSerializer jss = new JavaScriptSerializer();
                        return jss.Serialize(new DaoLibros().getOne(idLibro));
                    }
                    catch
                    {
                        throw new Exception("Se ha presentado un problema al obtener los datos");
                    }
                    
                }

            }
            return null;
        }


        [WebMethod(EnableSession = true)]
        public string getAll()
        {

            if (Session["session"] != null)
            {
                string tipo = Session["session"].ToString();
                if (tipo.Equals("usu") || tipo.Equals("admi"))
                {
                    try
                    {
                        JavaScriptSerializer jss = new JavaScriptSerializer();
                        return jss.Serialize(new DaoLibros().getAll());
                    }
                    catch(Exception e)
                    {
                        throw new Exception("Se ha presentado un problema al obtener los datos");
                    }
                }

            }
            return null;
        }

        [WebMethod(EnableSession = true)]
        public string getPopulares()
        {

            if (Session["session"] != null)
            {
                string tipo = Session["session"].ToString();
                if (tipo.Equals("usu") || tipo.Equals("admi"))
                {
                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    return jss.Serialize(new DaoLibros().getPopulares());
                }

            }
            throw new SecurityException("Acceso restringido");
        }


        [WebMethod(EnableSession = true)]
        public string getNuevos()
        {

            if (Session["session"] != null)
            {
                string tipo = Session["session"].ToString();
                if (tipo.Equals("usu") || tipo.Equals("admi"))
                {
                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    return jss.Serialize(new DaoLibros().getNuevos());
                }

            }
            throw new SecurityException("Acceso restringido");
        }


        [WebMethod(EnableSession = true)]
        public int insertLibro(String info)
        {

            if (Session["session"] != null)
            {
                string tipo = Session["session"].ToString();
                if (tipo.Equals("admi"))
                {
                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    Libros obj = jss.Deserialize<Libros>(info);
                    if (valido(obj))
                    {
                        try
                        {
                            int val = 0;
                            return val = new DaoLibros().insertLibro(obj);
                        }
                        catch
                        {
                            throw new Exception("Se ha presentado un problema en el acceso a los datos");
                        }
                    }
                }
            }
            return 0;
        }

        [WebMethod(EnableSession = true)]
        public bool updateLibro(String info)
        {

            if (Session["session"] != null)
            {
                string tipo = Session["session"].ToString();
                if (tipo.Equals("admi"))
                {
                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    Libros obj = jss.Deserialize<Libros>(info);
                    if (valido(obj))
                    {
                        try
                        {
                            bool val = false;
                            return val = new DaoLibros().updateLibro(obj);
                        }
                        catch
                        {
                            throw new Exception("Se ha presentado un problema al obtener los datos");
                        }
                    }
                }
            }
            return false;
        }

        [WebMethod(EnableSession = true)]
        public bool deleteLibro(int id)
        {

            if (Session["session"] != null)
            {
                string tipo = Session["session"].ToString();
                if (tipo.Equals("admi"))
                {

                    try
                    {
                        return new DaoLibros().deleteLibro(id);
                    }
                    catch
                    {
                        throw new Exception("Se ha presentado un problema al obtener los datos");
                    }
                }
            }
            return false;
        }

        [WebMethod(EnableSession = true)]

        public String traerLibro(string nombre)
        {

            if (Session["session"] != null)
            {
                string tipo = Session["session"].ToString();
                if (tipo.Equals("usu") || tipo.Equals("admi"))
                {
                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    return jss.Serialize(new DaoLibros().traerLibro(nombre));
                }

            }
            throw new SecurityException("Acceso restringido");
        }

        public bool valido(Libros obj)
        {

            if (obj.Nombre == "" || obj.Nombre.Length > 50)
            {

                return false;
            }

            if (obj.Autor == "" || obj.Autor.Length > 50)
            {

                return false;
            }

            if (obj.Editorial == "" || obj.Editorial.Length > 30)
            {
                return false;
            }

            if (obj.ISBN == "" || obj.ISBN.Length > 30)
            {
                return false;

            }

            if (obj.FechaPublicacion == null)
            {
                return false;
            }


            if (obj.Descripcion == "" || obj.Descripcion.Length > 300)
            {
                return false;
            }

            return true;
        }

    }
}

