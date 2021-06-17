using System.Collections.Generic;
using iti.chalenge.api.domain.models;
using iti.chalenge.api.domain.repositories.interfaces;

namespace iti.chalenge.api.domain.repositories
{
    public class RuleRepository: IRuleRepository
    {
        private const string charSpecials = "!@#$%^&*()";

        private readonly string msgRule01 = $"Caracteres inválidos. Caracteres válidos: Letras (maiusculas e minusculas), numeros e os seguintes carcteres especiais {charSpecials}",
        msgRule02 = $"Deve possuir 9 ou mais caracteres validos. Caracteres validos: Letras, numeros e os seguintes carcteres especiais: {charSpecials}",
        msgRule03 = "Deve possuir ao menos 1 (um) digito (numerico.)",
        msgRule04 = "Deve possuir ao menos 1 (uma) letra minuscula.",
        msgRule05 = "Deve possuir ao menos 1 (uma) letra maiuscula.",
        msgRule06 = $"Deve possuir ao menos 1 caracter especial. Ex.: {charSpecials}.",
        msgRule07 = "Nao e permitido caracteres repetidos.";


        private List<RuleModel> _rules;

        public List<RuleModel> rules
        {
            get { return _rules; }
        }

        public RuleRepository()
        {
            this.SetupRules();
        }

        private void SetupRules()
        {

            this._rules = new List<RuleModel>();

            // Regra 01: Apenas caracteres validos .. !@#$%^&*()a-zA-Z0-9
            this._rules.Add(new RuleModel(@"^[!@#$%^&*()a-zA-Z0-9]+$", msgRule01));

            // Regra 02: A senha precisa ter no minimo nove caracteres
            this._rules.Add(new RuleModel(@"^(.*[a-zA-Z0-9]|[!@#\$%\^&\*\(\)]){9,}", msgRule02));

            // Regra 03: Possuir ao menos um dígito (numero)
            this._rules.Add(new RuleModel(@"^(.*[0-9]){1,}", msgRule03));

            // Regra 04: Possuir ao menos uma letra minuscula
            this._rules.Add(new RuleModel(@"^(.*[a-z]){1,}", msgRule04));

            // Regra 05: Possuir ao menos uma letra maiuscula
            this._rules.Add(new RuleModel(@"^(.*[A-Z]){1,}", msgRule05));

            // Regra 06: Possuir ao menos um caracter especial
            this._rules.Add(new RuleModel(@"^(.*[!@#\$%\^&\*\(\)]){1,}", msgRule06));

            // Regra 07: Não são permiotidos caracteres repetidos
            this._rules.Add(new RuleModel(@"^(?!.*(\w)\1{1,}).+$", msgRule07));
        }
    }
}