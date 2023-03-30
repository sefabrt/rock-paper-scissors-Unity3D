using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BGMManager : MonoBehaviour
{
    [SerializeField] Image on, off;
    private bool muted = false;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }
        UpdateOnOffIcon();
        AudioListener.pause = muted;
    }
    public void OnButtonPress()
    {
        if (!muted)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }
        Save();
        UpdateOnOffIcon();
    }
    private void UpdateOnOffIcon()
    {
        on.enabled = muted ? false : true;
        off.enabled = muted ? true : false;
    }
    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }
    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }

}
