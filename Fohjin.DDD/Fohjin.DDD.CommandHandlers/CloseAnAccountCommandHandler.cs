using Fohjin.DDD.Commands;
using Fohjin.DDD.Domain.Entities;
using Fohjin.EventStorage;

namespace Fohjin.DDD.CommandHandlers
{
    public class CloseAnAccountCommandHandler : ICommandHandler<CloseAnAccountCommand>
    {
        private readonly IRepository<ActiveAccount> _repository;

        public CloseAnAccountCommandHandler(IRepository<ActiveAccount> repository)
        {
            _repository = repository;
        }

        public void Execute(CloseAnAccountCommand command)
        {
            var activeAccount = _repository.GetById(command.Id);

            activeAccount.Close();

            _repository.Save(activeAccount);
        }
    }
}