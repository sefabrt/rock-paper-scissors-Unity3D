using System.Collections;
using UnityEngine;

public class OnEnabledAndDisabledADMOB : MonoBehaviour {
	public float delaySecond;
	public ButtonAdmobType ShowType;
	private void OnEnable(){
		StartCoroutine(DelayOnEnabled());
	}
	public IEnumerator DelayOnEnabled(){
		yield return new WaitForSeconds(delaySecond);
		switch (ShowType){
			case ButtonAdmobType.RewardBasedVideo:
				FindObjectOfType<VG_GoogleAdmob>().ShowRewardBasedVideo();
			break;
			case ButtonAdmobType.Interstitial:
				FindObjectOfType<VG_GoogleAdmob>().ShowInterstitial();
			break;
		}
	}
}