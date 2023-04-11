using Codebase.Systems.MVC;
using UniRx;
using UnityEngine;

namespace Codebase.ComponentScripts.Vehicle.View
{
    public class VehicleHpView : BaseView
    {
        [SerializeField] private int hp;
        [SerializeField] private int armor;
        
        public override void Construct()
        {
            //do some visual shit!
        }

        public void BindHpChanging(IReadOnlyReactiveProperty<int> currentHp, IReadOnlyReactiveProperty<int> currentArmor)
        {
            currentHp
                .Subscribe(HandleHpChanging)
                .AddTo(CompositeDisposable);

            currentArmor
                .Subscribe(HandleAmmoChanging)
                .AddTo(CompositeDisposable);
        }

        private void HandleHpChanging(int currentHp)
        {
            hp = currentHp;
        }

        private void HandleAmmoChanging(int currentAmmo)
        {
            armor = currentAmmo;
        }
    }
}