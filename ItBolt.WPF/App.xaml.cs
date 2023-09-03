using Microsoft.Extensions.DependencyInjection;
using System;
using ItBolt.Model.Entities;
using System.Windows;
using ItBolt.WPF.ViewModels;
using ApiClient.Repositories;
using ItBolt.WPF.Views;
using ApiClient.Entities;

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
            services.AddTransient<BelepesViewModel>();
            services.AddTransient<AddBoltViewModel>();
            services.AddTransient<AddRaktarViewModel>();
            services.AddTransient<AddEszkozViewModel>();
            services.AddTransient<BoltKimutatasViewModel>();
            services.AddTransient<RaktarKimutatasViewModel>();
            services.AddTransient<EszkozKimutatasViewModel>();
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

            services.AddTransient<IGenericRepository<Bolt>, GenericAPIRepository<Bolt>>(x =>
            {
                return new PagerRepository<Bolt>("api/Boltok");
            });

            services.AddTransient<IGenericRepository<Raktar>, GenericAPIRepository<Raktar>>(x =>
            {
                return new PagerRepository<Raktar>("api/Raktarok/RaktarokToList");
            });

            services.AddTransient<IPagerRepository<Raktar>, PagerRepository<Raktar>>(x =>
            {
                return new PagerRepository<Raktar>("api/Raktarok");
            });

            services.AddTransient<IPagerRepository<Eszkoz>, PagerRepository<Eszkoz>>(x =>
            {
                return new PagerRepository<Eszkoz>("api/Eszkozok");
            });
            services.AddTransient<IGenericRepository<Eszkoz>, GenericAPIRepository<Eszkoz>>(x =>
            {
                return new PagerRepository<Eszkoz>("api/Eszkozok");
            });
            services.AddTransient<IGenericRepository<Kategoria>, GenericAPIRepository<Kategoria>>(x =>
            {
                return new PagerRepository<Kategoria>("api/Kategoriak");
            });
            services.AddTransient<IGenericRepository<Gyarto>, GenericAPIRepository<Gyarto>>(x =>
            {
                return new PagerRepository<Gyarto>("api/Gyartok");
            });

            return services.BuildServiceProvider();
        }
    }
}
