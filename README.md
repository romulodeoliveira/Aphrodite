<h1 align="center">
  <p align="center">Aphrodite</p>
  <a href="#introdução"><img src="https://github.com/romulodeoliveira/romulodeoliveira/blob/main/img/csharp.png?raw=true" alt="Docusaurus"></a>
</h1>

# Introdução

O objetivo é criar uma API para facilitar o contato formal entre empresa e cliente. Desenvolvido em C# com foco em boas práticas de desenvolvimento de software e aplicação de conceitos do DDD. Utilizei Design by Contracts (DbC) para garantir consistência no código, e Orientação a Objetos (OOP) para modelagem do domínio da aplicação. Implementei validações de entidades do domínio com Flunt, CQRS (Command Query Responsibility Segregation) para separação de comandos e queries, Repository Pattern para abstração do acesso a dados e MSTest para os testes de unidade.

O sistema será desenvolvido com base nessa ideia:

- Usuários `Admin` conseguirão criar usuários `Customer`.
- O usuário `Customer` poderá aceitar o contrato (`Contract`) de prestação de serviços.
- Ao aceitar o contrato, o sistema gerará para o `Customer` as ordens de pagamento do período contratado (`PaymentOrder`).
- Ao realizar o pagamento, o cliente terá acesso à nota fiscal (`ElectronicInvoice`).
- O usuário `Admin` poderá lançar criativos (`Creative`) no sistema em formatos de foto ou vídeo (`File`) para aceite por parte do usuário `Customer`.
- As partes poderão trocar ideias e sujestões por meio de comentários (`Comment`).

Extras:
- O projeto contará com sistema de pagamento próprio, pelo [Banco do Brasil](https://www.bb.com.br/site/developers/).
- O projeto contará com sistema de cobrança próprio, pelo [Whatsapp](https://business.whatsapp.com/developers/developer-hub). 

# Tecnologias utilizadas

- .NET 8
- ASP.NET
- Entity Framework
- Flunt

# Estatísticas

- Github issues: ![GitHub issues](https://img.shields.io/github/issues/romulodeoliveira/Aphrodite)
- Github forks: ![GitHub forks](https://img.shields.io/github/forks/romulodeoliveira/Aphrodite)
- Github stars: ![GitHub Repo stars](https://img.shields.io/github/stars/romulodeoliveira/Aphrodite)

# Desenvolvedores

| [<img src="https://avatars.githubusercontent.com/u/100490822?v=4" width=115><br><sub>Rômulo de Oliveira</sub>](https://github.com/romulodeoliveira) |
| :-------------------------------------------------------------------------------------------------------------------------------------------------: |
| .NET Developer |