using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// enumeration for Level
public enum STAGE {Zero, One, Two, Three, Four, Five, Six}
public class Stage : MonoBehaviour
{
    public STAGE stage = STAGE.Zero;
    public static Stage instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void CheckStage(int platformsCountRemoved)
    {
        // change level depends on platforms removed count
        switch (platformsCountRemoved)
        {
            case 0:
                stage = STAGE.Zero;
                break;
            case 1:
                stage = STAGE.One;
                break;
            case 10:
                stage = STAGE.Two;
                break;
            case 20:
                stage = STAGE.Three;
                break;
            case 30:
                stage = STAGE.Four;
                break;
            case 40:
                stage = STAGE.Five;
                break;
            case 50:
                stage = STAGE.Six;
                break;
            default:
                break;
        }
    }
}

