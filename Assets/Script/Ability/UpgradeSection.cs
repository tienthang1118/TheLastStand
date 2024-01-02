using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeSection : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI summary;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Set(UpgradeData upgradeData)
    {
        icon.sprite = upgradeData.Icon;
        summary.text = upgradeData.Summary;
    }
}
