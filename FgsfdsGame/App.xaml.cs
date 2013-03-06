using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.EntityClient;
using System.Data.Metadata.Edm;
using System.Linq;
using System.Windows;

namespace FgsfdsGame
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            if(e.Args.Contains("-editor"))
            {
                IsEditorMode = true;
            }
        }

        protected internal bool IsEditorMode { get; private set; }
    }
}
