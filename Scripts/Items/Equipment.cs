using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Equipment", menuName ="Inventory/Equipment")]
public class Equipment : Item {

    public EquipmentSLot equipSlot;
    public SkinnedMeshRenderer mesh;
    public EquipmentMeshRegion[] coverredMeshRegions;

    public int armourModifier;
    public int damageModifier;

    public override void Use()
    {
        base.Use();
        //Equips item
        EquipmentManager.instance.Equip(this);
        //Removes from inventory
        RemoveFromInventory();

    }

}

public enum EquipmentSLot { Head, Chest, Legs, Weapon, Shield, Feet }
public enum EquipmentMeshRegion {Legs, Arms, Torso }; //Corresponds to body blendshapes
