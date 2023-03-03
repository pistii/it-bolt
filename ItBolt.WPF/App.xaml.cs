using Microsoft.Extensions.DependencyInjection;
using System;
using ItBolt.Model.Entities;
using System.Windows;
using ItBolt.WPF.ViewModels;
using ApiClient.Repositories;

namespace ItBolt.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // https://learn.microsoft.com/en-us/windows/communitytoolkit/mvvm/ioc
        public App()
        {
            Services = ConfigureServices();
            InitializeComponent();
        }
        public new static App Current => (App)Application.Current;
        public IServiceProvider Services { get; }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<MainViewModel>();
            
            services.AddSingleton<BelepesViewModel>();
            services.AddSingleton<AddBoltViewModel>();
            services.AddTransient<IPagerRepository<Bolt>, PagerRepository<Bolt>>(x =>
            {
                return new PagerRepository<Bolt>("api/Bolt");
            });
            /*
            services.AddTransient<IPagerRepository<Felhasznalo>, PagerAPIRepository<Felhasznalo>>(x =>
            {
                return new PagerAPIRepository<Felhasznalo>("api/felhasznalo");
            });
            
            services.AddTransient<IGenericRepository<JarmuTipus>, GenericAPIRepository<JarmuTipus>>(x =>
            {
                return new PagerAPIRepository<JarmuTipus>("api/JarmuTipusok");
            });
            services.AddTransient<IPagerRepository<Ugyfel>, PagerAPIRepository<Ugyfel>>(x =>
            {
                return new PagerAPIRepository<Ugyfel>("api/Ugyfelek");
            });
            
            services.AddTransient<JarmuvekViewModel>();
            services.AddTransient<UgyfelekViewModel>();
            */
            return services.BuildServiceProvider();
        }
    }
}
