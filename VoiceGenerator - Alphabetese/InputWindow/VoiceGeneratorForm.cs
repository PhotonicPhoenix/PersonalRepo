using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InputWindow
{
    public partial class VoiceGeneratorForm : Form
    {
        public VoiceGeneratorForm()
        {
            InitializeComponent();
        }

        private void VoiceGeneratorForm_Load(object sender, EventArgs e)
        {

        }

        private void PhraseInput_Click(object sender, EventArgs e)
        {
            if(PhraseInput.Text.Contains("Enter a phrase here..."))
            {
                PhraseInput.Clear();
            }
            
        }

        private void TextBoxImage_Click(object sender, EventArgs e)
        {
            PhraseInput.Focus();
        }
    }
}
