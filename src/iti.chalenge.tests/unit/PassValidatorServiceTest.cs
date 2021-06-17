using Xunit;
using FluentAssertions;
using iti.chalenge.api.domain.services.interfaces;
using iti.chalenge.api.domain.services;
using iti.chalenge.api.domain.repositories;
namespace iti.chalenge.tests.unit
{



    public class PassValidatorServiceTest
    {
        private readonly IPassValidatorService _service;

        public PassValidatorServiceTest() => 
            this._service = new PassValidatorService(new RuleRepository());
 

        [Fact]
        [Trait("Category", "Unit")]
        /// Testa senha nula (null)
        public async void ShouldReturnFalseWhenValueIsNull() =>
            (await _service.IsValid(null)).isValid.Should().BeFalse();


        [Fact]
        [Trait("Category", "Unit")]
        /// Testa senha com menos de nove caracteres
        public async void ShouldFalseWhenSmallerThanNine() =>
            (await _service.IsValid("12345678")).isValid.Should().BeFalse();


        [Fact]
        [Trait("Category", "Unit")]
        /// Testa senha que não tenha ao menos 1 dígito numerico
        public async void ShouldFalseWhenValueNotContainDigit() =>
            (await _service.IsValid("!Abcdefgh")).isValid.Should().BeFalse();


        [Fact]
        [Trait("Category", "Unit")]
        /// Testa senha que não tenha ao menos 1 letra minuscula
        public async void ShouldFalseWhenValueNotContainLowerCase() =>
            (await _service.IsValid("!ABCDEFG9")).isValid.Should().BeFalse();

        [Fact]
        [Trait("Category", "Unit")]
        /// Testa senha que não tenha ao menos 1 caracter especial
        public async void ShouldFalseWhenValueNotContainSpecial() =>
            (await _service.IsValid("Aabcdefg9")).isValid.Should().BeFalse();
  

        [Fact]
        [Trait("Category", "Unit")]
        /// Testa senha que possui caracter repetido
        public async void ShouldFalseWhenValueContainRepetition() =>
            (await _service.IsValid("1@ABcdef1")).isValid.Should().BeFalse();
     

        [Fact]
        [Trait("Category", "Unit")]
        /// Testa senha que possui caracter nao permitido
        public async void ShouldFalseWhenValueContainUnsuported() =>
            (await _service.IsValid("1|ABcdefG")).isValid.Should().BeFalse(); 

        [Fact]
        [Trait("Category", "Unit")]
        /// Testa senha que atende todas as regras
        public async void ShouldTrueWhenValueAllRulesOK() =>
            (await _service.IsValid("EUn0it@u!")).isValid.Should().BeTrue(); 

    }
}
