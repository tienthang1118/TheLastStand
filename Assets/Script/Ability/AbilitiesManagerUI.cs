using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesManagerUI : MonoBehaviour
{
    [Header("Abilities window")]
    [SerializeField]
    private GameObject abilitiesWindow;

    [SerializeField]
    private List<UpgradeSection> upgradeSections;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DisplayAbilitiesWindow(bool isDisplay)
    {
        abilitiesWindow.SetActive(isDisplay);
    }
    public void UpdateUpgreadeSectionUI(List<UpgradeData> upgradeDatas)
    {
        for(int i = 0; i < upgradeDatas.Count; i++)
        {
            upgradeSections[i].Set(upgradeDatas[i]);
        }
    }
}
