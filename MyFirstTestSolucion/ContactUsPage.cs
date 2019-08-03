using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstTestSolucion
{
    public partial class ContactUsPage : Component
    {
        public ContactUsPage()
        {
            InitializeComponent();
        }

        public ContactUsPage(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
