using UnityEngine;

public class Character
{
    public string name;
    public int level;

    public Character(string name, int level)
    {
        this.name = name;
        this.level = level;
    }

    public virtual void PrintStatsInfo()
    {
        Debug.Log($"Character: {name}, Level: {level}");
    }
}

public struct Weapon
{
    public string weaponName;
    public int damage;

    public Weapon(string weaponName, int damage)
    {
        this.weaponName = weaponName;
        this.damage = damage;
    }
}

public class Paladin : Character
{
    public Weapon weapon;

    public Paladin(string name, int level, Weapon weapon) : base(name, level)
    {
        this.weapon = weapon;
    }

    public override void PrintStatsInfo()
    {
        Debug.Log($"Paladin: {name}, Level: {level}, Weapon: {weapon.weaponName} ({weapon.damage} dmg)");
    }
}
