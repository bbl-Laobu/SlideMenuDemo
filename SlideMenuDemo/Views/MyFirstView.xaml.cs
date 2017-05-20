using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Diagnostics;
using CarouselView.FormsPlugin.Abstractions;
using SlideMenuDemo.Pages;

namespace SlideMenuDemo.Views
{
	public partial class MyFirstView : ContentView
	{
		public MyFirstView ()
		{
			InitializeComponent ();
		}

		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new BBLGitHubWebPage());
		}
	}
}