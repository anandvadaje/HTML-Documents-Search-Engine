using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTML_Documents_Search_Engine
{
    public partial class SearchForm : MetroFramework.Forms.MetroForm
    {
        Logic searchEngine;
        public SearchForm()
        {
            InitializeComponent();
            searchEngine = new Logic();
        }

        private void m_SearchButton_Click(object sender, EventArgs e)
        {
            string query = m_KeyWorkTextBox.Text;

            m_ResultTextBox.Text = searchEngine.start_search(query);
            this.Refresh();


        }
    }
}
