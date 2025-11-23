namespace Login;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		try
		{
			List<DadosUsuario> lista_usuarios = new List<DadosUsuario>()
			{
				new DadosUsuario()
				{
					usuarios = "jose",
					senha = "123"
				},
				new DadosUsuario()
				{
					usuarios = "maria",
					senha = "321"
				}
			};

			DadosUsuario dados_digitados = new DadosUsuario()
			{
				usuarios = txt_user.Text,
				senha = txt_password.Text
			};

			if (lista_usuarios.Any(i => (dados_digitados.usuarios == i.usuarios && dados_digitados.senha == i.senha)))
			{
				await SecureStorage.Default.SetAsync("usuario_logado", dados_digitados.usuarios);

				App.Current.MainPage = new Protegida();
			}
			else
			{
				throw new Exception("Usuario ou Senha incorretos.");
			}





		}
		catch (Exception ex)
		{
			await DisplayAlert("Ops...", ex.Message, "Fechar");
		}
		




    }
}