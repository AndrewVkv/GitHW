using UnityEngine;
using TMPro;

public class Swipe : MonoBehaviour
{
    private const string TAP = "Tap";
    private const string INCREASE = "Жест увеличение";
    private const string SWIPERIGHT = "Свайп вправо";

    [SerializeField]
    private TextMeshProUGUI tmp;
    private Vector2 startPos;
    float startDistance;
    float movedDistance;

    private void Start()
    {
        tmp.text = string.Empty;
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 secondTouchPos = new Vector2(150f, 150f);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos.x = touch.position.x;
                    startPos.y = touch.position.y;
                    tmp.text = TAP;

                    startDistance = Vector2.Distance(startPos, secondTouchPos);
                    break;

                case TouchPhase.Moved:
                    movedDistance = Vector2.Distance(touch.position, secondTouchPos);
                    if ((movedDistance - startDistance) > 0)
                        tmp.text = INCREASE;
                    break;

                case TouchPhase.Stationary:
                    break;

                case TouchPhase.Ended:
                    if (touch.position.x - startPos.x > 100f && Mathf.Abs(touch.position.y - startPos.y) < 50f)
                        tmp.text = SWIPERIGHT;
                    break;

                case TouchPhase.Canceled:
                    break;

                default:
                    break;
            }
        }
    }
}
