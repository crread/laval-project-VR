using UnityEngine;

public class EnergyDisplay : MonoBehaviour
{
    [SerializeField] private Energy myEnergy;
    private void Start()
    {
        Debug.Log(myEnergy.name);
        Debug.Log(myEnergy.partDeMarcher);
    }
}
