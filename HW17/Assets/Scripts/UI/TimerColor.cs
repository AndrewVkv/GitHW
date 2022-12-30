using UnityEngine;
using UnityEngine.UI;

public enum IMCOLOR {red, orange, green, invisible };
public class TimerColor : MonoBehaviour
{
    public static TimerColor Instance;
    private Image imageColor;
    public Color32[] colors = new Color32[3];
    public IMCOLOR colorIm = IMCOLOR.red;

    private void Start()
    {
        if (Instance == null)
            Instance = this;

        imageColor = GetComponent<Image>();
        imageColor.color = colors[0];
    }
    public void ChangeTimerColor(IMCOLOR col) 
    {
        switch (col)
        {
            case IMCOLOR.red: imageColor.color = colors[0]; break;
            case IMCOLOR.orange: imageColor.color = colors[1]; break;
            case IMCOLOR.green: imageColor.color = colors[2]; break;
            case IMCOLOR.invisible: imageColor.color = colors[3]; break;

            default:
                break;
        }
    }
}
