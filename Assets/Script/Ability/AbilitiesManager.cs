using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesManager : MonoBehaviour
{
    private PlayerStats playerStats;
    private AbilitiesManagerUI abilitiesManagerUI;
    [SerializeField]
    private List<UpgradeData> upgrades;
    private List<UpgradeData> randomUpgrades;

    private void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        abilitiesManagerUI = FindObjectOfType<AbilitiesManagerUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DisplayAbilitiesWindow(bool isDisplay)
    {
        abilitiesManagerUI.DisplayAbilitiesWindow(isDisplay);
    }
    public IEnumerator ChooseAbility()
    {
        Time.timeScale = 0f;
        randomUpgrades = new List<UpgradeData>();
        randomUpgrades = GetUpgrades(2);
        abilitiesManagerUI.UpdateUpgreadeSectionUI(randomUpgrades);
        DisplayAbilitiesWindow(true);
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Upgrade(randomUpgrades[0]);
                break;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Upgrade(randomUpgrades[1]);
                break;
            }
            yield return null;
        }
        DisplayAbilitiesWindow(false);
        Time.timeScale = 1f;
    }
    public List<UpgradeData> GetUpgrades(int count)
    {
        List<UpgradeData> upgradeList = new List<UpgradeData>();
        
        int number1, number2;
        do
        {
            number1 = Random.Range(0, upgrades.Count);
            number2 = Random.Range(0, upgrades.Count);
        }
        while (number1 == number2);

        upgradeList.Add(upgrades[number1]);
        upgradeList.Add(upgrades[number2]);

        return upgradeList;
    }
    public void Upgrade(UpgradeData selectedUpgradeData)
    {
        switch (selectedUpgradeData.Ability)
        {
            case Abilities.IncreaseATSD:
                playerStats.IncreaseATSD(selectedUpgradeData.StatIncreasePercent);
                break;
            case Abilities.IncreaseDMG:
                playerStats.IncreaseDMG(selectedUpgradeData.StatIncreasePercent);
                break;
        }
    }
}
