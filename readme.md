# Iti Backend Challenge 

### Objetivo:
Esta simples implementação se propõe a solucionar o problema de validação de senha, proposto no desafio (https://github.com/itidigital/backend-challenge)

## Pré-requisitos para executar a solução:

-   Baixar a versão 3.1 do .NET Core SDK em  [https://dotnet.microsoft.com/download/dotnet-core/3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)

## Tecnologias utilizadas:

-   C#
-   ASP .NET Core 3.1

## Executando a aplicação

### CLI
```
dotnet run --project .\src\iti.chalenge.api\
```

## Executando Testes
```
dotnet test .\src\iti.chalenge.tests\    
```

## URL's

### Health Check:  http://localhost:5000/health-check
### Swagger:       http://localhost:5000/swagger/index.html

## Explicações

#### Por que as regras (rules) foram implementadas individualmente e não utilizando apenas uma única expressão regular?
O objetivo foi implementar de forma que fosse mais legível e também que tivesse sempre uma informação dizendo qual regra falhou (info do response). Outro motivador foi a possibilidade de armazenar estas regras em uma estrutura de dados (banco). Desta forma as regras poderiam ser acrescentadas, alteradas ou removidas individualmente. Exemplo: Alterar para exigir ao menos 2 letras maiúsculas; Obrigar a ter um tamanho de 10 posições no mínimo; etc...

#### Por que é feita uma ordenação dos caracteres da senha?
A regra de verificação de caractere repetido, funciona com caracteres que se repetem de forma consecutiva.
Exemplo:  AAbcde12@ => A regra é capaz de identificar o bloco "AA" ou seja 2 caracteres repetidos, mas não seria capaz de identificar se estivesse assim Abcde12@A. Com a ordenação a repetição dos caracteres é sempre consecutiva e a expressão regular funciona corretamente.

#### Por que foi utilizado o verbo http POST para uma consulta ao invés de GET?
Ocorreriam problemas com as chamadas em caso de utilização de {path param} ou {query param} no GET devido a utilização de caracteres especiais. Isso até poderia ser resolvido com urlEncode, mas achei melhor optar pelo POST, por questões didáticas.

#### HTTPS?
Sim eu retirei o redirecionamento e as configurações de HTTPS no projeto, por se tratar de um exercício e para não receber aquela mensagem chata do navegador de que a url não é segura.


## O que falta nesta aplicação?

### LOGS
Sim! Faltam logs. Eu iria implementar os logs como middleware e a intenção seria logar todos requests e responses.  Este mecanismo poderia ser ativado/desativado no arquivo de configuração.

#### CACHE
Poderia ser criado um cache com as consultas de senhas realizadas e o resultado, de modo a não precisar passar pelas regras a cada chamada. Isto daria algum ganho se tivéssemos mais regras ou regras mais complexas (pesadas para executar).

Outra oportunidade de cache seria das próprias regras caso elas fossem carregadas de um banco de dados, evitando excessivas consultas.
