using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Spatial;
using System.Data.Entity.Spatial;

namespace RAMCO_MAPPING1
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        static bool _isSqlTypesLoaded = false;

        public WebForm4()
        {
            if (!_isSqlTypesLoaded)
            {
                SqlServerTypes.Utilities.LoadNativeAssemblies(Server.MapPath("~"));
                _isSqlTypesLoaded = true;
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            GenerateData();
        }
        void GenerateData()
        {
            Random random = new Random();
            double lat = 11.021526254058758, lng = 77.10259661170751;
            using (var context = new Registration_FormDBEntities())
            {

                for (int i = 1; i < 100; i++)
                {
                    context.PlaceInfoes.Add(new PlaceInfo()
                    {
                        Name = "Sample" + i,
                        Address = "address" + i,
                        City = "test city",
                        State = "test state",
                        CountryId = Convert.ToInt32((i + random.Next(20)) % 2),
                        Geolocation = DbGeography.FromText("POINT( " + (lng + random.NextDouble() * 1.55).ToString() + " " + (lat + random.NextDouble()).ToString() + ")")
                    });
                }
                context.SaveChanges();


            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            var currentLocation = DbGeography.FromText("POINT(" + hdnLocation.Value + ")");
            string[] latlng = hdnLocation.Value.Split(new char[] { ' ' });
            using (var context = new Registration_FormDBEntities())
            {

                var places = (from u in context.PlaceInfoes
                              orderby u.Geolocation.Distance(currentLocation)
                              select u).Take(5).Select(x => new { Name = x.Name, Address = x.Address, City = x.City, State = x.State, Latitude = x.Geolocation.Latitude, Longitude = x.Geolocation.Longitude });

                //Bind GridView
                GridView1.DataSource = places.ToList();
                GridView1.DataBind();

                //Set points for map
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                var output = serializer.Serialize(places);
                ClientScript.RegisterClientScriptBlock(GetType(), "points", "var points = " + output + ";var currentLoc = { 'Latitude' : " + latlng[1] + ", 'Longitude':" + latlng[0] + " }", true);
            }

        }
    }
}