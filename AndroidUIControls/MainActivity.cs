using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Content;
using Android.Util;
using Android.Runtime;
using Android.Views;
using System;
using System.Collections;

namespace AndroidUIControls
{
    [Activity(Label = "AndroidUIControls", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        ListView listView;
        ArrayAdapter arrayAdapter;
        ArrayList UIControlArray;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            UIControlArray = new ArrayList();

            //Add some data
            UIControlArray.Add("TextView");
            UIControlArray.Add("Edit Text");
            UIControlArray.Add("AutoCompleteTextView");
            UIControlArray.Add("Button");
            UIControlArray.Add("ImageButton");
            UIControlArray.Add("Checkbox");
            UIControlArray.Add("ToggleButton");
            UIControlArray.Add("RadioButton");
            UIControlArray.Add("RadioGroup");
            UIControlArray.Add("Progress Bar");
            UIControlArray.Add("Spinner");
            UIControlArray.Add("TimePicker");
            UIControlArray.Add("DatePicker");

            //assosiate listview
            listView = FindViewById<ListView>(Resource.Id.list);

            //Adapter - Custom Item in ListView
            arrayAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, UIControlArray);

            //Setting Adapter
            listView.Adapter = arrayAdapter;
            listView.ItemClick += itemClicked;
            //listView.ItemSelected += itemSelectedFromList;


        }

        private void itemSelectedFromList(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Console.WriteLine("Selected item: " + e.Position);
            Console.WriteLine("Click working At Select");
        }

        void itemClicked(object sender, AdapterView.ItemClickEventArgs e)
        {
            Console.WriteLine("Click working"+ e.Id);

            var activity2 = new Intent(this, typeof(SecondActivity));
            activity2.PutExtra("controlType", UIControlArray[(int)e.Id].ToString());
            StartActivity(activity2);

        }

    }
}