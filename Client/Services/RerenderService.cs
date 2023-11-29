namespace STIMULUS_V2.Client.Services
{
    public class RerenderService
    {
        public event Action OnGroupeCreated;
        public event Action OnGrapheCreated;
        public event Action OnGroupeDelete;
        public event Action OnGrapheDelete;

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
    }
}
