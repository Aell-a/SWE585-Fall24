using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoldierManager : MonoBehaviour
{
    public GameObject soldierPrefab;
    public TextMeshProUGUI soldierCountText;
    public Button increaseButton, decreaseButton;

    private int soldierCount = 0; // Current soldier count
    private readonly int[] soldierSteps = { 1, 5, 10, 15, 25, 50, 100 }; // Steps for soldier count
    private int currentStepIndex = 0; // Current index in soldierSteps array

    private Transform soldiersParent; // Parent object for soldiers

    void Start()
    {
        // Create a parent object to organize soldiers
        soldiersParent = new GameObject("SoldiersParent").transform;

        // Set up button listeners
        increaseButton.onClick.AddListener(IncreaseSoldierCount);
        decreaseButton.onClick.AddListener(DecreaseSoldierCount);

        // Initialize the soldiers
        UpdateSoldierCount();
    }

    void IncreaseSoldierCount()
    {
        if (currentStepIndex < soldierSteps.Length - 1)
        {
            currentStepIndex++;
            UpdateSoldierCount();
        }
    }

    void DecreaseSoldierCount()
    {
        if (currentStepIndex > 0)
        {
            currentStepIndex--;
            UpdateSoldierCount();
        }
    }

    void UpdateSoldierCount()
    {
        int targetCount = soldierSteps[currentStepIndex];

        // Adjust soldiers to match the target count
        if (targetCount > soldierCount)
        {
            SpawnSoldiers(targetCount - soldierCount);
        }
        else if (targetCount < soldierCount)
        {
            RemoveSoldiers(soldierCount - targetCount);
        }

        // Update the current soldier count
        soldierCount = targetCount;
        UpdateSoldierUI();
    }

    void SpawnSoldiers(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 spawnPosition = new Vector3(soldiersParent.childCount, 0, 0); // Increment on X-axis
            Instantiate(soldierPrefab, spawnPosition, Quaternion.identity, soldiersParent);
        }
    }

    void RemoveSoldiers(int count)
    {
        int soldiersToRemove = Mathf.Min(count, soldiersParent.childCount);

        for (int i = 0; i < soldiersToRemove; i++)
        {
            Transform lastSoldier = soldiersParent.GetChild(soldiersParent.childCount - 1);
            DestroyImmediate(lastSoldier.gameObject); // Use DestroyImmediate to ensure immediate removal
        }

        // Adjust soldierCount to reflect the actual removal
        soldierCount -= soldiersToRemove;
    }

    void UpdateSoldierUI()
    {
        // Update the UI text with the current soldier count
        soldierCountText.text = $"Soldiers: {soldierCount}";
    }
}