using Codebase.ComponentScripts.Vehicle.Model;
using Codebase.ComponentScripts.Vehicle.View;
using Codebase.Systems.MVC;
using UniRx;

namespace Codebase.ComponentScripts.Vehicle.Controller
{
    public class VehicleHpController : BaseController<VehicleHpView>
    {
        public IReadOnlyReactiveProperty<bool> IsAlive => _isAlive;
        public IReadOnlyReactiveProperty<int> CurrentHP => _currentHp;
        public IReadOnlyReactiveProperty<int> CurrentArmor => _currentArmor;

        private readonly VehicleHpView _hitpointsView;
        
        private IReactiveProperty<int> _currentHp;
        private IReactiveProperty<int> _currentArmor;
        private IReactiveProperty<bool> _isAlive;

        public VehicleHpController(
            VehicleHpView viewContract,
            VehicleHPModel model)
            : base(viewContract)
        {
            _currentHp = new ReactiveProperty<int>(model.HitPoints);
            _currentArmor = new ReactiveProperty<int>(model.Armor);
            _isAlive = new ReactiveProperty<bool>(true);
            _hitpointsView = viewContract;
        }

        protected override void Initialize()
        {
            _hitpointsView.BindHpChanging(CurrentHP, CurrentArmor);
        }

        public void AddDamage(int damage)
        {
            if (_isAlive.Value == false) return;

            var remainingDamage = ArmorDamage(damage);
            
            if (remainingDamage > 0) return;

            HitPointsDamage(remainingDamage);
        }

        private int ArmorDamage(int damage)
        {
            if (damage >= _currentArmor.Value)
            {
                damage -= _currentArmor.Value;
                _currentArmor.Value = 0;
                return damage;
            }
            
            _currentArmor.Value -= damage;
            return 0;
        }

        private void HitPointsDamage(int damage)
        {
            if (damage >= _currentHp.Value)
            {
                _currentHp.Value = 0;
                _isAlive.Value = false;
            }
            
            _currentHp.Value -= damage;
        }
    }
}