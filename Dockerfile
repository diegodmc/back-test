FROM mcr.microsoft.com/mssql/server:2022-latest

# Configuração do SQL Server
ENV SA_PASSWORD=Sql@2023
ENV ACCEPT_EULA=Y
ENV MSSQLSERVER=localhost

# Subindo a instância do SQL Server
EXPOSE 1433
CMD ["/opt/mssql/bin/sqlservr"]