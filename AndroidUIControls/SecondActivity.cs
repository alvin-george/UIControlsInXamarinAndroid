
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Collections;


namespace AndroidUIControls
{
    [Activity(Label = "SecondActivity")]
    public class SecondActivity : Activity
    {



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SecondActivityLayout);


            Console.WriteLine("Second Activity Loaded");
            string intentData = Intent.GetStringExtra("controlType") ?? "0";
            Console.WriteLine(intentData);

            //Showing selected UI Control
            this.showUIControlBasedOnSelection(intentData);


        }

        private void showUIControlBasedOnSelection(string intentData)
        {
            Console.WriteLine("on Switch case");
            LinearLayout linearLayoutObject = (LinearLayout)FindViewById(Resource.Id.linearLayout);


            switch (intentData)
            {
                case UI_CONTROLS_IN_ANDROID.textView:
                    TextView textView = new TextView(this);
                    textView.Text = "Its a sample Text View";
                    textView.SetTextColor(Android.Graphics.Color.Red);
                    textView.SetBackgroundColor(Android.Graphics.Color.White);
                    linearLayoutObject.AddView(textView);
                    break;
                case UI_CONTROLS_IN_ANDROID.button:
                    Button myButton = new Button(this);
                    myButton.Text = "Sample Button";
                    linearLayoutObject.AddView(myButton);
                    break;
                case UI_CONTROLS_IN_ANDROID.autocompleteTextview:

                    AutoCompleteTextView autocompleteTextView = new AutoCompleteTextView(this);
                    autocompleteTextView.Text = "Its a sample AutoTextView";
                    autocompleteTextView.SetTextColor(Android.Graphics.Color.Red);
                    autocompleteTextView.SetBackgroundColor(Android.Graphics.Color.White);
                    linearLayoutObject.AddView(autocompleteTextView);

                    break;
                case UI_CONTROLS_IN_ANDROID.imageButton:
                    ImageButton imageButton = new ImageButton(this);
                    imageButton.SetImageResource(Resource.Drawable.mac);
                    linearLayoutObject.AddView(imageButton);

                    break;
                case UI_CONTROLS_IN_ANDROID.checkbox:
                    CheckBox checkBox = new CheckBox(this);
                    checkBox.Click += (o, e) =>
                    {
                        if (checkBox.Checked)
                            Toast.MakeText(this, "Selected", ToastLength.Short).Show();
                        else
                            Toast.MakeText(this, "Not selected", ToastLength.Short).Show();
                    };
                    linearLayoutObject.AddView(checkBox);

                    break;
                case UI_CONTROLS_IN_ANDROID.toggleButton:
                    ToggleButton toggleButton = new ToggleButton(this);
                    toggleButton.Click += (o, e) =>
                    {
                        // Perform action on clicks  
                        if (toggleButton.Checked) Toast.MakeText(this, "On", ToastLength.Short).Show();
                        else Toast.MakeText(this, "Off", ToastLength.Short).Show();
                    };
                    linearLayoutObject.AddView(toggleButton);
                    break;
                case UI_CONTROLS_IN_ANDROID.radioButton:
                    RadioButton radioButton = new RadioButton(this);
                    radioButton.Text = "Check the radio button";
                    radioButton.Click += (o, e) =>
                    {
                        Toast.MakeText(this, radioButton.Text, ToastLength.Short).Show();
                    };
                    linearLayoutObject.AddView(radioButton);
                    break;

                case UI_CONTROLS_IN_ANDROID.radioGroup:

                    RadioGroup radioGroup = new RadioGroup(this);

                    RadioButton maleRadioButton = new RadioButton(this);
                    maleRadioButton.Text = "Male";
                    maleRadioButton.Click += RadioButtonClick;
                    radioGroup.AddView(maleRadioButton);

                    RadioButton femaleRadioButton = new RadioButton(this);
                    femaleRadioButton.Text = "Female";
                    femaleRadioButton.Click += RadioButtonClick;
                    radioGroup.AddView(femaleRadioButton);

                    RadioButton otherRadioButton = new RadioButton(this);
                    otherRadioButton.Text = "Other";
                    otherRadioButton.Click += RadioButtonClick;
                    radioGroup.AddView(otherRadioButton);

                    linearLayoutObject.AddView(radioGroup);
                    break;
                case UI_CONTROLS_IN_ANDROID.progressBar:

                    ProgressBar progressBar = new ProgressBar(this);
                    progressBar.Max = 100;
                    progressBar.Progress = 30;
                    linearLayoutObject.AddView(progressBar);

                    break;
                case UI_CONTROLS_IN_ANDROID.spinner:
                    Spinner spinner = new Spinner(this);
                    spinner.ItemSelected += this.SpinnerItemSelected;

                    string[] data = { "Spinner Item 1", "Spinner Item 2", "Spinner Item 3", "Spinner Item 4", "Spinner Item 5" };

                    ArrayAdapter spinnerArrayAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, data);
                    spinner.Adapter = spinnerArrayAdapter;
                    linearLayoutObject.AddView(spinner);

                    break;
                case UI_CONTROLS_IN_ANDROID.timePicker:
                    TimePicker timePicker = new TimePicker(this);
                    timePicker.TimeChanged += (o, e) =>
                    {
                        this.onTimeChanged(timePicker, timePicker.Hour, timePicker.Minute);
                    };
                    linearLayoutObject.AddView(timePicker);
                    break;
                case UI_CONTROLS_IN_ANDROID.datePicker:

                    DatePicker datePicker = new DatePicker(this);

                    datePicker.DateChanged += (o, e) =>
                    {
                        Toast.MakeText(this, datePicker.DayOfMonth + " : " + datePicker.Month + " : " + datePicker.Year, ToastLength.Short).Show();
                    };

                    linearLayoutObject.AddView(datePicker);
                    break;

                default:
                    break;
            }
        }

        //Radio Group -  Click Event trigger this method.
        private void RadioButtonClick(object sender, EventArgs e)
        {
            Console.WriteLine("Click happened on Radio Group");
            RadioButton rb = (RadioButton)sender;
            Toast.MakeText(this, rb.Text, ToastLength.Short).Show();
        }

        // Spinner - Item Selected event trigger to this method
        public void SpinnerItemSelected(Object sender, EventArgs e)
        {
            Console.WriteLine("Click happened on Spinner Item");
            Spinner sp = (Spinner)sender;

            string item = sp.SelectedItem.ToString();
            Toast.MakeText(this, item, ToastLength.Short).Show();
        }

        //TimePicker - Timechanged trigger to this method 
        public void onTimeChanged(TimePicker view, int hourOfDay, int minute)
        {
            Console.WriteLine("Time changed");

            string AM_PM;
            if (hourOfDay < 12)
            {
                AM_PM = "AM";
            }
            else
            {
                AM_PM = "PM";
            }

            Toast.MakeText(this, hourOfDay + " : " + minute + " " + AM_PM, ToastLength.Short).Show();

        }
    }
}
