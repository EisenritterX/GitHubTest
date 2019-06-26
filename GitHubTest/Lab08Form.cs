using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GitHubTest
{
    public partial class Lab08Form : Form
    {
        public string UserName { get; set; }
        public float UserAge { get; set; }
        public Lab08Form()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// This is the Event Handler for the Lab08Form Load Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lab08Form_Load(object sender, EventArgs e)
        {
            ButtonSubmit.Enabled = false;
            ClearForm();
        }

        /// <summary>
        /// This is the Event Handler for the SubmitButton Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            UserName = NameTextbox.Text;
            //Option A
            UserAge = Convert.ToSingle(AgeTextbox.Text);
            //Option B -- Best, less memory usage
            UserAge = float.Parse(AgeTextbox.Text);
            //Option C -- Option for catch errors
            float tempFloat;
            bool result = float.TryParse(AgeTextbox.Text, out tempFloat);
            UserAge = tempFloat;
            //Option D
            //UserAge = float(AgeTextbox.Text);


            OutputLabel.Text = UserName+" "+UserAge;
        }

        private void ClearForm()
        {
            NameTextbox.Clear();
            AgeTextbox.Clear();
        }

        /// <summary>
        /// This is the Event Handler for the NameTextBox TextChanged Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NameTextbox_TextChanged(object sender, EventArgs e)
        {
            ButtonSubmit.Enabled = (NameTextbox.Text.Length >= 2) ? true : false;
        }

        private void AgeTextbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float.Parse(AgeTextbox.Text);
                ButtonSubmit.Enabled = true;
            }
            catch
            {
                ButtonSubmit.Enabled = false;
            }
        }
    }
}
