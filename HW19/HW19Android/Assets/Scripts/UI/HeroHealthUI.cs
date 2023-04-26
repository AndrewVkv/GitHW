using UnityEngine;
using UnityEngine.UI;

public class HeroHealthUI : MonoBehaviour
{
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;
    private int heartsLength;


    private void Awake()
    {
        heartsLength = transform.childCount;
        hearts = new Image[heartsLength];

        for (int i = 0; i < heartsLength; i++)
        {
            hearts[i] = transform.GetChild(i).GetComponent<Image>();
        }        
    }

    public void UpdateHearts(int value) 
    {
        for (int i = 0; i < heartsLength; i++)
        {
            if(i < value)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;
        }
    }
}
