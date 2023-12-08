namespace STIMULUS_V2.Client.Services
{
    public class RerenderService
    {
        public event Action OnGroupeCreated;
        public event Action OnGrapheCreated;
        public event Action OnGroupeDelete;
        public event Action OnGrapheDelete;
        public event Action OnNoeudStatus;
        public event Action OnEtudiantChanged;

        public void TriggerGroupeCreated()
        {
            OnGroupeCreated?.Invoke();
        }
        public void TriggerGrapheCreated()
        {
            OnGrapheCreated?.Invoke();
        }
        public void TriggerGrapheDelete()
        {
            OnGrapheDelete?.Invoke();
        }
        public void TriggerGroupeDelete()
        {
            OnGrapheDelete?.Invoke();
        }
        public void TriggerStatusNoeud()
        {
            OnNoeudStatus?.Invoke();
        }
        public void TriggerEtudiantChanged()
        {
            OnEtudiantChanged?.Invoke();
        }
    }
}
