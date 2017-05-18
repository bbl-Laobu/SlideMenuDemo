using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SlideMenuDemo.ViewModels;
using SlideMenuDemo.Views;

using Xamarin.Forms;

namespace SlideMenuDemo.Pages
{
    public partial class StartPage : ContentPage
    {
        int tapCountMenu;
        public MainViewModel _vm;

        public StartPage()
        {
            InitializeComponent();

            BindingContext = _vm = new MainViewModel();
            // myCarousel.ItemTemplate = new DataTemplate(typeof(MyFirstView));

            SubcribeToSlideUpMenuMessages(); // Needed to catch SlideUpMenu events such as open and close menu...

            controlGrid.LowerChild(slideUpMenu_Interactive); // hide menu used for interaction to the back of the display stack
            //slideUpMenu_Interactive.IsVisible = false;
        }



        void SubcribeToSlideUpMenuMessages()
        {
            MessagingCenter.Subscribe<SlideUpMenuView>(this, "OpenCloseSlideUpMenu", async (sender) =>
           {
               await OpenCloseSlideUpMenuAsync();
           });

            MessagingCenter.Subscribe<SlideUpMenuView>(this, "CloseSlideUpMenu", async (sender) =>
            {
                await CloseSlideUpMenuAsync();
            });

            MessagingCenter.Subscribe<SlideUpMenuView>(this, "ReceivedClicked", (sender) =>
            {
                _vm.Position = 0;
            });
            MessagingCenter.Subscribe<SlideUpMenuView>(this, "SentClicked", (sender) =>
            {
                _vm.Position = 1;
            });
        }

        async Task OpenCloseSlideUpMenuAsync()
        {
            tapCountMenu++;

            if (tapCountMenu % 2 == 0) // Close SlideUp Menu
            {
                await CloseSlideUpMenuAsync();

            }
            else // Open SlideUp Menu
            {
                await OpenSlideUpMenuAsync();
            }
        }

        async Task CloseSlideUpMenuAsync()
        {
            // Hide menu
            slideUpMenu_Animated.IsVisible = true;
            controlGrid.LowerChild(slideUpMenu_Interactive);
            await slideUpMenu_Animated.TranslateTo(0, 0, 200, Easing.CubicInOut);

            // content overlay
            await contentOverlay.FadeTo(0, 100, Easing.CubicOut);
            contentOverlay.IsVisible = false;


            tapCountMenu = 0; // reset counter to menu closed
        }

        async Task OpenSlideUpMenuAsync()
        {
            // content overlay
            contentOverlay.IsVisible = true;
            await contentOverlay.FadeTo(0.9, 20, Easing.CubicIn);

            // Show menu
            await slideUpMenu_Animated.TranslateTo(0, -200, 200, Easing.CubicInOut);
			controlGrid.RaiseChild(slideUpMenu_Interactive);
            slideUpMenu_Animated.IsVisible = false;

            tapCountMenu = 1; // Set flag to menu Open
        }

        async void ContentOverlayTabbed(object sender, EventArgs args)
        {
            await OpenCloseSlideUpMenuAsync();
        }
    }
}