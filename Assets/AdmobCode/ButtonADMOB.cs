using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonADMOB : MonoBehaviour, IPointerClickHandler
{

	public ButtonAdmobType buttonType;
    public void OnPointerClick(PointerEventData pointerEventData){
		
		switch (buttonType){
			case ButtonAdmobType.RewardBasedVideo:
				FindObjectOfType<VG_GoogleAdmob>().ShowRewardBasedVideo();
			break;
			case ButtonAdmobType.Interstitial:
				FindObjectOfType<VG_GoogleAdmob>().ShowInterstitial();
			break;
		}
    }
}
public enum ButtonAdmobType
{
	Interstitial,RewardBasedVideo
}