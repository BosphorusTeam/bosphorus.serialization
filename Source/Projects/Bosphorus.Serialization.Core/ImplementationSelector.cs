using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bosphorus.Serialization.Core
{
    public partial class ImplementationSelector : Form
    {
        public ImplementationSelector(IEnumerable<Type> types)
        {
            InitializeComponent();
            this.dataGridView1.DataSource = types.ToList();
        }

        public Type Selected
        {
            get
            {
                var dataBoundItem = dataGridView1.SelectedRows[0].DataBoundItem;
                return (Type) dataBoundItem;
            }
        }
    }
}
