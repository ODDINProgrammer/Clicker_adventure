using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] private Transform EnemySpawner;
    [SerializeField] private GameObject Enemy;
    
    [Header("Player parametrs")]
    [SerializeField] internal int MaxHP;
    internal int CurrentHP;
    
    [SerializeField] internal int MaxDamage;
    internal int CurrentDamage;
    
    [SerializeField] internal int MaxArmor;
    internal int CurrentArmor;
    
    internal int CurrentEXP;
    internal int Level;
    [SerializeField] internal int[] RequiredExpToLevel;
    
    
    [Header("Gold")]
    [SerializeField] internal int Gold;
    
    [Header("Statistics")]
    [SerializeField] internal int Enemieskilled;
    [SerializeField] private int ClicksDone;
    [SerializeField] private int ChestsFound;
    
    [Header("Accessors")]
    [SerializeField] internal UIHandler aUiHandler;
    [SerializeField] internal PowerUp aPOPupHandler;
    [SerializeField] internal HealthPotion aPotionHandler;
    [SerializeField] internal MenuScreenButtonHandler aButtonHandler;
    [SerializeField] private Transform aSpecialSpawner;
    [SerializeField] private Slider aHealthBar;
    [SerializeField] private GameObject aDeathScreen;
    [SerializeField] internal Button aPlayerButton;
    [SerializeField] internal WeaponChange aWeaponHandler;
    
    [Header("Chances")]
    
    [SerializeField] private int ChanceForChest;
   
    [Header("Audio")]
    [SerializeField] private AudioSource lvupsource;

    private void Start()
    {
        CurrentHP = MaxHP;
        aHealthBar.maxValue = MaxHP;
        aHealthBar.value = MaxHP;
        CurrentArmor = MaxArmor;

        CurrentDamage = MaxDamage;

        aUiHandler.UpdateUI();

        GenerateExpToLevel();
    }

    private void Update()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        // Enemy spawn handling
        if (Enemy == null)
        {
            //  GENERATE A CHANCE TO SPAWN A CHEST
            int random = Random.Range(0, 100);
            if (random <= ChanceForChest && ChanceForChest > 0)
            {
                //  RECORD INTO STATISTICS
                ChestsFound++;
                aSpecialSpawner.Find("Chest").gameObject.SetActive(true);
                return;
            }
            //  SPAWN A RANDOM ENEMY
            //  MAKE MORE ENEMIES AWAILABLE WITH HIGHER PLAYER LEVEL
            //  BY DEFAULT PICKS FROM FIRST 2 ENEMIES 
            //  RANDOM RANGE WITH INT WORKS AS FOLLOWS - RAND(MIN_VALUE, MAX_VALUE-1)
            int PickFrom = 0;
            int PickTo = 2;
            
            //  ADD FORTH ENEMY TYPE
            if (Level > 0 && Level <= 3)
                PickTo = 3;

            //  REMOVE FIRST ENEMY TYPE
            if (Level > 3 && Level <= 5)
            {
                PickFrom = 1;
                PickTo = 4;
            }
            
            //  REMOVE SECOND ENEMY TYPE
            if(Level > 5)
            {
                PickFrom = 2;
                PickTo = 4;
            }

            EnemySpawner.GetChild(Random.Range(PickFrom, PickTo)).gameObject.SetActive(true);
        }
    }

    public void Attack()
    {
        ClicksDone++;
        Enemy.GetComponent<Enemy>().TakeDamage(CurrentDamage);
    }
    internal void SetEnemy(GameObject _enemy)
    {
        Enemy = _enemy;
    }

    private void GenerateExpToLevel()
    {
        for (int i = 1; i < RequiredExpToLevel.Length; i++)
        {
            if (i > 2)
                RequiredExpToLevel[i] = RequiredExpToLevel[i - 1] + RequiredExpToLevel[i - 2];
            else
                RequiredExpToLevel[i] = RequiredExpToLevel[i - 1] + 20;
        }
    }


    internal void CountKill(int _exp, int _gold)
    {
        //  ADD EXP
        //  CHECK IF MAXIMUM LEVEL REACHED
        if (Level != RequiredExpToLevel.Length)
        {
            CurrentEXP += _exp;
            CheckForLevelUp();
        }

        //  ADD GOLD
        Gold += _gold;

        //  ADD STATISTICS
        Enemieskilled++;

        aUiHandler.UpdateUI();
    }
    private void CheckForLevelUp()
    {
        //  LEVEL UP ONLY IF WE ARE NOT AT MAXIMUM LEVEL
        if (CurrentEXP >= RequiredExpToLevel[Level] && Level < RequiredExpToLevel.Length)
        {
            lvupsource.Play();

            Level++;
            CurrentEXP = 0;

            MaxHP += 50;
            CurrentHP = MaxHP;
            aHealthBar.maxValue = MaxHP;
            aHealthBar.value = MaxHP;

            CurrentDamage++;
            MaxDamage++;

            aUiHandler.UpdateUI();
        }
    }

    internal void TakeDamage(int _damage)
    {
        int damage_to_take = CurrentArmor - _damage;

        //  ENEMY ATTACK IS HIGHER THAN ARMOR RATING
        if(damage_to_take < 0)
        {
            CurrentHP -= Mathf.Abs(damage_to_take);
        }

        if (CurrentHP <= 0)
        {
            CurrentHP = 0;
            aDeathScreen.SetActive(true);
        }

        aHealthBar.value = CurrentHP;
        aUiHandler.UpdateUI();
    }

    internal void ModifyHP(int _value)
    {
        CurrentHP += _value;

        if (CurrentHP > MaxHP)
            CurrentHP = MaxHP;

        aHealthBar.value = CurrentHP;
        aUiHandler.UpdateUI();
    }
}
