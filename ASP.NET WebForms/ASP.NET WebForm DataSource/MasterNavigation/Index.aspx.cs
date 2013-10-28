
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterNavigation
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
        }

        protected void ContinentsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void GridViewCustomers_PageIndexChanging(object sender,
            System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
        }

        protected void AddContinent_Click(object sender, EventArgs e)
        {
            string newContinentName = this.NewContinent.Text.ToString();

            EarthEntities context = new EarthEntities();

            Continent newContinent = new Continent()
            {
                Name=newContinentName
            };

            context.Continents.Add(newContinent);
            context.SaveChanges();

            this.NewContinent.Text = "";
            this.ContinentsListBox.DataBind();
        }

        protected void DeleteContinent_Click(object sender, EventArgs e)
        {
            int selectedContinent = int.Parse(this.ContinentsListBox.SelectedValue);

            EarthEntities context = new EarthEntities();

            var continent = context.Continents.FirstOrDefault(c => c.Id == selectedContinent);

            context.Continents.Remove(continent);
            context.SaveChanges();

            this.ContinentsListBox.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.EditContinentName.Visible = true;
            this.SaveContinent.Visible = true;
            this.CancelContinent.Visible = true;
        }

        protected void SaveContinent_Click(object sender, EventArgs e)
        {
            int currentContinentId = int.Parse(this.ContinentsListBox.SelectedValue);
            EarthEntities context = new EarthEntities();
            var currentContinent = context.Continents.FirstOrDefault(c => c.Id == currentContinentId);
            currentContinent.Name = this.EditContinentName.Text;
            context.SaveChanges();

            this.EditContinentName.Text = "";
            this.ContinentsListBox.DataBind();
        }

        protected void CancelContinent_Click(object sender, EventArgs e)
        {
            this.EditContinentName.Visible = false;
            this.SaveContinent.Visible = false;
            this.CancelContinent.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var selectedContinentId = int.Parse(this.ContinentsListBox.SelectedValue);
            EarthEntities context = new EarthEntities();
            var selectedContinent = context.Continents.FirstOrDefault(c => c.Id == selectedContinentId);

            Country country = new Country()
            {
                Name = this.NewCountryName.Text,
                Language = this.NewCountryLanguage.Text,
                Population = int.Parse(this.NewCountryPopulation.Text)
            };

            selectedContinent.Countries.Add(country);
            context.SaveChanges();

            this.NewCountryPopulation.Text = "";
            this.NewCountryName.Text = "";
            this.NewCountryLanguage.Text = "";

            this.GridView1.DataBind();
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            int selectedCountryId = (int)this.GridView1.SelectedDataKey.Value;
            EarthEntities context = new EarthEntities();
            var selectedCountry = context.Countries.FirstOrDefault(c => c.Id == selectedCountryId);

            Town town = new Town()
            {
                Name = this.NewTownName.Text,
                Population = int.Parse(this.NewTownPopulation.Text)
            };

            selectedCountry.Towns.Add(town);
            context.SaveChanges();

            this.NewTownName.Text = "";
            this.NewTownPopulation.Text = "";

            this.GridView1.DataBind();
        }
    }
}