using UnityEngine;

public class DeviceDisplay : MonoBehaviour
{
    [SerializeField] private Device myDevice;

    private void Start()
    {
        Debug.Log(myDevice.name);
        Debug.Log(myDevice.getCostParAn());
    }
}
