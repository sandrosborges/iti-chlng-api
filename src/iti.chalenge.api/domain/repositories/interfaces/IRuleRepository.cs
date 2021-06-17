using System.Collections.Generic;
using iti.chalenge.api.domain.models;

namespace iti.chalenge.api.domain.repositories.interfaces
{
    public interface IRuleRepository
    {
         public List<RuleModel> rules {get;}
    }
}