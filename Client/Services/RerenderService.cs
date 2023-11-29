namespace STIMULUS_V2.Client.Services
{
    public class RerenderService
    {
        public event Action OnGroupeCreated;
        public event Action OnGrapheCreated;

        public void TriggerGroupeCreated()
        {
            OnGroupeCreated?.Invoke();
        }
        public void TriggerGrapheCreated()
        {
            OnGrapheCreated?.Invoke();
        }
    }
}
