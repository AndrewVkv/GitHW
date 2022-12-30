using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayInventory : MonoBehaviour
{
    private readonly string goText = "Go!";
    private readonly int stopCount = 0;

    public static DisplayInventory Instance;
    public Text coinText;
    public Text bulletText;
    public Text timerText;
    public Image[] hearts = new Image[3];
    public Sprite life, noLife;

    private Inventory inventory;
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }
    private void Start()
    {
        if (Inventory.Instance != null)
            inventory = Inventory.Instance;
        UpdateCoinText();
        UpdateBulletText();
        EventBus.eCoinCollision.AddListener(UpdateCoinText);
        UpdateHP();
        EventBus.eObstacleCollision.AddListener(UpdateHP);
        EventBus.eFalling.AddListener(UpdateHP);

        StartCoroutine(StartTimer());
    }

    public void UpdateCoinText()
    {
        coinText.text = inventory.GetCoins().ToString();
    }
    public void UpdateBulletText()
    {
        bulletText.text = inventory.GetBullets().ToString();
    }
    private void UpdateHP() 
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if(inventory.GetHP() > i)
                hearts[i].sprite = life;
            else
                hearts[i].sprite = noLife;
        }
    }
    private IEnumerator StartTimer() 
    {
        int counter = 3;
        while (counter > stopCount)
        {
            timerText.text = counter.ToString();
            yield return new WaitForSeconds(1);
            counter--;

            if (counter == 1)
            {
                TimerColor.Instance.ChangeTimerColor(IMCOLOR.orange);
                EventBus.ready?.Invoke();
            }

        }
        TimerColor.Instance.ChangeTimerColor(IMCOLOR.green);
        timerText.text = goText;
        EventBus.go?.Invoke();

        yield return new WaitForSeconds(1);
        TimerColor.Instance.ChangeTimerColor(IMCOLOR.invisible);
        timerText.text = string.Empty;
        StageDisplay.Instance.SetStagePannel(true);
        StopCoroutine(StartTimer());
    }
}
