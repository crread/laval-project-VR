using UnityEngine;

[CreateAssetMenu(fileName = "Device", menuName = "Model/Device", order = 0)]
public class Device : ScriptableObject
{
    public int id;
    public new string name;
    public float powerWatt;
    public float consoKwhParAn;
    public float costKwh = 0.1893f;

    public int getCostParAn()
    {
        return Mathf.RoundToInt(costKwh * consoKwhParAn);
    }
}
