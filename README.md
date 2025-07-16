# CleanArch

Aplicação em .Net 8 Web API no padrão arquitetural CQRS, que visa a separação das operações de leitura (queries) e escrita (commands) do sistema. Também com os princípios da Clean Architecture para deixar o projeto mais limpo.
 
Junto ao CQRS, temos o MediatR, que ajuda a implementar a comunicação entre comandos, manipuladores de comandos, consultas e manipuladores de consultas, visando maior desacoplamento.

Foi utilizado também o ORM EntityFramework para implementar a persistência dos commands de escrita no banco de dados SQL Server, e Dapper para facilitar as queries de consultas.
