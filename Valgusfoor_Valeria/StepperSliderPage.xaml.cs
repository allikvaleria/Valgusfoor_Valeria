namespace Valgusfoor_Valeria;

public partial class StepperSliderPage : ContentPage
{
	Label lbl;
	Slider sl;
	Stepper st;
	AbsoluteLayout abs;
	public StepperSliderPage()
	{
		lbl = new Label
		{
			BackgroundColor = Color.FromRgb(120, 144, 133),
			Text = "..."
		};
		sl = new Slider
		{
			Minimum = 0,
			Maximum = 100,
			Value = 25,
			MinimumTrackColor = Color.FromRgb(55, 55, 55),
			MaximumTrackColor = Color.FromRgb(0, 0, 0),
			ThumbColor = Color.FromRgb(155, 155, 155),
		};
        sl.ValueChanged += Sl_ValueChanged;

		st = new Stepper
		{
			Minimum = 0,
			Maximum = 100,
			Increment = 5,
			Value = 25,
			HorizontalOptions = LayoutOptions.CenterAndExpand
		};
        st.ValueChanged += St_ValueChanged;


    }

    private void St_ValueChanged(object? sender, ValueChangedEventArgs e)
    {
		lbl.Text = String.Format("{0.F1}", e.NewValue);
		lbl.FontSize = e.NewValue;
		lbl.Rotation = e.NewValue;
    }

    private void Sl_ValueChanged(object? sender, ValueChangedEventArgs e)
    {
        lbl.Text = String.Format("{0.F1}", e.NewValue);
        lbl.FontSize = e.NewValue;
        lbl.Rotation = e.NewValue;
    }

    
}