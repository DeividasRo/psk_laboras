using System;
using System.Collections.Generic;
using System.Linq;

public class Enemy
{
    private int hp;
    private string enemyName;
    private readonly float maxSpeed = 10.0f;
    private List<string> drop_items;
    public bool isAlive;
    readonly int BaseDamage;
    private float movementSpeed;
    private int burnTicks = 0;

    public Enemy(string name, int hp, float speed, bool isHostile, string faction,
        int armor, int magicResist, int level, List<string> items, bool respawnable)
    {
        enemyName = name;
        health_points = hp;
        movementSpeed = Math.Min(speed, maxSpeed);
        drop_items = items ?? new List<string>();
        BaseDamage = 10;
        isAlive = true;
    }

    public void ProcessDamageAndUpdateState(int damageAmount, string damageType, bool isCritical)
    {
        float finalDamage = damageAmount;

        if (isCritical)
            finalDamage *= 1.5f;

        if (damageType == "fire")
        {
            finalDamage *= 1.2f;
            ApplyBurningEffect();
        }

        health_points -= (int)finalDamage;

        if (health_points <= 0)
        {
            isAlive = false;
            DropLoot();
        }
    }

    private void applyBurningEffect()
    {
        burnTicks = 3;
        movementSpeed *= 0.8f;

        for (int i = 0; i < burnTicks; i++)
        {
            health_points -= 5;
        }
    }

    private void DropLoot()
    {
        if (drop_items.Any())
        {
          Random rng = new Random();
          foreach (string item in drop_items.Where(item => rng.Next(100) < 30))
          {
              drop_items.Remove(item);
          }
        }
    }

    public int IsEnemyDangerous()
    {
        return BaseDamage > 20 ? 1 : 0;
    }

    public float GetCurrentSpeed()
    {
        return movementSpeed;
    }

    public void Heal(int amount)
    {
        if (!isAlive) return;
        health_points += amount;
    }
}
