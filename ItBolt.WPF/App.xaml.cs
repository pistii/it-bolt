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

            services.AddTransient<IPagerRepository<Bolt>, PagerRepository<Bolt>>(x =>
            {
                return new PagerRepository<Bolt>("api/Boltok");
            });
            //services.AddTransient<IPagerRepository<Eszkoz>, PagerRepository<Eszkoz>>(x =>
            //{
            //    return new PagerRepository<Eszkoz>("api/Eszkozok");
            //});

            services.AddTransient<IGenericRepository<Raktar>, GenericAPIRepository<Raktar>>(x =>
            {
                return new PagerRepository<Raktar>("api/Raktar");
            });
            services.AddTransient<AddBoltViewModel>();
            services.AddTransient<BoltKimutatasViewModel>();
            return services.BuildServiceProvider();
        }
    }
}
