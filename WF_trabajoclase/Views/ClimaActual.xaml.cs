//using Android.Net.Wifi.Rtt;
using Microsoft.Maui.Networking;
using Newtonsoft.Json;

namespace WF_trabajoclase.Views;

public partial class ClimaActual : ContentPage
{
	public ClimaActual()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		string latitud = lat.Text;
        string longitud = lon.Text;
		
		if(Connectivity.NetworkAccess== NetworkAccess.Internet)
		{
			using (var client =new HttpClient())
			{
				
				string url = $"https://api.openweathermap.org/data/2.5/weather?lat=" + latitud + "&lon=" + longitud + "appid=08b396712b84cd44657649b9a821d18c";
					var response = await client.GetAsync(url);
				if (response.IsSuccessStatusCode) {
				var json = await response.Content.ReadAsStringAsync();
				var clima = JsonConvert.DeserializeObject<Rootobject>(json);

					weatherLabel.Text = clima.weather[0].main;
                }
            }
		}


    }
}