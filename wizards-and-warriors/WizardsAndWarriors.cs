using System;

abstract class Character
{
    public string Type { get; }

    protected Character(string type)
    {
        Type = type;
    }

    public virtual bool Vulnerable() => false;

    public abstract int DamagePoints(Character target);

    public override string ToString() => $"Character is a {Type}";
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target) => target.Vulnerable() ? 10 : 6;
}

class Wizard : Character
{
    public bool PreparedSpell = false;

    public Wizard() : base("Wizard")
    {
    }

    public void PrepareSpell() => PreparedSpell = true;

    public override bool Vulnerable() => !PreparedSpell;

    public override int DamagePoints(Character target) => PreparedSpell ? 12 : 3;
}
