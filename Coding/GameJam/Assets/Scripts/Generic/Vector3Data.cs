using UnityEngine;

[CreateAssetMenu]

public class Vector3Data : ScriptableObject
{
    public Vector3 value;

    public void SetValue(Vector3Data incomingValue)
    {
        value = incomingValue.value;
    }
}
