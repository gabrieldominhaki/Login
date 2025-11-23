using Microsoft.Extensions.DependencyInjection;

namespace Login
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            string? usuario_logado = null;

            // Enviando o usuário ara página de login por padrão.
            MainPage = new Login();

            Task.Run(async () =>
            {
                usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");

                if (usuario_logado != null)
                {
                    MainPage = new Protegida();
                }

            });
        }


        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);

            window.Height = 700;
            window.Width = 400;

            return window;

        }
        
        

         
    }
}