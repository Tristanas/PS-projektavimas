namespace RPGVisitor
{
    interface IEffect
    {
        bool expire();
        bool acceptVisitor(IEffectVisitor visitor);
        bool isNewEffect();
    }
}