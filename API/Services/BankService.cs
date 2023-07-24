using API.Contracts;
using API.DTOs.Banks;
using API.Models;

namespace API.Services
{
    public class BankService
    {
        private readonly IBankRepository _bankRepository;
        public BankService(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public IEnumerable<GetBankDto>? GetBanks()
        {
            var banks = _bankRepository.GetAll();
            if (!banks.Any())
            {
                return null; // No bank found
            }

            var toDto = banks.Select(bank =>
                                    new GetBankDto
                                    {
                                        Guid = bank.Guid,
                                        Code = bank.Code,
                                        Name = bank.Name,
                                    }).ToList();

            return toDto; // bank found
        }

        public GetBankDto? GetBank(Guid guid)
        {
            var bank = _bankRepository.GetByGuid(guid);
            if (bank is null)
            {
                return null; // bank not found
            }

            var toDto = new GetBankDto
            {
                Guid = bank.Guid,
                Code = bank.Code,
                Name = bank.Name,
            };

            return toDto; // banks found
        }

        public GetBankDto? CreateBank(CreateBankDto createBankDto)
        {
            var bank = new Bank
            {
                Guid = new Guid(),
                Code = createBankDto.Code,
                Name = createBankDto.Name,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var createdBank = _bankRepository.Create(bank);
            if (createdBank is null)
            {
                return null; // bank not created
            }

            var toDto = new GetBankDto
            {
                Guid = bank.Guid,
                Code = bank.Code,
                Name = bank.Name
            };

            return toDto; // bank created
        }

        public int UpdateBank(UpdateBankDto updateBankDto)
        {
            var isExist = _bankRepository.IsExist(updateBankDto.Guid);
            if (!isExist)
            {
                return -1; // bank not found
            }

            var getBank = _bankRepository.GetByGuid(updateBankDto.Guid);

            var bank = new Bank
            {
                Guid = updateBankDto.Guid,
                Code = updateBankDto.Code,
                Name = updateBankDto.Name,
                ModifiedDate = DateTime.Now,
                CreatedDate = getBank!.CreatedDate
            };

            var isUpdate = _bankRepository.Update(bank);
            if (!isUpdate)
            {
                return 0; // bank not updated
            }

            return 1;
        }

        public int DeleteBank(Guid guid)
        {
            var isExist = _bankRepository.IsExist(guid);
            if (!isExist)
            {
                return -1; // bank not found
            }

            var bank = _bankRepository.GetByGuid(guid);
            var isDelete = _bankRepository.Delete(bank!);
            if (!isDelete)
            {
                return 0; // bank not deleted
            }

            return 1;
        }
    }
}
