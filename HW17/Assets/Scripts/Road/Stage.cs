using UnityEngine;

public enum STAGE : int {one = 1, two = 2, three = 3}
public static class Stage
{
    private const int lvl1 = -1;
    private const int lvl2 = 8;
    private const int lvl3 = 16;

    public static STAGE gameStage;

    public static void CheckStage() 
    {
        if (RoadBuilder.Instance.DelayedPlatformsCount > lvl1)
            gameStage = STAGE.one;
        if (RoadBuilder.Instance.DelayedPlatformsCount > lvl2)
            gameStage = STAGE.two;
        if (RoadBuilder.Instance.DelayedPlatformsCount > lvl3)
            gameStage = STAGE.three;
        StageDisplay.Instance.UpdateStageText();
    }
}


