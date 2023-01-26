using UnityEngine;
using UnityEngine.UI;

public class Pin2 : MonoBehaviour, IPin
{
    private Text pin2Field;
    private int pin1FieldValue;

    private void Start()
    {
        pin2Field = GetComponentInChildren<Text>();
        if (pin2Field == null)
            throw new System.NotImplementedException($"No component Text in children {gameObject.name}");

        ResetPin();
    }

    public int GetPinValue() => pin1FieldValue;

    public void SetPin(int value)
    {
        pin1FieldValue += value;
        pin2Field.text = pin1FieldValue.ToString();
    }

    public void ResetPin()
    {
        pin1FieldValue = Random.Range(1, 10);
        pin2Field.text = pin1FieldValue.ToString();
    }
}
