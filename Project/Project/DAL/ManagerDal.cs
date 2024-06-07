namespace Project.DAL
{
    public class ManagerDal:IManagerDal
    {
        private readonly Context Context;

        public ManagerDal(Context Context)
        {
            this.Context = Context;
        }
        public async Task<bool> CheckManager(string ManName, int Password)
        {
            var manager = Context.Managers.FirstOrDefault(c => c.Name==ManName&&c.Password==Password);
            await Task.Delay(100);
            if (manager == null)
            {
               //throw new Exception($"manager {ManName} not found");
                return false;
            }
            return true;
        }

    }
}
