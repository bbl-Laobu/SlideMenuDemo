using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using SlideMenuDemo.Pages;

namespace SlideMenuDemo.Views
{
    public partial class SlideUpMenuView : ContentView
    {
        static int headerButtonSelectedPosition; //0=Left, 1=Right
        static uint tapMarkerSpeed = 200;

        public SlideUpMenuView()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<SlideUpMenuView>(this, "UpdateTabMarker", async (sender) =>
            {
                await updateTabMarker();
            });
        }

        void OnMenuTappedAsync(object sender, EventArgs args)
        {
			MessagingCenter.Send<SlideUpMenuView>(this, "UpdateTabMarker");
            MessagingCenter.Send<SlideUpMenuView>(this, "OpenCloseSlideUpMenu");
        }

        void OnHeaderLeftButtonTappedAsync(object sender, EventArgs args)
        {
            headerButtonSelectedPosition = 0;
            MessagingCenter.Send<SlideUpMenuView>(this, "UpdateTabMarker");
			MessagingCenter.Send<SlideUpMenuView>(this, "LeftClicked");
			MessagingCenter.Send<SlideUpMenuView>(this, "CloseSlideUpMenu");
        }

        void OnHeaderRightButtonTappedAsync(object sender, EventArgs args)
        {
            headerButtonSelectedPosition = 1;
            MessagingCenter.Send<SlideUpMenuView>(this, "UpdateTabMarker");
			MessagingCenter.Send<SlideUpMenuView>(this, "RightClicked");
			MessagingCenter.Send<SlideUpMenuView>(this, "CloseSlideUpMenu");
        }


        async Task updateTabMarker()
        {
            if (headerButtonSelectedPosition == 0)
            {
                await MoveTabMarkerToLeft();
            }
            else
            {
                await MoveTabMarkerToRight();
            }
        }

        async Task MoveTabMarkerToLeft()
        {
            await buttonSelectedMarker.TranslateTo(0, 0, tapMarkerSpeed);
            headerButtonSelectedPosition = 0;
        }

        async Task MoveTabMarkerToRight()
        {
            var tapSelectedEndPos = headerLeftButton.Width / 2 + menuButton.Width + headerRightButton.Width / 2;
            await buttonSelectedMarker.TranslateTo(tapSelectedEndPos, 0, tapMarkerSpeed);
            headerButtonSelectedPosition = 1;
        }


		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new RotateAnimationPage());
		}
    }
}
