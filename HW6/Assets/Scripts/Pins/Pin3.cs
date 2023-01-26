using UnityEngine;
using UnityEngine.UI;

public class Pin3 : MonoBehaviour, IPin
{
    private Text pin3Field;
    private int pin1FieldValue;

    private void Start()
    {
        pin3Field = GetComponentInChildren<Text>();
        if (pin3Field == null)
            throw new System.NotImplementedException($"No component Text in children {gameObject.name}");

        ResetPin();
    }

    public int GetPinValue() => pin1FieldValue;

    public void SetPin(int value)
    {
        pin1FieldValue += value;
        pin3Field.text = pin1FieldValue.ToString();
    }

    public void ResetPin()
    {
        pin1FieldValue = Random.Range(1, 10);
        pin3Field.text = pin1FieldValue.ToString();
    }
}