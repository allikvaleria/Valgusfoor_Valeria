using System.Threading.Tasks;

namespace Valgusfoor_Valeria;

public partial class Valgusfoor : ContentPage
{
    private Label lbl, message;
    private BoxView[] lights = new BoxView[3];
    private bool isOn = false;

    public Valgusfoor()
    {
        lbl = new Label
        {
            Text = "Valgusfoor",
            FontSize = 24,
            TextColor = Colors.Black,
            HorizontalOptions = LayoutOptions.Center
        };

        message = new Label
        {
            Text = "Valgusfoor on välja lülitatud",
            FontSize = 18,
            TextColor = Colors.Gray,
            HorizontalOptions = LayoutOptions.Center
        };

        
        StackLayout lightsStack = new StackLayout
        {
            Spacing = 10,
            VerticalOptions = LayoutOptions.Center
        };

        for (int i = 0; i < 3; i++)
        {
            lights[i] = new BoxView
            {
                Color = Colors.Gray,
                CornerRadius = 50,
                WidthRequest = 100,
                HeightRequest = 100,
                HorizontalOptions = LayoutOptions.Center
            };

            var tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += Light_Tapped;
            lights[i].GestureRecognizers.Add(tapGesture);

            lightsStack.Children.Add(lights[i]);
        }

        
        Button onButton = new Button { Text = "Sisse" };
        onButton.Clicked += OnButton_Clicked;

        Button offButton = new Button { Text = "Välja" };
        offButton.Clicked += OffButton_Clicked;

        Button Ooreziim = new Button { Text = "Ööreþiim" };
        Ooreziim.Clicked += Ooreziim_Clicked;

        HorizontalStackLayout buttonLayout = new HorizontalStackLayout
        {
            Children = { onButton, offButton, Ooreziim },
            Spacing = 20,
            HorizontalOptions = LayoutOptions.Center
        };

        
        Content = new VerticalStackLayout
        {
            Children = { lbl, message, lightsStack, buttonLayout },
            Spacing = 20,
            Padding = 20,
            VerticalOptions = LayoutOptions.Center
        };
    }

    private async void Ooreziim_Clicked(object? sender, EventArgs e)
    {
        if (!isOn)
        {
            message.Text = "Lülitage kõigepealt valgusfoorid sisse!";
            return;
        }
        isOn = false;
        message.Text = "Ööreþiim";
        lights[0].Color = Colors.Gray;
        lights[1].Color = Colors.Yellow;
        lights[2].Color = Colors.Gray;

        for (int i = 0; i < 6; i++)
        {
            lights[1].Color = (i % 2 == 0) ? Colors.Yellow : Colors.Gray;
            await Task.Delay(500);
        }
        message.Text = "Valgusfoor on välja lülitatud";
        lights[1].Color = Colors.Gray;
    }

    private void OnButton_Clicked(object sender, EventArgs e)
    {
        isOn = true;
        message.Text = "Valgusfoor on sisse lülitatud";
        lights[0].Color = Colors.Red;
        lights[1].Color = Colors.Yellow;
        lights[2].Color = Colors.Green;
    }

    private void OffButton_Clicked(object sender, EventArgs e)
    {
        isOn = false;
        message.Text = "Valgusfoor on välja lülitatud";
        foreach (var light in lights) light.Color = Colors.Gray;
    }

    private void Light_Tapped(object sender, TappedEventArgs e)
    {
        if (!isOn)
        {
            message.Text = "Kõigepealt lülitage valgusfoorid sisse";
            return;
        }

        if (sender == lights[0]) message.Text = "Stopp!";
        else if (sender == lights[1]) message.Text = "Oodake!";
        else if (sender == lights[2]) message.Text = "Mine!";
    }
}