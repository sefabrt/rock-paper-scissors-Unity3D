using UnityEngine;

public class UnikDontDestroy : MonoBehaviour {
	private void Awake() {
		if (FindObjectsOfType<UnikDontDestroy>().Length > 1)
		{
			Destroy(gameObject);
		}else{
			DontDestroyOnLoad(this);
		}	
	}
}
