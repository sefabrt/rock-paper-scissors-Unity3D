using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMusic : MonoBehaviour
{
    private static BgMusic bgmusic;
    private void Awake()
    {
        if (bgmusic == null)
        {
            bgmusic = this;
            DontDestroyOnLoad(bgmusic);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
