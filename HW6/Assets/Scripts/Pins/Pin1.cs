using UnityEngine;
using UnityEngine.UI;

public class Pin1 : MonoBehaviour, IPin
{
    private Text pin1Field;
    private int pin1FieldValue;

    private void Start()
    {
        pin1Field = GetComponentInChildren<Text>();
        if (pin1Field == null)
            throw new System.NotImplementedException($"No component Text in children {gameObject.name}");

        ResetPin();
    }

    public int GetPinValue() => pin1FieldValue;

    public void SetPin(int value)
    {
        pin1FieldValue += value;
        pin1Field.text = pin1FieldValue.ToString();
    }

    public void ResetPin()
    {
        pin1FieldValue = Random.Range(1, 10);
        pin1Field.text = pin1FieldValue.ToString();
    }
}
