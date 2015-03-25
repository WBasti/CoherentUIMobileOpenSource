package com.coherentlabs.ui;

import android.util.DisplayMetrics;
import android.webkit.JavascriptInterface;
import android.webkit.WebView;

public class CoherentJavaScriptInterface {
	public static final String INTERFACE_NAME = "__couiAndroid";
	private WebView mWebView;
	private float mDPtoPXCoef;

	public CoherentJavaScriptInterface(WebView webView) {
		mWebView = webView;
		
		DisplayMetrics displayMetrics = webView.getContext().getResources().getDisplayMetrics();
		mDPtoPXCoef = displayMetrics.densityDpi / 160.0f;
	}

	@JavascriptInterface
	public String initCoui() {
		return "window.engine = window.engine || {};";
	}
	
	@JavascriptInterface
	public void addTouchEvent(int fingerId, int phase, int x, int y) {
		addCoherentTouchEvent(mWebView.getId(), fingerId, phase, (int)(x * mDPtoPXCoef), (int)(y * mDPtoPXCoef));
	}
	
	public native void addCoherentTouchEvent(int id, int fingerId, int phase, int x, int y);
}
