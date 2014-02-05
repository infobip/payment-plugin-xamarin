# Centili Mobile Payments for Xamarin
This project is Xamarin ([Xamarin](http://xamarin.com "Xamarin")) component which can be merged with your Xamarin project and enable you to use Centili Mobile Payments system.

## Step By Step integration
1. Download our component and reference dll from _libs_ folder in your project (_Infobip.Mpayments.dll_).
2. In your code make new _PurchaseRequest_ object (with _ApiKey_ as only mandatory field).
 
		PurchaseRequest request = new Infobip.Mpayments.PurchaseRequest ("your-api-key-abc123abc123") {
			ClientId = "test1"
		};

3. Register your callbacks (_PurchaseListener_) by ``` PurchaseManager.AttachPurchaseListener(new MyPurchaseListener()); ``` where _MyPurchaseListener_ extends _Java.Lang.Object_ [[?](http://docs.xamarin.com/guides/android/advanced_topics/java_integration_overview/android_callable_wrappers/index.html#1.implementing-interfaces "Why must I extend Java.Lang.Object")] and implements interface _Infobip.Mpayments.IPurchaseListener_. It should have these methods:

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

5. Your callback methods will be invoked upon completing payment request. All you have to do is handle payment result in your application (additional info is provided by _PurchaseResponse_).

		public void OnPurchaseSuccess (PurchaseResponse purchaseResponse)
    	{
    		// Your code goes here...
			// ex: 
			this.Users.FindById(purchaseResponse.ClientId).AddCredit(purchaseResponse.ItemAmount);
    	}

## Additional methods

- You can *Infobip.Mpayments.Util.Logger*.*SetDebugModeEnabled(debugMode)* to true or false to get our logger output debug data. Defaults to false.
- You can also set or unset *PurchaseManager*.*PendingTransactionHandlingEnabled*, which will influence whether will we continue pending payment when new payment request is sent, or will we start a new payment request. Default is true, which means that we will try to resume unresolved transaction.

## Authors
Framework Integration Team @ Infobip Belgrade, Serbia
Copyright 2013-2014 Infobip Ltd. 
