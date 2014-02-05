using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Infobip.Mpayments;

namespace mpaymentspaymentapixamarintest
{
	public class PurchaseListener : Java.Lang.Object, IPurchaseListener 
	{
		Button button;
		public PurchaseListener(Button btn) { button = btn; }

		#region IPurchaseListener implementation
		public void OnPurchaseCanceled (PurchaseResponse purchaseResponse) 
		{
			button.SetBackgroundColor (color: Android.Graphics.Color.Orange);
		}
		public void OnPurchaseFailed (PurchaseResponse purchaseResponse)
		{
			button.SetBackgroundColor (color: Android.Graphics.Color.Red);
		}
		public void OnPurchasePending (PurchaseResponse purchaseResponse)
		{
			button.SetBackgroundColor (color: Android.Graphics.Color.Blue);
		}
		public void OnPurchaseSuccess (PurchaseResponse purchaseResponse)
		{
			button.SetBackgroundColor (color: Android.Graphics.Color.Green);
		}
		#endregion
	}

	[Activity (Label = "mpayments-paymentapi-xamarin-test", MainLauncher = true)]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
            PurchaseRequest request = new Infobip.Mpayments.PurchaseRequest ("28550ec26491d4ed1b1de6fd3fe2b92a") {
				ClientId = "test1"
			};

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);

			button.Click += delegate {
				button.Text = string.Format ("{0}", count++);

				PurchaseManager.AttachPurchaseListener(new PurchaseListener(button));

				PurchaseManager.StartPurchase(request, this.ApplicationContext);
			};
		}
	}
}


