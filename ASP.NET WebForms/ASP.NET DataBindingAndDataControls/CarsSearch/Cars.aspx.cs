using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarsSearch
{
    public partial class Cars : System.Web.UI.Page
    {
        public List<Extra> extras = new List<Extra>();
        public List<Model> bmwModels = new List<Model>();
        public List<Model> mercedesModels = new List<Model>();
        public List<Producer> producers = new List<Producer>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Extra turbo = new Extra() { Id = 1, Type = "turbo" };
            Extra nitro = new Extra() { Id = 2, Type = "nitro" };
            Extra tuning = new Extra() { Id = 2, Type = "tuning" };
            Extra kompresor = new Extra() { Id = 2, Type = "kompresor" };

            extras.Add(turbo);
            extras.Add(nitro);

            Model coupe325 = new Model() { Id = 1, Type = "325", Extras = extras };
            Model coupe525 = new Model() { Id = 2, Type = "525", Extras = extras };
            bmwModels.Add(coupe325);
            bmwModels.Add(coupe525);

            extras.Add(tuning);
            extras.Add(kompresor);
            Model glk350 = new Model() { Id = 3, Type = "GLK 350", Extras = extras };
            Model cl63 = new Model() { Id = 4, Type = "CL 63", Extras = extras };
            mercedesModels.Add(glk350);
            mercedesModels.Add(cl63);

            Producer bmw = new Producer() { Id = 1, Name = "BMW", Models = bmwModels };
            Producer mercedes = new Producer() { Id = 2, Name = "Mercedes", Models = mercedesModels };
            producers.Add(bmw);
            producers.Add(mercedes);

            if (!Page.IsPostBack) {

            this.ProducerDropDownList.DataSource = producers;
            this.ProducerDropDownList.DataBind();

            this.ModelsDropDownList.DataSource = bmwModels;
            this.ModelsDropDownList.DataBind();

            this.ExtrasRadioButtonList.DataSource = extras;
            this.ExtrasRadioButtonList.DataBind();
            }
        }

        protected void ProducerIndexChange(object sender, EventArgs e)
        {
            int selectedProducer = int.Parse(this.ProducerDropDownList.SelectedValue.ToString());
            var models = producers.FirstOrDefault(p => p.Id == selectedProducer).Models;
            this.ModelsDropDownList.DataSource = models;
            this.ModelsDropDownList.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            int selectedProducerId = int.Parse(this.ProducerDropDownList.SelectedValue.ToString());
            var models = producers.FirstOrDefault(p => p.Id == selectedProducerId).Models;
            sb.AppendLine(producers.FirstOrDefault(p => p.Id == selectedProducerId).Name);
            var modelType = models.FirstOrDefault(p => p.Id == int.Parse(this.ModelsDropDownList.SelectedValue)).Type;
            sb.Append(modelType);
            this.Literal1.Text = sb.ToString();
        }
    }
}