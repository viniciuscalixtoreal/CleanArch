# CleanArch

Aplicação em .Net 8 Web API no padrão arquitetural CQRS, com os princípios da Clean Architecture, que visa a separação das operações de leitura (queries) e escrita (commands) do sistema. 
 
Junto ao CQRS, temos o MediatR, que ajuda a implementar a comunicação entre comandos, manipuladores de comandos, consultas e manipuladores de consultas, visando maior desacoplamento.

Foi utilizado também o ORM EntityFramework para implementar a persistência dos commands de escrita no banco de dados SQL Server, e Dapper para facilitar as queries de consultas.
