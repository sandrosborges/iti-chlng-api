using System.Threading.Tasks;
using iti.chalenge.api.domain.models;

namespace iti.chalenge.api.domain.services.interfaces
{
    public interface IPassValidatorService
    {
        public Task<ResponseModel> IsValid(string value);
    }
}