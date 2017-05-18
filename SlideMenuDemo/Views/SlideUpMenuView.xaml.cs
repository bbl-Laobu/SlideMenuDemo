using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using SlideMenuDemo.Pages;

namespace SlideMenuDemo.Views
{
    public partial class SlideUpMenuView : ContentView
    {
        static int tapSelectedPosition;

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

        void OnReceivedTappedAsync(object sender, EventArgs args)
        {
            tapSelectedPosition = 0;
            MessagingCenter.Send<SlideUpMenuView>(this, "UpdateTabMarker");
			MessagingCenter.Send<SlideUpMenuView>(this, "ReceivedClicked");
			MessagingCenter.Send<SlideUpMenuView>(this, "CloseSlideUpMenu");
        }

        void OnSentTappedAsync(object sender, EventArgs args)
        {
            tapSelectedPosition = 1;
            MessagingCenter.Send<SlideUpMenuView>(this, "UpdateTabMarker");
			MessagingCenter.Send<SlideUpMenuView>(this, "SentClicked");
			MessagingCenter.Send<SlideUpMenuView>(this, "CloseSlideUpMenu");
        }


        async Task updateTabMarker()
        {
            if (tapSelectedPosition == 0)
            {
                await MoveTabMarkerToReceived();
            }
            else
            {
                await MoveTabMarkerToSent();
            }
        }

        async Task MoveTabMarkerToReceived()
        {
            await tapSelectedMarker.TranslateTo(0, 0, 100);
            tapSelectedPosition = 0;
        }

        async Task MoveTabMarkerToSent()
        {
            var tapSelectedEndPos = recievedTap.Width / 2 + menuTap.Width + sentTap.Width / 2;
            await tapSelectedMarker.TranslateTo(tapSelectedEndPos, 0, 100);
            tapSelectedPosition = 1;
        }


		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new RotateAnimationPage());
		}
    }
}
