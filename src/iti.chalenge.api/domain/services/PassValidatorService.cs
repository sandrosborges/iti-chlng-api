using System.Text.RegularExpressions;
using System.Linq;
using iti.chalenge.api.domain.repositories.interfaces;
using iti.chalenge.api.domain.models;
using iti.chalenge.api.domain.services.interfaces;
using System.Threading.Tasks;

namespace iti.chalenge.api.domain.services
{
    public class PassValidatorService : IPassValidatorService
    {

        IRuleRepository _repo;

        private Regex regex;
        public PassValidatorService(IRuleRepository repository) => this._repo = repository;


        public async Task<ResponseModel> IsValid(string value)
        {

            if (string.IsNullOrWhiteSpace(value))
                return await Task.FromResult(new ResponseModel(false, "problemas no request"));

            //ordena os caracteres da string, para simplificar a aplicacao das regras
            var sorted = string.Concat(value.OrderBy(c => c).ToArray());

            var resp = new ResponseModel(true, "OK");

            foreach (RuleModel r in this._repo.rules)
            {
                regex = new Regex(r.regexPatern);

                if (!regex.Match(sorted ?? "").Success)
                {
                    resp.isValid =false; 
                    resp.info = r.info; 
                    break;
                }

            }

            return await Task.FromResult(resp);

        }


    }
}