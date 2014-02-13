# Centili in-app Payment Plugin for Xamarin
*only for Android platform*

This project is the Xamarin ([Xamarin](http://xamarin.com "Xamarin")) component which can be merged with your existing Xamarin project and enable you to use the Centili Mobile Payments system.

## Step By Step integration
1. Download our component and reference dll from _libs_ folder in your project (_Infobip.Mpayments.dll_).
2. Create a new _PurchaseRequest_ object in your code  (with the _ApiKey_ as only mandatory field).
 
		PurchaseRequest request = new Infobip.Mpayments.PurchaseRequest ("your-api-key-abc123abc123") {
			ClientId = "test1"
		};

3. Register your call-backs (_PurchaseListener_) by ``` PurchaseManager.AttachPurchaseListener(new MyPurchaseListener()); ``` where _MyPurchaseListener_ extends _Java.Lang.Object_ [[?](http://docs.xamarin.com/guides/android/advanced_topics/java_integration_overview/android_callable_wrappers/index.html#1.implementing-interfaces "Why must I extend Java.Lang.Object")] and implements the _Infobip.Mpayments.IPurchaseListener_ interface. It should contains these methods:

    	public void OnPurchaseCanceled (PurchaseResponse purchaseResponse)
    	{
    		// Your code goes here...
    	}
    	public void OnPurchaseFailed (PurchaseResponse purchaseResponse)
    	{
    		// Your code goes here...
    	}
    	public void OnPurchasePending (PurchaseResponse purchaseResponse)
    	{
    		// Your code goes here...
    	}
    	public void OnPurchaseSuccess (PurchaseResponse purchaseResponse)
    	{
    		// Your code goes here...
    	}
 
4. Call static method _PurchaseManager.StartPurchase(purchaseRequest, context)_.

    	PurchaseManager.StartPurchase(purchaseRequest, applicationContext);

5. Your call-back methods will be invoked upon completing the payment request. All you have to do is handle the payment result in your application (additional info is provided by the _PurchaseResponse_).

		public void OnPurchaseSuccess (PurchaseResponse purchaseResponse)
    	{
    		// Your code goes here...
			// ex: 
			this.Users.FindById(purchaseResponse.ClientId).AddCredit(purchaseResponse.ItemAmount);
    	}

## Additional methods

- You can *Infobip.Mpayments.Util.Logger*.*SetDebugModeEnabled(debugMode)* to 'true' or 'false' to get our logger output debug data. Defaults to 'false'.
- You can also set or un-set *PurchaseManager*.*PendingTransactionHandlingEnabled*, which will influence whether we will continue the pending payment when a new payment request is sent or start a new payment request. Default is 'true', which means that we will try to resume the unresolved transaction.

Owners
------

Framework Integration Team @ Infobip Belgrade, Serbia

*Android is a trademark of Google Inc.*

© 2013-2014, Infobip Ltd.