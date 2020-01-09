using System;
using System.Collections.Generic;
using SharpnadoExemplo.ViewModels;
using Xamarin.Forms;

namespace SharpnadoExemplo
{
    public partial class InicialPage : ContentPage
    {
        public InicialPage()
        {
            InitializeComponent();

            this.BindingContext = new InicialViewModel();
        }
    }
}
