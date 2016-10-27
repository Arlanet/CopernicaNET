using System;
using Arlanet.CopernicaNET.Sample.Models;
using Arlanet.CopernicaNET.Data;

namespace Arlanet.CopernicaNET.Sample
{
    public partial class SubProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Add_SubProfile(object sender, EventArgs e)
        {
            //Create the product
            var product = new Product { ID = Int32.Parse(ProductID.Text), Name = SubProfileName.Text, Price = Int32.Parse(Price.Text) };
            //Create the client. Only the identifier is needed. 
            var client = new Client() { ID = Int32.Parse(ProfileID.Text) };
            //Add the product to the client.
            try
            {
                CopernicaHandler.Instance.Add(product, client);
                StatusLabel.Text = "The subprofile has been added";
            }
            catch (CopernicaException ex)
            {
                StatusLabel.Text = ex.Message;
            }
        }

        protected void Update_SubProfile(object sender, EventArgs e)
        {
            //Create the product
            var product = new Product { ID = Int32.Parse(ProductID.Text), Name = SubProfileName.Text, Price = Int32.Parse(Price.Text) };

            try
            {
                //Update the client profile
                CopernicaHandler.Instance.Update(product);
                StatusLabel.Text = "The subprofile has been updated";
            }
            catch (CopernicaException ex)
            {
                StatusLabel.Text = ex.Message;
            }
        }
    }
}