using Microsoft.Extensions.DependencyInjection;
using System;
using ItBolt.Model.Entities;
using System.Windows;
using ItBolt.WPF.ViewModels;
using ApiClient.Repositories;
using ItBolt.WPF.Views;

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

        protected override async void OnStartup(StartupEventArgs startupEventArgs)
        {
            base.OnStartup(startupEventArgs);
            ServiceCollection services = new ServiceCollection();
            services.AddSingleton<BelepesViewModel>();
            services.AddSingleton<AddBoltViewModel>();
            services.AddTransient<BoltKimutatasViewModel>();
            services.AddTransient<BoltKimutatasView>();
            services.AddTransient<AddBoltView>();
            services.AddTransient<UdvozloViewModel>();

        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<BelepesViewModel>();
            services.AddSingleton<AddBoltViewModel>();
            services.AddTransient<BoltKimutatasViewModel>();
            services.AddTransient<BoltKimutatasView>();
            services.AddTransient<AddBoltView>();

            services.AddTransient<UdvozloViewModel>();
            services.AddSingleton<MainViewModel>();


            services.AddTransient<ILoginRepository<Felhasznalo>, LoginRepository<Felhasznalo>>(x =>
            {
                return new LoginRepository<Felhasznalo>("api/Felhasznalo");
            });

            services.AddTransient<IPagerRepository<Bolt>, PagerRepository<Bolt>>(x =>
            {
                return new PagerRepository<Bolt>("api/Boltok");
            });


            services.AddTransient<IGenericRepository<Raktar>, GenericAPIRepository<Raktar>>(x =>
            {
                return new PagerRepository<Raktar>("api/Raktar");
            });


            return services.BuildServiceProvider();
        }
    }
}
