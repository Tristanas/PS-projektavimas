namespace RPGVisitor
{
    interface IEffect
    {
        bool expire();
        float acceptVisitor(IEffectVisitor visitor);
        bool isNewEffect();
    }
}