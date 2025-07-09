using UnityEngine;

public class RewardsController : MonoBehaviour
{
    public static RewardsController Instance { get; private set; }

    [SerializeField]
    private Animator playerAnimator;
    [SerializeField]
    private HealthUI healthUI;
    [SerializeField]
    private PlayerHealth playerHealth;
    [SerializeField]
    private Weapon weapon;
    [SerializeField]
    private FogoPlayer fogoPlayer;
    public GameObject howToFireScreen;
    public GameObject waypointPhase2;
    public GameObject waypointPhase3;
    public GameObject waypointPhase4;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void GiveQuestReward(Quest quest)
    {
        if (quest?.questRewards == null) return;

        foreach (var reward in quest.questRewards)
        {
            switch (reward.type)
            {
                case RewardType.Item:
                    GiveItemReward(reward.rewardID, reward.amount);
                    break;
                case RewardType.Gold: //habilidade de fogo
                    fogoPlayer.enabled = true;
                    howToFireScreen.SetActive(true);
                    PauseController.SetPause(true);
                    waypointPhase4.SetActive(true);
                    break;
                case RewardType.Experience: //adicionar 1 coracao
                    playerHealth.maxHealth = 5;
                    healthUI.SetMaxHearts(5);
                    playerHealth.SetCurrentHealth(5);
                    waypointPhase3.SetActive(true);
                    break;
                case RewardType.Custom: //pode ser cutscene (usada para receber lanca atualmente)
                    playerAnimator.SetBool("Arma", true);
                    weapon.damage = 3;
                    waypointPhase2.SetActive(true);
                    break;
            }
        }
    }

    public void GiveItemReward(int itemID, int amount)
    {
        var itemPrefab = FindAnyObjectByType<ItemDictionary>()?.GetItemPrefab(itemID);

        if (itemPrefab == null) return;

        for (int i = 0; i < amount; i++)
        {
            if (!InventoryController.Instance.AddItem(itemPrefab))
            {
                GameObject dropItem = Instantiate(itemPrefab, transform.position + Vector3.down, Quaternion.identity);
                //dropItem.GetComponent<BounceEffect>().StartBounce();
            }
            else
            {
                itemPrefab.GetComponent<Item>().ShowPopUp();
            }
        }
    }
}
