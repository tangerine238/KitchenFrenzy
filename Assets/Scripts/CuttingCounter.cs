using UnityEngine;
using System;
public class CuttingCounter : BaseCounter
{

    [SerializeField] private KitchenObjectSO cutKitchenObjectSO;


    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {

            }
        }
        else
        {
            if (player.HasKitchenObject())
            {

            }
            else
            {
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

    public override void InteractAlternate(Player player)
    {
        if (HasKitchenObject())
        {
            GetKitchenObject().DestroySelf();

            Transform kitchenObjectTransform = Instantiate(cutKitchenObjectSO.prefab);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
        }
    }
}
