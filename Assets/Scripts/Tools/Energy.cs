using UnityEngine;

[CreateAssetMenu(fileName = "Energy", menuName = "Model/Energy", order = 0)]
public class Energy : ScriptableObject
{
    public int id;
    public new string name;
    public float TwhProduit;
    public float partDeMarcher;
}
