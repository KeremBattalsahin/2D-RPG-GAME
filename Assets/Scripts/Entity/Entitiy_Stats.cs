
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Entity_Stats : MonoBehaviour
{
    public Stat maxHealth;
    public Stat_MajorGroup major;
    public Stat_OffensiveGroup offense;
    public Stat_DefenseGroup deffense;

    public float GetElementalDamage(out ElementType element, float scaleFactor = 1)
    {
        float fireDamage = offense.fireDamage.GetValue();
        float iceDamage = offense.iceDamage.GetValue();
        float lightningDamage = offense.lightningDamage.GetValue();
        float bonusElementalDamage = major.intelligience.GetValue();

        float highestDamage = fireDamage;
        element = ElementType.Fire;

        if(iceDamage > highestDamage)
        {
            highestDamage = iceDamage;
            element = ElementType.Ice;
        }
        

        if(lightningDamage > highestDamage)
        {
            highestDamage = lightningDamage;
            element = ElementType.Lightning;
        }
        

        if (highestDamage <= 0)
        {
            element = ElementType.None;
            return 0;
        }
        

        float bonusFire = (fireDamage == highestDamage) ? 0 : fireDamage * .5f;
        float bonusIce = (iceDamage == highestDamage) ? 0 : iceDamage * .5f;
        float bonusLight = (lightningDamage == highestDamage) ? 0 : lightningDamage * .5f;

        float weakerElementDamage = bonusFire + bonusIce + bonusLight;

        float finalDamage = highestDamage + weakerElementDamage + bonusElementalDamage;

        return finalDamage * scaleFactor;
    }

    public float GetElementalResistance(ElementType element)
    {
        float baseResistance = 0;
        float bonusResistance = major.intelligience.GetValue() * .5f;

        switch (element)
        {
            case ElementType.Fire:
            baseResistance = deffense.fireRes.GetValue();
            break;

            case ElementType.Ice:
            baseResistance = deffense.iceRes.GetValue();
            break;

            case ElementType.Lightning:
            baseResistance = deffense.lightningRes.GetValue();
            break;
        }

        float resistance = baseResistance+ bonusResistance;
        float resistanceCap = 75f;
        float finalResistance = Mathf.Clamp(resistance,0,resistanceCap) / 100;

        return finalResistance;
    }

    public float GetPhysicalDamage(out bool isCrit,float scaleFactor = 1)
    {
        float baseDamage = offense.damage.GetValue();
        float bonusDamage = major.strength.GetValue();
        float totalBaseDamage = baseDamage + bonusDamage;

        float baseCritChance = offense.criticChance.GetValue();
        float bonusCritChance = major.agility.GetValue() * .3f;
        float critChance = baseCritChance + bonusCritChance;

        float baseCritPower = offense.criticPower.GetValue();
        float bonusCritPower = major.strength.GetValue() * .5f;
        float critPower = (baseCritPower + bonusCritPower) / 100;

         isCrit = Random.Range(0,100) < critChance;
        float finalDamage = isCrit ? totalBaseDamage * critPower : totalBaseDamage;

        return finalDamage * scaleFactor;
    }
    
    public float GetArmorMitigation(float armorReduction)
    {
        float baseArmor = deffense.armor.GetValue();
        float bonusArmor = major.vitality.GetValue();
        float totalArmor = baseArmor + bonusArmor;

        float reductionMultiplier = Mathf.Clamp(1 - armorReduction,0,1);
        float effectiveArmor = totalArmor * reductionMultiplier;

        float mitigation = effectiveArmor / (effectiveArmor + 100);
        float mitigationCap = .85f;

        float finalMitigation = Mathf.Clamp(mitigation,0,mitigationCap);

        return finalMitigation;
        
    }

    public float GetArmorReduction()
    {
        float finalReduction = offense.armorReduction.GetValue() / 100;
        return finalReduction;
    }
    
    

    public float GetEvasion()
    {
        float baseEvasion = deffense.evasion.GetValue();
        float bonusEvasion = major.agility.GetValue() * .5f;

        float totalEvasion = baseEvasion + bonusEvasion;
        float evasionCap = 85f;

        float finalEvasion = Mathf.Clamp(totalEvasion,0,evasionCap);

        return finalEvasion;
    }

    public float GetMaxHealth()
    {
        float baseMaxHealth = maxHealth.GetValue();
        float bonusMaxHealth = major.vitality.GetValue() * 5;

        float finalMaxHealth = baseMaxHealth + bonusMaxHealth;

        return finalMaxHealth;
    } 
}
