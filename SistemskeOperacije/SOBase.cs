using DBBroker;

namespace SistemskeOperacije
{
    public abstract class SOBase
    {
        protected Broker broker;

        public SOBase()
        {
            broker = new Broker();
        }


        public void ExecuteTemplate()
        {
            try
            {
                broker.OpenConnection();
                broker.BeginTransaction();

                ExecuteConcreteOperation();

                broker.Commit();
            }
            catch (Exception ex)
            {
                broker.RollBack();
                throw;
            }
            finally
            {
                broker.CloseConnection();
            }
        }
        protected abstract void ExecuteConcreteOperation();

    }
}
