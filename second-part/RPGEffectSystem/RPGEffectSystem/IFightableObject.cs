namespace RPGEffectSystem
{
    public interface IFightableObject
    {
        // Calculates the effective damage the object can deal to other objects.
        float dealDamage(IFightableObject target, float bonusDamage);

        // Calculates how much damage an object would receive if it was attacked with given baseDamage.
        float receiveDamage(float baseDamage);
    }
}