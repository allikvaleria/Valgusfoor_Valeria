namespace Valgusfoor_Valeria;

public partial class StartPage : ContentPage
{
    public List<ContentPage> lehed = new List<ContentPage>() { new TextPage(0), new FigurePage(1), new Valgusfoor() };
    public List<string> tekstid = new List<string> { "Tee lahti TextPage", "Tee lahti FigurePage", "Tee lahti Valgusfoor" };

    ScrollView sv;
    VerticalStackLayout vst;
    public StartPage()
    {
        //InitializeComponent();
        Title = "Avaleht";
        vst = new VerticalStackLayout { BackgroundColor = Color.FromRgb(255, 204, 229) };
        for (int i = 0; i < tekstid.Count; i++)
        {
            Button nupp = new Button
            {
                Text = tekstid[i],
                BackgroundColor = Color.FromRgb(255, 153, 204),
                TextColor = Color.FromRgb(204, 0, 102),
                FontFamily = "Lovesty 400",
                FontSize = 30,
                BorderWidth = 10,
                ZIndex = i
            };
            vst.Add(nupp);
            nupp.Clicked += Nupp_Clicked;
        }
        sv = new ScrollView { Content = vst };
        Content = sv;
    }

    private async void Nupp_Clicked(object? sender, EventArgs e)
    {
        Button btn = sender as Button;
        await Navigation.PushAsync(lehed[btn.ZIndex]);
    }
}