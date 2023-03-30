using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;


[RequireComponent(typeof(VG_GoogleAdmob))]
public class VG_RequestADS : MonoBehaviour {

	VG_GoogleAdmob admob;

	public bool Interstitial;
	public bool RewardBasedVideo;

	public bool Banner;
	public AdPosition BannerPostion;

	


	void Start () {
		admob = GetComponent<VG_GoogleAdmob>();
		StartCoroutine(RequestAds());
	}
	
	public IEnumerator RequestAds(){
		yield return new WaitForSeconds(1f);
		if (RewardBasedVideo){
			admob.RequestRewardBasedVideo();
		}
		if (Interstitial){
			admob.RequestInterstitial();
		}
		if (Banner){
			admob.RequestBanner(BannerPostion);
		}
	}
	public void OnODUL(double OdulMiktari){
		Debug.Log("odulu aldik Miktar -> [ "+OdulMiktari+" ]");
	}
}