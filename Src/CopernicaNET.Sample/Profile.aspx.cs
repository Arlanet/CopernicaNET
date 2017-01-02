using System;
using System.Data.Entity;
using Arlanet.CopernicaNET.Sample.Models;

namespace Arlanet.CopernicaNET.Sample
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Add_Profile(object sender, EventArgs e)
        {
            //Create the client
            var client = new Client { DatabaseId = int.Parse(ProfileID.Text), Name = ProfileName.Text, Email = ProfileEmail.Text };
            
            try
            {
                
                //Add the client profile
                //CopernicaHandler.Instance.Add(client);
                CopernicaContext context = new CopernicaContext();
                context.Clients.Add(client);

                //var clients = context.Clients.FirstOrDefault(x => x.Name == "Shiz");
                
                StatusLabel.Text = "The profile has been added";
            }
            catch (CopernicaException ex)
            {
                StatusLabel.Text = ex.Message;
            }
        } 
        
        protected void Delete_Profile(object sender, EventArgs e)
        {
            //Create the client. Only the CopernicaKeyField property is required to delete the profile.
            var client = new Client { DatabaseId = Int32.Parse(ProfileID.Text) };
            
            try
            {
                //Delete the client profile
                CopernicaContext context = new CopernicaContext();
                context.Clients.Remove(client);

                StatusLabel.Text = "The profile has been deleted";
            }
            catch (CopernicaException ex)
            {
                StatusLabel.Text = ex.Message;
            }
        } 
        
        protected void Update_Profile(object sender, EventArgs e)
        {
            //Create the client
            var client = new Client { DatabaseId = Int32.Parse(ProfileID.Text), Name = ProfileName.Text, Email = ProfileEmail.Text };
            
            try
            {
                //Update the client profile
               // CopernicaHandler.Instance.Update(client);
                StatusLabel.Text = "The profile has been updated";
            }
            catch (CopernicaException ex)
            {
                StatusLabel.Text = ex.Message;
            }
        }

        protected void CreateOrUpdate_Profile(object sender, EventArgs e)
        {
            //Create the client
            //var client = new Client { ID = Int32.Parse(ProfileID.Text), Name = ProfileName.Text, Email = ProfileEmail.Text };

            try
            {
                //Add the client profile
                //CopernicaHandler.Instance.CreateOrUpdate(client);
                StatusLabel.Text = "The profile has been added or updated";
            }
            catch (CopernicaException ex)
            {
                StatusLabel.Text = ex.Message;
            }
        }
    }
}