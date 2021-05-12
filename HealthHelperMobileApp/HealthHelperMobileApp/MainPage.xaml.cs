using prjWorkout.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace prjWorkout
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {

            CALFactory alFactory = new CALFactory();
            alFactory.insert();

            //CWCFatory wcFatory = new CWCFatory();
            //wcFatory.insert();

            //CWFactory wFactory = new CWFactory();
            //wFactory.insert();
        }
    }
}
